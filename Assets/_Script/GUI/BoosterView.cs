using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kencoder
{
	public class BoosterView : MonoBehaviour {
		public Slider energySlider;
		public float swingSpeed = 10.0f;

		public int energyRange2 = 90;
		public int energyRange1 = 60;

		protected bool mSwing = false;
		protected int mSwingDir = 1;



		// Use this for initialization
		void Start () {
			mSwing = false;
		}

		public void StartSwing() {
			mSwing = true;
		}

		public void StopSwing() {
			mSwing = false;
		}

		public void Reset() {
			energySlider.value = 0;
			mSwingDir = 1;
			mSwing = false;
		}

		void UpdateSlideValue() {
			float newValue = energySlider.value + swingSpeed * mSwingDir;
			if(newValue > 100) {
				mSwingDir = -1;
				newValue = 100;
			} else if(newValue < 0) {
				mSwingDir = 1;
				newValue = 0;
			}
			energySlider.value = newValue;
		}

		
		// Update is called once per frame
		void Update () {
			if(mSwing) {
				UpdateSlideValue();	
			}
		}

		public int energyLevel {
			get {
				float energyValue = energySlider.value;
				if(energyValue > energyRange2) {
					return 2;
				} else if(energyValue > energyRange1) {
					return 1;
				} else {
					return 0;
				}
				//fore
			}
		}

		public void OnBoostClicked() {
			mSwing = false;
			if(onBoostCallback != null) {
				onBoostCallback();
			}
		}

		public void OnLandClicked() {
			mSwing = false;
			if(onLandCallback != null) {
				onLandCallback();
			}
		}


		// callback
		public delegate void Callback();

		public Callback onBoostCallback = null;
		public Callback onLandCallback = null;
	}
}