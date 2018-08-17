using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kencoder
{
	public class FuelView : MonoBehaviour {
		public Slider slider;
		public Text fuelCountText;
		
		
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void SetFuelCount(int value)
		{
			fuelCountText.text = value.ToString();
		}

		public void SetFuel(float fuel) {
			if(slider != null) {
				if(fuel < 0) {
					fuel = 0;
				}
				slider.value = fuel;
			}
		}
	}
}