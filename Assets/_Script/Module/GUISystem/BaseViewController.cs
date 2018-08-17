using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder {
	public class BaseViewController : MonoBehaviour {

		protected List<BaseUI> mBaseUIList = new List<BaseUI>();
		protected Dictionary<string, BaseUI> mBaseUIDict = new Dictionary<string, BaseUI>();


		protected void ClearBaseUIList() {
			mBaseUIDict.Clear();
		}

		// Use this for initialization
		void Start () {
			Debug.Log("BaseViewController.Start");
		}

		// Update is called once per frame
		void Update () {

		}

		#region General & Common
		protected virtual void DidAwake() {

		}

		void Awake() {
			Debug.Log("BaseViewController.Awake");
			ClearBaseUIList();

			// 
			HideAll();

			//
			ShowInfo();

			DidAwake();
		}

		public void HideAll() {
			HideOthers(null);
		}

		public void HideOthers(Object caller) {
			foreach(BaseUI uiObj in mBaseUIDict.Values) {
				if(uiObj != caller) {
					uiObj.Hide();
				}
			}
		}

		protected void AddBaseUI(BaseUI uiObject, string name = "")
		{
			if(uiObject == null) {
				Debug.LogError("AddBaseUI: uiObject is null. name=" + name);
			}

			if(name == "") {
				name = uiObject.name;
			}
			// Debug.Log("AddUI: name=" + uiObject.name);
			uiObject.viewController = this;
			//	mBaseUIList.Add(uiObject);

			mBaseUIDict.Add(name, uiObject);
		}

		public void ShowUI(string name, bool hideOther = true) {
			Debug.Log("ShowUI: name=" + name + " hide=" + hideOther);
			if(mBaseUIDict.ContainsKey(name) == false) {
				return;
			}

			BaseUI uiObj = mBaseUIDict[name];
			uiObj.Show(hideOther);
		}

		public bool IsShowing(BaseUI ui) {
			if(ui == null) {
				return false;
			}
			
			return mBaseUIDict.ContainsValue(ui);
		}

		#endregion

		// Sample Code for the sub class
		//
		//		#region Normal Mode Game UI
		//		private NormalModeGUI mNormalModeGameGUI;
		//
		//		void SetupNormalGameUI() {
		//			GameObject obj = GameObjectHelper.GetChildObject(gameObject, "InGamePanel");
		//			mNormalModeGameGUI= obj.GetComponent<NormalModeGUI>();
		//			AddBaseUI(mNormalModeGameGUI);		// effect: VC help control view
		//			// e.g MainUI.Show -> vc help close other views
		//		}
		//
		//		public NormalModeGUI NormalModeUI {
		//			get {
		//				return mNormalModeGameGUI;
		//			}
		//		}
		//
		//		#endregion

		public virtual void OnViewClosed(BaseUI closedView) {

		}

		public virtual void OnViewShown(BaseUI closedView) {

		}

		


		#region Class information
		public void ShowInfo() {
			Debug.Log("==================================");
			Debug.Log("VC: " + Info());
			Debug.Log("==================================");
		}

		public virtual string Info() {
			string info = "BaseViewController";

			return info;
		}

		#endregion


	}
}