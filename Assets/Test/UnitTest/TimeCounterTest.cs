using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;
using Kencoder;

public class TimeCounterTest : BaseTest {	
	[Header("Time View")]	
	public int decreaseRate = 10;	// 10 day per seconds
	public GameTime gameTime;
	public TimeCounterUI timeCounterUI;
	


	public bool reduceTime;

	[Header("Fuel View")]
	public FuelView fuelView;
	public float fuel = 100;

	[Header("Booster View")]	
	public BoosterView boosterView;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		gameTime = new GameTime();
		gameTime.SetYearDay(2018, 123);	
		timeCounterUI.gameTime = gameTime;
		timeCounterUI.UpdateTimeGame();

		boosterView.onBoostCallback = () => {
			Debug.Log("On Boost Called. energyLevel=" + boosterView.energyLevel);
		};

		boosterView.onLandCallback = () => {
			Debug.Log("On Land Called");
		};
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(reduceTime) {
			gameTime.ReduceTime(Time.deltaTime * decreaseRate);
			UpdateUI();
		}
	}

	void UpdateUI() {
		timeCounterUI.UpdateTimeGame();
	}

	[Test]
	public void testGameTime()
	{
		GameTime time = new GameTime(2018, 200);

		Debug.Log("Time=" + time.Info());
	}

	[Test]
	public void FuelAsFull()
	{
		fuel = 100;
		fuelView.SetFuel(fuel);
	}

	[Test]
	public void DecreaseFuel()
	{
		fuel -= 10;
		if(fuel < 0) {
			fuel = 0;
		}
		fuelView.SetFuel(fuel);
	}

	[Test]
	public void StartSwing()
	{
		boosterView.StartSwing();
		
	}

	[Test]
	public void StopSwing()
	{
		boosterView.StopSwing();
	}

}
