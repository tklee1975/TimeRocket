using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

namespace Kencoder
{
	public class GameSaveData : JSONData {
        const string kSaveFile = "profile.dat";


        protected Dictionary<int, bool> mUnlockSceneSet = new Dictionary<int, bool>();
        protected Dictionary<int, bool> mUnlockEventSet = new Dictionary<int, bool>();	// year

        #region Save / Load / Reset
		public void Save() {
			SaveToFile(kSaveFile);
		}

		public bool Load() {
			if(File.Exists(Application.persistentDataPath + "/" + kSaveFile) == false) {
				Reset();
				return true; 
			}

			

			bool result = LoadFromFile(kSaveFile);
			return result;
		}

        public void Reset() {
			//		
            mUnlockEventSet.Clear();
            mUnlockSceneSet.Clear();
			Save();
		}
        #endregion


	



        public void AddUnlockScene(int worldID, bool autoSave=true){
			//mUnlockPlayerObjectList [unitID] = true;
			if(mUnlockSceneSet.ContainsKey(worldID)) {
				return;	// already added
			}

			mUnlockSceneSet.Add(worldID, true);

			if(autoSave) {
				Save ();
			}
		}

		public void AddUnlockEvent(int year, bool autoSave=true){
			//mUnlockPlayerObjectList [unitID] = true;
			if(mUnlockEventSet.ContainsKey(year)) {
				return;	// already added
			}

			mUnlockEventSet.Add(year, true);

			if(autoSave) {
				Save ();
			}
		}

		public bool IsSceneUnLocked(int worldID) {
			return mUnlockSceneSet.ContainsKey(worldID);
		}

		public bool IsEventUnlocked(int year) {
			return mUnlockEventSet.ContainsKey(year);
		}

        public List<int> GetUnlockSceneList(){
			return new List<int>(mUnlockSceneSet.Keys);
		}

		 public List<int> GetUnlockEventList(){
			return new List<int>(mUnlockEventSet.Keys);
		}

		public string InfoUnlockScene() {
			List<int> unlockList = GetUnlockSceneList();

			return StringHelper.JoinIntList(", ", unlockList);
		}

		#region JSON Implementation

		public override void ParseJSONData(Dictionary<string, object> jsonData) {

			List<object> objectList = JSONHelper.GetList (jsonData, "unlockSceneList");
			if(objectList != null) {
				foreach (object obj in objectList) {
					AddUnlockScene(JSONHelper.objectToInt(obj), false);
				}	
			}

			objectList = JSONHelper.GetList (jsonData, "unlockEventList");
			if(objectList != null) {
				foreach (object obj in objectList) {
					AddUnlockEvent(JSONHelper.objectToInt(obj), false);
				}	
			}

            // TODO Event
		}

		public override void DefineJSON (Dictionary<string, object> outDict)
		{
			List<int> unlockList = GetUnlockSceneList();
			AddIntList(outDict, "unlockSceneList", unlockList);

			unlockList = GetUnlockEventList();
			AddIntList(outDict, "unlockEventList", unlockList);
		}
			
		#endregion	
    }
}
