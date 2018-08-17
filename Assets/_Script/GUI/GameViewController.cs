using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class GameViewController : BaseViewController {
		public HomeView homeView;
		public LaunchView launchView;
		public LandingView landingView;
		public RocketControlView rocketView;

		#region Singleton Logic 
		private static GameViewController s_Instance;
		public static GameViewController Instance
		{
			get {
				if(s_Instance != null) {
					return s_Instance;      // 已經註冊的Singleton物件
				}
				s_Instance = FindObjectOfType<GameViewController>(); 
									
				return s_Instance;
			}
      	}
		#endregion

		// Use this for initialization
		void Start () {
			AddBaseUI(homeView);
			AddBaseUI(launchView);
			AddBaseUI(landingView);
			AddBaseUI(rocketView);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void ShowHomeView() {
			homeView.Show();
		}

		public void ShowLaunchView() {
			launchView.Show();
		}

		public void ShowRocketView() {
			rocketView.Show();
		}

		public void ShowLandingView() {
			landingView.Show();
		}

	}
}