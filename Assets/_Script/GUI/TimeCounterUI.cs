using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kencoder
{
	public class TimeCounterUI : MonoBehaviour {
		public Text yearText;
		public Text dayText;
		public GameTime gameTime;

		// Use this for initialization
		void Start () {
			UpdateTimeGame();
		}

		public void UpdateTimeGame()
		{
			if(gameTime == null) {
				return;
			}

			yearText.text = gameTime.year.ToString("0000");
			dayText.text = gameTime.day.ToString("000");
		}
		
	}
}