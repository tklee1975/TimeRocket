using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kencoder
{
	public class EventItemView : MonoBehaviour {
		public Text yearText;
		public Text eventText;
		public Text lockedText;

		public int lockedHeight = 30;
		public int unlockHeight = 50;




		public void SetYear(int year) {
			yearText.text = year.ToString("0000");
		}

		public void SetEvent(string eventMsg) {
			eventText.text = eventMsg;
		}

		public void SetHeight(int height) {
			RectTransform rt = transform as RectTransform;

			Vector3 size = rt.sizeDelta;
			size.y = height;

			rt.sizeDelta = size;
		}


		public void SetStatus(bool isUnlocked) {
			if(isUnlocked) {
				eventText.gameObject.SetActive(true);
				lockedText.gameObject.SetActive(false);
				SetHeight(unlockHeight);
			} else {
				eventText.gameObject.SetActive(false);
				lockedText.gameObject.SetActive(true);
				SetHeight(lockedHeight);
			}
		}
	}
}