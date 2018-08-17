using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class LaunchState : BaseGameState {
		enum SubState 
		{
			NotLaunch,
			Launching,
			Launched,
			TimeTravel,
		}

		SubState mSubState = SubState.NotLaunch;
		float mCooldown = 3;



        #region manadatory GameState implementation
        public override void OnEnter () {
			

			// Show the UI 
			SetViewNotLaunched();
			GameViewController.Instance.ShowLaunchView();
		}

		public override void OnExit(){
		}
		public override void OnUpdate(){
			if(mSubState == SubState.Launching) {
				UpdateLaunching();
			} else if(mSubState == SubState.Launched) {
				UpdateLaunched();
			}
		}

		#endregion

		void SetViewNotLaunched() {
			GameViewController.Instance.launchView.timeCounter.UpdateTime();
			GameViewController.Instance.launchView.SetLaunchVisible(true);
			GameViewController.Instance.launchView.SetCountDownVisible(false);
		}

		void UpdateLaunching() {
			mCooldown -= Time.deltaTime;
			GameViewController.Instance.launchView.SetCountDown((int) mCooldown);

			if(mCooldown <= 0) {
				StartLaunch();
			}
		}

		void UpdateLaunched() {
			GameViewController.Instance.launchView.timeCounter.UpdateTime();
			if(GameScene.Instance.rocket.IsInSpace()) {
				mSubState = SubState.TimeTravel;
				GameScene.Instance.GotoTimeTravelState();
			}
		}

		void StartLaunch() {
			mSubState = SubState.Launched;

			GameViewController.Instance.launchView.SetCountDownVisible(false);
			GameScene.Instance.SetCameraFollow(true);
			GameScene.Instance.rocket.Flying();
			GameScene.Instance.SetDefaultSpeed();
			GameScene.Instance.StartTimeTravel();
		}

		void StartLaunching() {
			mSubState = SubState.Launching;
			mCooldown = 3;		// 5 seconds

			GameViewController.Instance.launchView.SetCountDownVisible(true);
			GameViewController.Instance.launchView.SetLaunchVisible(false);
		}

		public void OnLaunchClicked() {
			StartLaunching();
		}
	}
}