using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JSONHelper
{
	#region Helper method 
	public static bool isDict(System.Type t)
	{
		return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>);
	}

	public static bool isList(System.Type t)
	{
		return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>);
	}

	public static int objectToInt(object obj) {
		return System.Convert.ToInt32(obj);
	}

	#endregion

	#region JSON String Information

	public static string infoJSONObject(object jsonObject) {
		if(isDict(jsonObject.GetType())){
			return infoJSONDict((Dictionary<string, object>) jsonObject);
		} else if(isList(jsonObject.GetType())){
			return infoJSONList((List<object>) jsonObject);
		} else {
			return jsonObject.ToString();
		}
	}

	public static string infoJSONList(List<object> list) {
		string info = "[";

		bool needComma = false;
		foreach(object obj in list) {
			if(needComma) {
				info += ", ";
			}

			info += infoJSONObject(obj);

			needComma = true;
		}

		info += "]\n";

		return info;
	}

	public static string infoJSONDict(Dictionary<string, object> dict) {

		string info = "{";

		foreach(string key in dict.Keys) {
			info += key;
			info += ": ";

			object obj = dict[key];
			info += infoJSONObject(obj);

			info += "\n";
		}

		info += "}\n";


		return info;
	}

	#endregion
	public static Dictionary<string, object> GetJSONDict(Dictionary<string, object> dict, string name) 
	{
		if(dict.ContainsKey(name) == false) {
			return null;
		}

		return (Dictionary<string, object>) dict[name];
	}

	public static int GetInt(Dictionary<string, object> dict, string name, int defaultValue = 0)
	{
		if(dict.ContainsKey(name) == false) {
			return defaultValue;
		}
		object obj = dict[name];

		//Debug.Log("DEBUG: GetInt: type=" + obj.GetType());
		return System.Convert.ToInt32(obj);
		//return ((System.Int64) obj);
	}


	public static float GetFloat(Dictionary<string, object> dict, string name, float defaultValue = 0.0f)
	{
		if(dict.ContainsKey(name) == false) {
			return defaultValue;
		}
		object obj = dict[name];
		return (float) System.Convert.ToDouble(obj);
	}


	public static long GetLong(Dictionary<string, object> dict, string name, long defaultValue = 0)
	{
		if(dict.ContainsKey(name) == false) {
			return defaultValue;
		}

		object obj = dict[name];
		return (long) System.Convert.ToInt64(obj);
	}

	public static System.DateTime GetDateTime(Dictionary<string, object> dict, string name, 
									System.DateTime defaultTime)
	{
		if(dict.ContainsKey(name) == false) {
			return defaultTime;
		}

		object obj = dict[name];
		long fileTime = (long) System.Convert.ToInt64(obj);
		return System.DateTime.FromFileTime(fileTime);
	}

	public static string GetString(Dictionary<string, object> dict, string name, string defaultValue = "")
	{
		if(dict.ContainsKey(name) == false) {
			return defaultValue;
		}

		return dict[name].ToString();
	}

	public static bool GetBool(Dictionary<string, object> dict, string name, bool defaultValue = false)
	{
		if(dict.ContainsKey(name) == false) {
			return defaultValue;
		}

		object obj = dict[name];
		return System.Convert.ToBoolean(obj);
	}


	public static List<object> GetList(Dictionary<string, object> dict, string name)
	{
		if(dict.ContainsKey(name) == false) {
			return new List<object>();
		}

		return (List<object>) dict[name];
	}

	/*
	public static List<int> GetIntList(Dictionary<string, object> dict, string name)
	{
		if(dict.ContainsKey(name) == false) {
			return new List<int>();
		}

		return (List<int>) dict[name];
	}
*/
//
//	void JSONHelper::getJsonIntArray(const rapidjson::Value &parent, const char *name, std::vector<int> &outArray)
//	{
//		if(parent.HasMember(name) == false) {
//			return;
//		}
//
//		const rapidjson::Value &arrayValue = parent[name];
//
//		if(arrayValue.IsArray() == false) {
//			return;
//		}
//
//		for (rapidjson::SizeType i = 0; i < arrayValue.Size(); i++)
//		{
//			outArray.push_back(arrayValue[i].GetInt());
//		}
//	}
//
//
//
//	void JSONHelper::getJsonStrArray(const rapidjson::Value &parent,
//		const char *name, std::vector<std::string> &outArray,
//		bool allowInt)
//	{
//		if(parent.HasMember(name) == false) {
//			return;
//		}
//
//		const rapidjson::Value &arrayValue = parent[name];
//		if(arrayValue.IsArray() == false) {
//			return;
//		}
//
//		for (rapidjson::SizeType i = 0; i < arrayValue.Size(); i++)
//		{
//
//			std::string str;
//			if(allowInt == false) {
//				str = arrayValue[i].GetString();
//			} else {
//				str = getStringFromStrOrInt(arrayValue[i]);
//			}
//
//			outArray.push_back(str);
//		}
//	}
//
//	void JSONHelper::getJsonFloatArray(const rapidjson::Value &parent, const char *name, std::vector<float> &outArray)
//	{
//		if(parent.HasMember(name) == false) {
//			return;
//		}
//
//		const rapidjson::Value &arrayValue = parent[name];
//		if(arrayValue.IsArray() == false) {
//			return;
//		}
//
//		for (rapidjson::SizeType i = 0; i < arrayValue.Size(); i++)
//		{
//			outArray.push_back((float) arrayValue[i].GetDouble());
//		}
//	}
//
//	void JSONHelper::getJsonStrIntMap(const rapidjson::Value &parent, const std::string &key,
//		std::map<std::string, int> &outMap)
//	{
//		if(parent.HasMember(key.c_str()) == false) {
//			return;
//		}
//
//		const rapidjson::Value &jsonValue = parent[key.c_str()];
//
//		for (rapidjson::Value::ConstMemberIterator itr = jsonValue.MemberBegin();
//			itr != jsonValue.MemberEnd();
//			++itr)
//		{
//			std::string key = itr->name.GetString();
//			const rapidjson::Value &object = jsonValue[key.c_str()];
//			int value = object.GetInt();
//
//			//log("getJsonStrMap: key=%s value=%s", key.c_str(), value.c_str());
//			outMap[key] = value;
//		}
//	}
//
//
//	void JSONHelper::getJsonStrFloatMap(const rapidjson::Value &parent, const std::string &key,
//		std::map<std::string, float> &outMap)
//	{
//		if(parent.HasMember(key.c_str()) == false) {
//			return;
//		}
//
//		const rapidjson::Value &jsonValue = parent[key.c_str()];
//
//		for (rapidjson::Value::ConstMemberIterator itr = jsonValue.MemberBegin();
//			itr != jsonValue.MemberEnd();
//			++itr)
//		{
//			std::string key = itr->name.GetString();
//			const rapidjson::Value &object = jsonValue[key.c_str()];
//			float value = (float) object.GetDouble();
//
//			//log("getJsonStrMap: key=%s value=%s", key.c_str(), value.c_str());
//			outMap[key] = value;
//		}
//	}
//
//
//
//	void JSONHelper::getJsonIntMap(const rapidjson::Value &parent, const std::string &key,
//		std::map<int, int> &outMap)
//	{
//		if(parent.HasMember(key.c_str()) == false) {
//			return;
//		}
//
//		const rapidjson::Value &jsonValue = parent[key.c_str()];
//
//		for (rapidjson::Value::ConstMemberIterator itr = jsonValue.MemberBegin();
//			itr != jsonValue.MemberEnd();
//			++itr)
//		{
//			std::string key = itr->name.GetString();
//			const rapidjson::Value &object = jsonValue[key.c_str()];
//			int value = object.GetInt();
//
//			//log("getJsonStrMap: key=%s value=%s", key.c_str(), value.c_str());
//			int k = StringHelper::parseInt(key);
//			outMap[k] = value;
//		}
//	}



	// helper for property 
	public static void AddInt(Dictionary<string, object> outDict, string key, int value) {
		outDict.Add(key, (System.Int32) value);
	}

	public static void AddBool(Dictionary<string, object> outDict, string key, bool value) {
		outDict.Add(key, (System.Boolean) value);
	}

	public static void AddLong(Dictionary<string, object> outDict, string key, long value) {
		outDict.Add(key, (System.Int64) value);
	}

	public static void AddDateTime(Dictionary<string, object> outDict, string key, System.DateTime value) {
		outDict.Add(key, (System.Int64) value.ToFileTime());
	}

	public static void AddFloat(Dictionary<string, object> outDict, string key, float value) {
		outDict.Add(key, (System.Double) value);
	}

	public static void AddString(Dictionary<string, object> outDict, string key, string value) {
		outDict.Add(key, value);
	}

	public static void AddObject(Dictionary<string, object> outDict, string key, object obj) {
		outDict.Add(key, obj);
	}

	public static void AddJSONData(Dictionary<string, object> outDict, string key, JSONData obj) {
		outDict.Add(key, obj.ToJSONData());
	}

	public static void AddIntList(Dictionary<string, object> outDict, string key, List<int> obj) {
		outDict.Add(key, obj);
	}

	public static void AddList(Dictionary<string, object> outDict, string key, List<object> obj) {
		outDict.Add(key, obj);
	}

}

