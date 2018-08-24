using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;
using Kencoder;

public class GameUITest : BaseTest {		
	public FuelView fuelView;
	public int energy = 0;

	[Test]
	public void ShowHomeView()
	{
		GameViewController.Instance.ShowHomeView();
	}

	[Test]
	public void HideAll()
	{
		GameViewController.Instance.HideAll();
	}

	[Test]
	public void ShowLaunchView()
	{
		GameViewController.Instance.ShowLaunchView();
	}

	[Test]
	public void ShowRocketView()
	{
		GameViewController.Instance.ShowRocketView();
	}

	[Test]
	public void ShowLandingView()
	{
		GameViewController.Instance.ShowLandingView();
	}

	[Test]
	public void SetEnergy() {
		fuelView.SetEnergy(energy);
	}

}
