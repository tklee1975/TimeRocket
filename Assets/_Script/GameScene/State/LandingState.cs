using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class LandingState : BaseGameState {
		LandingView landingView;

        #region manadatory GameState implementation
        public override void OnEnter () {
			GameScene.Instance.UpdateUnlockData();
			GameScene.Instance.SetWorldModelForTime();
			landingView = GameViewController.Instance.landingView;

			GameScene.Instance.StopTimeTravel();

			landingView.timeCounter.UpdateTime();
			GameViewController.Instance.ShowLandingView();

			SetupUI();
			SetupScene();
		}
		
		public override void OnExit(){
		}
		public override void OnUpdate(){
		}

		#endregion


		void SetupUI() {
			

			landingView.SetKeyEvent("");
			landingView.SetPlayButtonVisible(false);
		}

		void SetupScene() {
			GameScene.Instance.rocket.Landing();

			GameScene.Instance.rocket.onStateChanged = OnRocketStateChanged;
		}

		void OnRocketStateChanged(Rocket.State newState) {
			if(newState == Rocket.State.Landed) {
				OnRocketLanded();
			}
		}

		void OnRocketLanded()
		{
			int year = GameScene.Instance.gameTime.year;
			string eventName = MainGameManager.Instance.GetTimeEventName(year);
			if(eventName == "") {
				eventName = "No news may be a Good news!";
			}

			landingView.SetKeyEvent(eventName);
			landingView.SetPlayButtonVisible(true);
		}
		

		public void OnPlayClicked() {
			GameScene.Instance.ResetGame();
			GameScene.Instance.GotoHomeState();
		}

	
	}
}