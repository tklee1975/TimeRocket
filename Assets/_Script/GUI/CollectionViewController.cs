using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class CollectionViewController : BaseViewController {
		public CollectionView collectionView;
		public TimeEventView timeEventView;

		#region Singleton Logic 
		private static CollectionViewController s_Instance;
		public static CollectionViewController Instance
		{
			get {
				if(s_Instance != null) {
					return s_Instance;      // 已經註冊的Singleton物件
				}
				s_Instance = FindObjectOfType<CollectionViewController>(); 
									
				return s_Instance;
			}
      	}
		#endregion

		// Use this for initialization
		void Start () {
			AddBaseUI(collectionView);
			AddBaseUI(timeEventView);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void ShowCollectionView() {
			collectionView.Setup();
			collectionView.Show(false);
		}

		public void ShowTimeEventViewForID(int worldID) {
			TimeSceneData sceneTime = MainGameManager.Instance.GetSceneDataForID(worldID);
			if(sceneTime != null) {
				ShowTimeEventView(sceneTime);
			}
		}

		public void ShowTimeEventView(TimeSceneData scene) {
			
			timeEventView.SetEventBetween(scene.startYear, scene.endYear);

			//
			timeEventView.onCloseCallback = () => {
				ShowCollectionView();
			};


			//
			timeEventView.Show();
		}

	}
}
