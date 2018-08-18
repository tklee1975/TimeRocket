using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class HomeState : BaseGameState {

        #region manadatory GameState implementation
        public override void OnEnter () {
			GameScene.Instance.ResetWorldModel();
			GameScene.Instance.ResetCamera();
			GameScene.Instance.SetCameraFollow(false);
			GameViewController.Instance.ShowHomeView();
		}
		public override void OnExit(){
		}
		public override void OnUpdate(){
		}

		#endregion

	
		

		public void OnStartClicked() {
			GameScene.Instance.ResetGame();
			GameScene.Instance.GotoLaunchState();
		}
	}
}