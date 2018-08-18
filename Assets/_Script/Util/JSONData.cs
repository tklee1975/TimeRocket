using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A helper object to generate final JSON 
public abstract class JSONData
{
	public JSONData ()
	{
		
	}

	public abstract void DefineJSON(Dictionary<string, object> outDict);

	// helper for property 
	public void AddInt(Dictionary<string, object> outDict, string key, int value) {
		outDict.Add(key, (System.Int32) value);
	}

	public void AddBool(Dictionary<string, object> outDict, string key, bool value) {
		outDict.Add(key, (System.Boolean) value);
	}

	public void AddLong(Dictionary<string, object> outDict, string key, long value) {
		outDict.Add(key, (System.Int64) value);
	}

	public void AddFloat(Dictionary<string, object> outDict, string key, float value) {
		outDict.Add(key, (System.Double) value);
	}

	public void AddString(Dictionary<string, object> outDict, string key, string value) {
		outDict.Add(key, value);
	}

	public void AddObject(Dictionary<string, object> outDict, string key, object obj) {
		outDict.Add(key, obj);
	}

	public void AddJSONData(Dictionary<string, object> outDict, string key, JSONData obj) {
		outDict.Add(key, obj.ToJSONData());
	}

	public void AddIntList(Dictionary<string, object> outDict, string key, List<int> obj) {
		outDict.Add(key, obj);
	}

	public void AddList(Dictionary<string, object> outDict, string key, List<object> obj) {
		outDict.Add(key, obj);
	}

	// 
	public Dictionary<string, object> ToJSONData()
	{
		Dictionary<string, object> jsonDict = new Dictionary<string, object>();

		DefineJSON(jsonDict);

		return jsonDict;
	}

	public virtual void ParseJSONData(Dictionary<string, object> jsonData) {
		// TO be implemented
	}

	public void ParseJSON(string jsonString) 
	{
		Dictionary<string, object> jsonData = (Dictionary<string, object>) MiniJSON.Json.Deserialize(jsonString);

		ParseJSONData(jsonData);
			
	}

	public string ToJSON() {
		Dictionary<string, object> jsonDict = ToJSONData();
		return MiniJSON.Json.Serialize(jsonDict);
	}

	#region Save/Load 
	public bool SaveToFile(string file) {
		string location = Application.persistentDataPath + "/" + file;

		//Debug.Log("SaveToFile: dest=" + location);
		FileHelper.WriteFile(location, ToJSON());

		return true;		// TODO: ken give a proper return value
	}


	public bool LoadFromFile(string file) {
		string location = Application.persistentDataPath + "/" + file;

		Debug.Log("LoadFromFile: dest=" + location);
		string content = FileHelper.ReadFile(location);

		//Debug.Log("content:\n" + content);

		if(content == null) {
			return false;
		}

		ParseJSON(content);



		return true;
	}

	#endregion 
}

