using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class TimeTravelState : BaseGameState {
		protected RocketControlView rocketView;	// For easy reference

		public int fuelCount = 4;
		public float fuelAmount = 100;

		public float fuelDrainRate = 20;	// 50 pt per second

        #region manadatory GameState implementation
        public override void OnEnter () {
			rocketView = GameViewController.Instance.rocketView;

			rocketView.timeCounter.UpdateTime();

			rocketView.boosterView.onBoostCallback = (int energyLevel) => {
				OnBoosting(energyLevel);
			};

			rocketView.boosterView.onLandCallback = () => {
				StartLanding();
			};

			GameScene.Instance.SetRocketSpeedByEnergy(0);
			rocketView.fuelView.SetEnergy(0);
			GameViewController.Instance.ShowRocketView();

			Setup();
		}
		
		public override void OnExit(){
		}

		public override void OnUpdate(){
			rocketView.timeCounter.UpdateTime();

			UpdateFuel();
		}

		#endregion

		void Setup() {
			SetupFuel();

			// Make the booster swinging
			
			rocketView.boosterView.Reset();
			rocketView.boosterView.StartSwing();
			rocketView.boosterView.EnableBooster();
		}

		void DisableUI() {
			rocketView.boosterView.StopSwing();
		}

		void StartLanding() {
			GameScene.Instance.GotoLandingState();
		}

		void ResetBooster() {
			rocketView.boosterView.Reset();
			rocketView.boosterView.StartSwing();
		}

		void StopBooster() {
			rocketView.boosterView.StopSwing();
			rocketView.boosterView.DisableBooster();
		}

		void OnBoosting(int boostValue) {
			rocketView.fuelView.SetEnergy(boostValue);
			GameScene.Instance.SetRocketSpeedByEnergy(boostValue);

			if(fuelCount > 1) {
				OnFuelUsed();
			}
			if(fuelCount > 1) {
				ResetBooster();
			} else {
				StopBooster();
			}
		}


		#region Fuel Drain Logic
		void SetupFuel() {
			fuelCount = 5;	// TODO: Define in GameSetting
			rocketView.fuelView.SetFuel(fuelAmount);
			ResetFuel();
		}

		void ResetFuel() {
			fuelAmount = 100;
			rocketView.fuelView.SetFuelCount(fuelCount);
		}

		void OnFuelUsed() {
			fuelCount--;
			rocketView.fuelView.SetFuelCount(fuelCount);
			ResetFuel();
		}

		

		void UpdateFuel() {
			fuelAmount -= fuelDrainRate * Time.deltaTime;

			rocketView.fuelView.SetFuel(fuelAmount);

			if(fuelAmount <= 0) {
				if(fuelCount <= 1) {		// force landing
					StartLanding();
				} else {
					OnFuelUsed(); 
				}				
			}
		}

		#endregion
	}
}