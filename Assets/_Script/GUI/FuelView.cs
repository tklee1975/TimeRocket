using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kencoder
{
	public class FuelView : MonoBehaviour {
		public Slider slider;
		public Text fuelCountText;
		public Text energyText;
		public Image energyBarImage;



		[Header("Energy Setting")]
		public Color[] energyColors;
		public string[] energyName;
		
		
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

		string GetEnergyName(int index) {
			if(index < 0) {
				return "";
			}
			if(index >= energyName.Length) {
				index = energyName.Length - 1;
			}
			return energyName[index];
		}

		Color GetEnergyColor(int index) {
			if(index < 0) {
				return Color.white;
			}
			if(index >= energyColors.Length) {
				index = energyColors.Length - 1;
			}
			return energyColors[index];
		}

		public void SetEnergy(int energyIndex) {
			int index = energyIndex + 1;
			string energyName = GetEnergyName(index);
			Color energyColor = GetEnergyColor(index);

			Debug.Log("Energy=" + index + " energyName=" + energyName + " color=" + energyColor);
			
			energyText.text = energyName;
			energyBarImage.color = energyColor;
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