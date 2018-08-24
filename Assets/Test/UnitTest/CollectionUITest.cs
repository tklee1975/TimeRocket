using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;
using Kencoder;

public class CollectionUITest : BaseTest {		
	public TimeSceneButton sceneButton;
	public EventItemView eventItemView;
	public TimeEventListView listView;
	public TimeEventView timeEventView;

	//public

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		//SetSampleData();
		Debug.Log("UnlockList: " + MainGameManager.Instance.saveData.InfoUnlockScene());
	}

	void SetSampleData()
	{
		MainGameManager.Instance.saveData.Reset();
		MainGameManager.Instance.saveData.AddUnlockScene(1);
		MainGameManager.Instance.saveData.AddUnlockScene(2);
		MainGameManager.Instance.saveData.AddUnlockScene(4);

		MainGameManager.Instance.saveData.AddUnlockEvent(1);
		MainGameManager.Instance.saveData.AddUnlockEvent(34);
		MainGameManager.Instance.saveData.AddUnlockEvent(59);
	}

	[Test]
	public void UnlockAll() {
		MainGameManager.Instance.UnlockAllEvent();
		MainGameManager.Instance.UnlockAllScene();
	}

	[Test]
	public void ResetAll() {
		MainGameManager.Instance.ResetData();
	}

	[Test]
	public void ShowCollectionView() {
		//SetSampleData();
		Debug.Log("UnlockList: " + MainGameManager.Instance.saveData.InfoUnlockScene());
		CollectionViewController.Instance.ShowCollectionView();

		CollectionViewController.Instance.collectionView.selectCallback = (int worldID) => {
				CollectionViewController.Instance.ShowTimeEventViewForID(worldID);
			};
		
	}

	[Test]
	public void SetTimeEventView() {
		//timeEventView.SetEventBetween(2, 100);
		timeEventView.SetEventBetween(1941, 1945);
	}

	public float testPercent = 0;
	
	[Test]
	public void TestProgressColor() {
		timeEventView.UpdateProgressColor(testPercent);

		if(testPercent > 1) {
			testPercent = 0;
		} else {
			testPercent += 0.1f;
		}
	}

	[Test]
	public void SetEventList() {
		List<TimeEventData> eventList = MainGameManager.Instance.GetEventBetween(1, 200);

		listView.SetTimeEventList(eventList);
	}

	[Test]
	public void SetEventLocked() {
		eventItemView.SetStatus(false);
		eventItemView.SetYear(1234);
		//eventItemView.SetHeight(80);
	}

	[Test]
	public void SetEventUnLocked() {
		eventItemView.SetStatus(true);
		eventItemView.SetYear(1357);
		eventItemView.SetEvent("A large 9.0 magnitude earthquake in the Indian Ocean creates a huge tsunami that kills over 230,000 people.");
		//eventItemView.SetHeight(160);
	}


	[Test]
	public void SetAsLocked()
	{
		sceneButton.SetAsLocked();
	}

	[Test]
	public void SetAsUnlocked()
	{
		sceneButton.SetAsUnlocked();
	}

	[Test]
	public void SetListViewEmpty() {
		listView.SetContentHeight(0);
	}

	[Test]
	public void SetListViewLong() {
		listView.SetContentHeight(10000);
	}

}
