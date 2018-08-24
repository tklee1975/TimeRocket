using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;
using Kencoder;

public class MainGameManagerTest : BaseTest {		
	[Test]
	public void GetTimeSceneData()
	{
		List<int> testYearList = new List<int>();
		for(int year = 2018; year >= 0; year -= 314) {
			testYearList.Add(year);
		}

		foreach(int year in testYearList) {
			TimeSceneData data = MainGameManager.Instance.GetSceneDataForYear(year);

			Debug.Log("Year=" + year + " Data=" + data);
		}
	}

	[Test]
	public void TestEvent()
	{
		for(int year=1; year <= 2018; year += 2) {
			string eventName = MainGameManager.Instance.GetTimeEventName(year);
			if(eventName != "") {
				Debug.Log("year=" + year + " event=" + eventName);
			}
		}
		for(int year=1938; year<=1944; year++) {
			string eventName = MainGameManager.Instance.GetTimeEventName(year);
			Debug.Log("year=" + year + " event=" + eventName);
		}
	}
}
