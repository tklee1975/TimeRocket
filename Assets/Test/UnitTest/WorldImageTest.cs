using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;
using Kencoder;

public class WorldImageTest : BaseTest {	
	//public string worldInd
	public WorldModel worldModel;
	public RenderTexture renderTexture;
	//public int worldID = 1;
	public TimeSceneData currentData;

	List<int> mGeneratedList = new List<int>();
	protected bool mIsCreating = false;

	public void SaveImage() {	
		//public RenderTexture renderTexture;
		int resWidth = renderTexture.width;
		int resHeight = renderTexture.height;

		Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
		RenderTexture.active = renderTexture;
		screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
		RenderTexture.active = null; // JC: added to avoid errors

		

		string filename = Application.persistentDataPath + "/time_scene_" + currentData.worldID + ".png";

		Debug.Log("Save File: " + filename);

		byte[] bytes = screenShot.EncodeToPNG();
		System.IO.File.WriteAllBytes(filename, bytes);
		
        //      camera.Render();
        //      RenderTexture.active = rt;
        //      screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        //      camera.targetTexture = null;
        //      RenderTexture.active = null; // JC: added to avoid errors
        //      Destroy(rt);
        //      byte[] bytes = screenShot.EncodeToPNG();
        //      string filename = ScreenShotName(resWidth, resHeight);
        //      System.IO.File.WriteAllBytes(filename, bytes);
        //      Debug.Log(string.Format("Took screenshot to: {0}", filename));
        //      takeHiResShot = false;
	}

	void SetWorld(int worldID) {
		currentData = MainGameManager.Instance.GetSceneDataForID(worldID);
		worldModel.SetWorld(currentData.building, currentData.subject);
		Invoke("SaveImage", 1.0f);
	}

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		mGeneratedList.Clear();
 
		foreach(TimeSceneData data in MainGameManager.Instance.timeSceneList) {
			mGeneratedList.Add(data.worldID);
		}

	}


	[Test]
	public void World1()
	{
		SetWorld(1);
	}

	[Test]
	public void World2()
	{
		SetWorld(2);
	}

	[Test]
	public void CreateWorld()
	{	
		if(mGeneratedList.Count == 0) {
			return;
		}

		int worldID = mGeneratedList[0];
		SetWorld(worldID);

		mGeneratedList.RemoveAt(0);
		
	}
}
