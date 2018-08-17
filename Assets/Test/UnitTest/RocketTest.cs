using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class RocketTest : BaseTest {
	public Rocket rocket;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		rocket.onStateChanged = (Rocket.State newState) => {
			Debug.Log("RocketState changed=" + newState);
		};
	}

	[Test]
	public void Flying()
	{
		Debug.Log("###### TEST 1 ######");
		rocket.Flying();
	}

	[Test]
	public void Land()
	{
		Debug.Log("###### TEST 2 ######");
		rocket.Landing();
	}
}
