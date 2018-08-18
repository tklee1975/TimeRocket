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
	public void test2()
	{
		Debug.Log("###### TEST 2 ######");
	}
}
