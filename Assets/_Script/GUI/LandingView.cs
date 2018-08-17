using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Reference:
//		http://www.thenagain.info/WebChron/World/Decolonization.html


namespace Kencoder
{
	public class LandingView : BaseUI {
		public Text keyEventText; 
		public TimeCounterUI timeCounter;
		public Button playButton;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		
		public void UpdateTimeCounter() {
			timeCounter.UpdateTime();
		}

		public void SetKeyEvent(string eventName) {
			keyEventText.text = eventName;
		}

		public void SetPlayButtonVisible(bool flag) {
			playButton.gameObject.SetActive(flag);
		}
	}

}
