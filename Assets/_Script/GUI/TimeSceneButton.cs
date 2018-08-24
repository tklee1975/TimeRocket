using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kencoder
{
	public class TimeSceneButton : MonoBehaviour {
		public int worldID = 0;

		public Image lockedImage = null;
		public Image timeSceneImage = null;
		public Button clickButton = null;

		public bool status = false;

		public delegate void Callback(int worldID);


		public Callback worldSelectedCallback = null;

		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start()
		{
			clickButton = GetComponent<Button>();
			UpdateUI();
		}

		public void UpdateUI() {
			bool isUnlock = MainGameManager.Instance.saveData.IsSceneUnLocked(worldID);
			Debug.Log("DEBUG: worldID=" + worldID + " unlock=" + isUnlock);
			SetLockStatus(isUnlock);
		}

		void SetLockStatus(bool isUnlock) {
			status = isUnlock;
			if(status) {
				SetAsUnlocked();
			} else {
				SetAsLocked();
			}
		}

		public void OnButtonClicked() {
			if(worldSelectedCallback != null) {
				worldSelectedCallback(worldID);
			}
		}

		public void SetAsUnlocked() {
			status = true;
			//clickButton.interactable = true;
			timeSceneImage.enabled = true;
			lockedImage.gameObject.SetActive(false);
			timeSceneImage.sprite = Resources.Load<Sprite>("TimeScene/time_scene_" + worldID);
		}

		public void SetAsLocked() {
			status = false;
			//clickButton.interactable = false;
			timeSceneImage.enabled = false;
			lockedImage.gameObject.SetActive(true);
		}
	}
}