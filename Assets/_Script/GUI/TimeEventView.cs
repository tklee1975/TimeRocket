using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kencoder
{
	public class TimeEventView : BaseUI {
		public TimeEventListView eventListView;
		public Button eventListButton;
		public Text headingText;
		public Text unlockProgressText;

		public int startYear = 0;
		public int endYear = 0;

		protected int mUnlockedCount = 0;
		protected int mTotalCount = 0;

		protected bool mEventListShown = false;

		public Color[] progressColorList;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		
		public void SetEventBetween(int _startYear, int _endYear) 
		{
			startYear = _startYear;
			endYear = _endYear;

			List<TimeEventData> eventList = MainGameManager.Instance.GetEventBetween(startYear, endYear);
			eventListView.SetTimeEventList(eventList);
			ShowEventList();

			mUnlockedCount = MainGameManager.Instance.GetUnlockCount(eventList);
			mTotalCount = eventList.Count;

			UpdateHeading();
			UpdateUnlockProgress();
		}

		void UpdateUnlockProgress() {
			float percent = (float) mUnlockedCount / mTotalCount;
			unlockProgressText.text = "UNLOCKED: " + mUnlockedCount + " / " + mTotalCount
							 + "  (" + (int)(percent * 100) + "%)";

			
			UpdateProgressColor(percent);
		}

		public void UpdateProgressColor(float percent) {
			unlockProgressText.color = GetProgressColor(percent);
		}

		Color GetProgressColor(float percent) {
			int index = (int)(percent * (progressColorList.Length - 1));
			if(index >= progressColorList.Length - 1) {
				index = progressColorList.Length - 1;
			}

			return progressColorList[index];
		}

		void UpdateHeading() {
			headingText.text = startYear + " - " + endYear + " AD";
		}

		void SetButtonName(Button button, string name) {
			Text text = button.GetComponentInChildren<Text>();
			if(text != null) {
				text.text = name;
			}
		}

		public void ToggleEventClicked() {
			if(mEventListShown) {
				HideEventList();
			} else {
				ShowEventList();
			}
		}

		public void ShowEventList() {
			eventListView.gameObject.SetActive(true);

			mEventListShown = true;

			SetButtonName(eventListButton, "HIDE EVENTS");
		}

		public void HideEventList() {
			eventListView.gameObject.SetActive(false);

			mEventListShown = false;

			SetButtonName(eventListButton, "SHOW EVENTS");
		}
	}
}