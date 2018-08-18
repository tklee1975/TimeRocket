using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;
using Kencoder;

public class WorldTest : BaseTest {		
	public WorldModel worldModel;
	public Dropdown buildingDropDown;
	public int testYear = 1234;

	public void ChangeBuilding(int optionIndex) {
		Dropdown.OptionData optionData = buildingDropDown.options[optionIndex];

		string building = optionData.text;
		worldModel.UpdateBuilding(building);
	}

	[Test]
	public void testLaunchArea()
	{
		worldModel.UpdateBuilding("launch_area");
	}

	[Test]
	public void testCity()
	{
		worldModel.UpdateBuilding("city_01");
	}

	[Test]
	public void testPeople()
	{
		worldModel.UpdateSubjects("people_01");
	}

	[Test]
	public void testWar()
	{
		worldModel.UpdateSubjects("war_01");
	}

	[Test]
	public void SetForYear()
	{
		worldModel.SetWorldForYear(testYear);
	}

}
