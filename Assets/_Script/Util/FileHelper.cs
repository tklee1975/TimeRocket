using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FileHelper 
{
	public static bool SaveObject<T>(string fileName, T obj){
		try {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create (Application.persistentDataPath + "/" + fileName);
			bf.Serialize(file, obj);
			file.Close();

			return true;

		} catch {

			return false;
		}
	}
	public static T LoadObject<T>(string fileName){
		if(File.Exists(Application.persistentDataPath + "/" + fileName)) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Open);
			T data = (T)bf.Deserialize(file);
			file.Close();
			return data;
		}

		return default(T);
	}


	public static void SaveString(string fileName, string content){
		SaveObject(fileName, content);
	}

	public static string LoadString(string fileName){
		return LoadObject<string>(fileName);
	}

	// https://docs.unity3d.com/Manual/StreamingAssets.html
	// https://answers.unity.com/questions/1087159/reading-text-file-on-android.html
	// https://answers.unity.com/questions/1066673/open-a-file-by-path-from-assets-folder-in-android.html
	public static string ReadFileFromAsset(string path) {	// related path to Assets/
		 TextAsset textAsset = Resources.Load<TextAsset>(path);
		 if(textAsset == null) {
			 Debug.Log("ReadFileFromAsset: textAsset is null. path=" + path);
			 return "";
		 }
		 Debug.Log(path + ">>\n" + textAsset);

		 return textAsset.text;
     }
//  }
// 		string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, path);
    
// 		//https://stackoverflow.com/questions/9544737/read-file-from-assets
// 		Debug.Log("Read from file: " + filePath);

// 		return ReadFile(filePath);
// 	}

	public static string ReadFile(string path)		// e.g "Assets/UnitTest/_Resource/test.txt";
	{
		//Read the text from directly from the test.txt file
		try {
			StreamReader reader = new StreamReader(path); 
			string result = reader.ReadToEnd();
			reader.Close();
			return result;
		} 
		catch 
		{
			//Debug.LogError("ReadFile: fail to read to path=" + path);
			return null;
		}
	}

	public static void WriteFile(string path, string content)		// e.g "Assets/UnitTest/_Resource/test.txt";
	{
		try {
			StreamWriter writer = new StreamWriter(path); 
			writer.Write(content);
			writer.Close();
		} catch{	
			Debug.LogError("WriteFile: fail to write to path=" + path);
		}
		 
		
	}
}

