using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionText : MonoBehaviour {
	public string version = "0.5";
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Text text = GetComponent<Text>();
		if(text != null) {
			text.text = "VERSION: " + version;	// Application.version;
		}
	}

}
