using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class CollectionView : BaseUI {
		public delegate void SelectCallback(int worldID);

		public SelectCallback selectCallback = null;

		// Use this for initialization
		void Start () {
			TimeSceneButton[] buttonList = transform.GetComponentsInChildren<TimeSceneButton>();

			foreach(TimeSceneButton button in buttonList) {
				button.worldSelectedCallback = OnSceneClicked;
			}
		}

		public void Setup() {
			TimeSceneButton[] buttonList = transform.GetComponentsInChildren<TimeSceneButton>();

			foreach(TimeSceneButton button in buttonList) {
				button.UpdateUI();
			}
		}
		
		
		public void OnSceneClicked(int worldID) {
			if(MainGameManager.Instance.saveData.IsSceneUnLocked(worldID) == false) {
				return;
			}

			if(selectCallback != null) {
				selectCallback(worldID);
			}
		}

		public void OnBackClicked() {
			// 
			//Scene
			SceneHelper.GotoMainScene();
		}
	}
}