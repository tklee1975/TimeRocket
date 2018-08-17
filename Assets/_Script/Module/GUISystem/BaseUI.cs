using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Kencoder
{

	public class BaseUI : MonoBehaviour {
		protected Vector3 mOffsetScreenPos = new Vector3(0, 1000, 0);

		public BaseViewController viewController;

		private float mTopOffsetY = 0;

		void Awake() {
			//mTopOffsetY = 
		}

		void Start() {			
		}



		virtual public void WillShow() {
			// the View will be shown
			// ken: uncomment when use localization
			//  LocalizationManager.Instance.RefreshLocalizedUI();
		}

		public bool IsShowing {
			get {
				return gameObject.activeSelf;
				// if(viewController == null) {
				// 	viewController = GetComponentInParent<BaseViewController>();
				// }
				// Debug.Log("IsShowing: viewController=" + viewController);
				// return viewController == null ? false : viewController.IsShowing(this);
			}
		}

		public void Show(bool hideOther=true) {
			SetPanelVisible(gameObject, true);
			gameObject.SetActive(true);

			//Debug.Log("BaseUI: HideOthers=" + hideOther);
			if(hideOther) {
				HideOthers();
			}
			WillShow();
			if(viewController != null) {
				viewController.OnViewShown(this);
			}
		}

		virtual public void DidHide() {
			// the View is already hidden 
		}

		public void Hide() {
			SetPanelVisible(gameObject, false);
			gameObject.SetActive(false);
			DidHide();

			if(viewController != null) {
				viewController.OnViewClosed(this);
			}

			if(onCloseCallback != null) {
				onCloseCallback();
			}
		}


		protected void HideOthers()  {
			if(viewController == null) {
				//Debug.LogError("BaseUI.HideOther: viewController is null");
				return;
			}

			viewController.HideOthers(this);
		}




		protected void SetPanelVisible(GameObject panelObj, bool visible) {
			if(panelObj == null) {
				return;
			}

			RectTransform rect = panelObj.transform as RectTransform;
			if(rect.anchorMax.y == 1) {
				Vector2 anchorPos = rect.anchoredPosition;
				anchorPos.x = 0;
				anchorPos.y = visible ? 0.0f : mOffsetScreenPos.y;

				rect.anchoredPosition = anchorPos;
			} else {
				Vector3 targetPos = visible ? Vector3.zero : 
					mOffsetScreenPos;
				panelObj.transform.localPosition = targetPos;
			}



		}


		// BACK TO HOME
		public delegate void Callback();
		public Callback onCloseCallback = null;

		// Doing the Callback
		public void OnBackClicked() {
			Hide();
		}
	}
}
