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
		}

		#endregion

	public void Startup() {

	}

		#region TimeScene Data 

		protected List<TimeSceneData> mTimeSceneDataList = new List<TimeSceneData>();

		void LoadTimeSceneData() {
			mTimeSceneDataList.Clear();

			string path = "Data/TimeSceneData";
			string content = FileHelper.ReadFileFromAsset(path);

			List<object> jsonDataArray = (List<object>) MiniJSON.Json.Deserialize(content);
			foreach (object obj in jsonDataArray) {
				Dictionary<string, object> recordJSON = (Dictionary<string, object>) obj;
				
				TimeSceneData data = new TimeSceneData();
				data.ParseJSONData(recordJSON);
				
				Debug.Log("DEBUG: " + data.ToString());
				// AuroraGameRecord record = new AuroraGameRecord ();
				// record.ParseJSONData (recordJSON);

				// recordList.Add (record);
                mTimeSceneDataList.Add(data);
			}
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


	}
}