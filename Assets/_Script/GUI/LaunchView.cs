using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kencoder
{
	public class LaunchView : BaseUI {
		public Text countDownText;
		public TimeCounterUI timeCounter;
		public Button launchButton;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void SetCountDownVisible(bool flag) {
			countDownText.gameObject.SetActive(flag);
		}

		public void SetCountDown(int value) {
			if(countDownText == null) {
				return;
			}
			if(value == 0) {
				countDownText.text = "GO";
			} else if(value > 0) {
				countDownText.text = value.ToString();
			} else {
				countDownText.text = "";
			}
		}

		public void SetLaunchVisible(bool flag) {
			launchButton.gameObject.SetActive(flag);
		}

		public void UpdateTimeCounter() {
			timeCounter.UpdateTime();
		}
	}

}
