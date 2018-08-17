using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class GameScene : MonoBehaviour {
		
		public GameTime gameTime;
		public Rocket rocket;
		public CameraFollow cameraLogic;

		public float rocketSpeed = 100;		// day per second

		public float defaultSpeed = 50;
		public float[] speedSetting;


		public bool isTimeTravel = false;

		#region Singleton Logic 
		private static GameScene s_Instance;
		public static GameScene Instance
		{
			get {
				if(s_Instance != null) {
					return s_Instance;      // 已經註冊的Singleton物件
				}
				s_Instance = FindObjectOfType<GameScene>(); 
									
				return s_Instance;
			}
		}
		#endregion

		// Use this for initialization
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			mStateManager = GetComponent<GameStateManager>();
		}

		void Start () {
			gameTime = new GameTime();

			SetupUI();

			GotoHomeState();
		}

		public void ResetGame() {
			ResetGameTime();
			isTimeTravel = false;
			rocketSpeed = 0;
		}

		public void ResetGameTime() {
			gameTime.SetYearDay(2018, 200);
		}
		
		// Update is called once per frame
		void Update () {
			if(isTimeTravel) {
				UpdateGameTime();
			}
		}

		void SetupUI() {

			// Setup the Game time
			GameViewController.Instance.landingView.timeCounter.gameTime = gameTime;
			GameViewController.Instance.launchView.timeCounter.gameTime = gameTime;
			GameViewController.Instance.rocketView.timeCounter.gameTime = gameTime;
		}



		#region State Logic 

		protected GameStateManager mStateManager;
		public void GotoHomeState() {
			mStateManager.SetState(typeof(HomeState));
		}
		public void GotoLaunchState() {
			mStateManager.SetState(typeof(LaunchState));
		}
		public void GotoTimeTravelState() {
			mStateManager.SetState(typeof(TimeTravelState));
		}
		public void GotoLandingState() {
			mStateManager.SetState(typeof(LandingState));
		}

		#endregion

		#region Camera Logic
		public void SetCameraFollow(bool flag) {
			cameraLogic.SetEnable(flag);
		}

		public void ResetCamera() {
			cameraLogic.ResetOrigin();
		}
		
		#endregion

		#region Rocket Speed
		public void StartTimeTravel() {
			isTimeTravel = true;
		}

		public void StopTimeTravel() {
			isTimeTravel = false;
		}


		public void SetRocketSpeed(float speed) {
			rocketSpeed = speed;
		}

		public void SetDefaultSpeed() {
			rocketSpeed = defaultSpeed;
		}

		public void SetRocketSpeedByEnergy(int energyLevel) {
			float speed = 300;
			if(energyLevel == 2) {
				speed = 30000;
			} else if(energyLevel == 1) {
				speed = 3000;
			}

			SetRocketSpeed(speed);
		}

		#endregion

		void UpdateGameTime(){
			float dayDelta = Time.deltaTime * rocketSpeed;
			gameTime.ReduceTime(dayDelta);
		}
	}
}