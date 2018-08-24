using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class CollectionScene : MonoBehaviour {
		public WorldModel worldModel;

		// Use this for initialization
		void Start () {
			CollectionViewController.Instance.ShowCollectionView();

			CollectionViewController.Instance.collectionView.selectCallback = (int worldID) => {
				ShowTimeEvent(worldID);
			};
		}
		
		void ShowTimeEvent(int worldID) {
			worldModel.SetWorldForID(worldID);
			CollectionViewController.Instance.ShowTimeEventViewForID(worldID);
		}
	}
}