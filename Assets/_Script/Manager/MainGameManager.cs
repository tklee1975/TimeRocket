using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class MainGameManager : ScriptableObject {

		#region Singleton Code
		protected static MainGameManager sInstance = null;

		public static MainGameManager Instance
		{
			get
			{
				if (sInstance == null) {
					sInstance = ScriptableObject.CreateInstance<MainGameManager>();
					sInstance.hideFlags = HideFlags.HideAndDontSave;	// Not visible to the user and not save
				}

				return sInstance;
			}
		}

		void OnEnable() {
			LoadTimeSceneData();
			LoadTimeEventData();
			LoadGameSave();
		}

		#endregion

	public void Startup() {

	}

		#region TimeScene Data 

		protected Dictionary<int, TimeSceneData> mTimeSceneDataDict = new Dictionary<int, TimeSceneData>();
		protected List<TimeSceneData> mTimeSceneDataList = new List<TimeSceneData>();

		public List<TimeSceneData> timeSceneList 
		{
			get {
				return mTimeSceneDataList;
			}
		}

		void LoadTimeSceneData() {
			mTimeSceneDataList.Clear();
			mTimeSceneDataDict.Clear();

			string path = "Data/TimeSceneData";
			string content = FileHelper.ReadFileFromAsset(path);

			int endYear = 2018;

			List<object> jsonDataArray = (List<object>) MiniJSON.Json.Deserialize(content);
			foreach (object obj in jsonDataArray) {
				Dictionary<string, object> recordJSON = (Dictionary<string, object>) obj;
				
				TimeSceneData data = new TimeSceneData();
				data.ParseJSONData(recordJSON);
				data.endYear = endYear;
				
				// Debug.Log("DEBUG: " + data.ToString());
				// AuroraGameRecord record = new AuroraGameRecord ();
				// record.ParseJSONData (recordJSON);

				// recordList.Add (record);
				mTimeSceneDataDict.Add(data.worldID, data);
                mTimeSceneDataList.Add(data);

				endYear = data.startYear - 1;
			}
		}

		public TimeSceneData GetSceneDataForID(int _worldID) {
			if(mTimeSceneDataDict.ContainsKey(_worldID) == false) {
				return null;
			}

			return mTimeSceneDataDict[_worldID];
		}

		public TimeSceneData GetSceneDataForYear(int year)
		{

			// Using Range 
			foreach(TimeSceneData data in mTimeSceneDataList) {
				if(data.isRange == false) {
					continue;
				}
				if(year >= data.startYear) {
					return data;
				}
			}

			return mTimeSceneDataList[0];	// the first one
		}

		


		#endregion


		#region TimeEvent Data 

		protected Dictionary<int, string> mYearEventDict = new Dictionary<int, string>();
		protected List<TimeEventData> mTimeEventList = new List<TimeEventData>();
		protected List<TimeEventData> mTimeEventRangeList = new List<TimeEventData>();

		void LoadTimeEventData() {
			mYearEventDict.Clear();
			mTimeEventList.Clear();
			mTimeEventRangeList.Clear();

			string path = "Data/TimeEventData";
			string content = FileHelper.ReadFileFromAsset(path);

			List<object> jsonDataArray = (List<object>) MiniJSON.Json.Deserialize(content);
			foreach (object obj in jsonDataArray) {
				Dictionary<string, object> recordJSON = (Dictionary<string, object>) obj;
				
				TimeEventData data = new TimeEventData();
				data.ParseJSONData(recordJSON);
				
				// Debug.Log("DEBUG: " + data.ToString());
				if(data.enable == false) {
					continue;
				}

				if(data.isRange) { 
					AddTimeRangeEvent(data);
				} else { 
					AddTimeEvent(data);
				}

				
			}
		}

		public void ResetData() {
			saveData.Reset();
		}

		public void AddUnlockEvent(int year) {
			if(! mYearEventDict.ContainsKey(year)) {
				return;
			}

			mSaveData.AddUnlockEvent(year);
		}

		public void UnlockAllScene() {
			foreach(TimeSceneData data in mTimeSceneDataList){
				mSaveData.AddUnlockScene(data.worldID);
			}
		}

		public void UnlockAllEvent() {
			foreach(TimeEventData data in mTimeEventList){
				if(data.isRange) {
					continue;	// No include the range data
				}
				mSaveData.AddUnlockEvent(data.year);
			}
			mSaveData.Save();
		}

		public List<TimeEventData> timeEventList {
			get {
				return mTimeEventList;
			}
		}

		public int GetUnlockCount(List<TimeEventData> eventDataList) {
			int count = 0;

			foreach(TimeEventData data in eventDataList){
				if(data.isRange) {
					continue;	// No include the range data
				}

				if(saveData.IsEventUnlocked(data.year)) {
					count++;
				}
			}

			return count;
		}

		public List<TimeEventData> GetEventBetween(int startYear, int endYear) {

			
			List<TimeEventData> result = new List<TimeEventData>();

			foreach(TimeEventData data in mTimeEventList){
				if(data.year < startYear) {
					continue;
				}
				if(data.year > endYear) {
					break;
				}

				result.Add(data);
			}


			return result;
		}

		void AddTimeRangeEvent(TimeEventData data) {
			mTimeEventRangeList.Add(data);
		}

		void AddTimeEvent(TimeEventData data) {
			int year = data.year;
			string name = data.eventName;

			if(name == "") {
				return;
			}
			if(mYearEventDict.ContainsKey(year)) {
				return;
			}
			mTimeEventList.Add(data);
			mYearEventDict.Add(year, name);
		}

		public string GetTimeEventName(int year) {
			if(mYearEventDict.ContainsKey(year)) {
				return mYearEventDict[year];
			}

			foreach(TimeEventData data in mTimeEventRangeList) {
				//Debug.Log("GetTime: " + data.ToString());
				if(year >= data.year && year <= data.endYear) {
					return data.eventName;
				}
			}

			return "";
		}
		#endregion

		#region Game Save 
		protected GameSaveData mSaveData = new GameSaveData();

		public GameSaveData saveData {
			get {
				return mSaveData;
			}
		}

		public void LoadGameSave() {
			mSaveData.Load();
		}

		public void SaveGameSave() {
			mSaveData.Save();
		}


		#endregion
	}
}