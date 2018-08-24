using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{
	public class WorldModel : MonoBehaviour {
		public Vector3 subjectPosition = new Vector3(0, -1.5f, -5);

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void SetWorldForID(int worldID) {
			TimeSceneData data = MainGameManager.Instance.GetSceneDataForID(worldID);
			if(data != null) {
				Debug.Log("SetWorld: building=" + data.building + " sub=" + data.subject);
				SetWorld(data.building, data.subject);
			}
		}

		public void SetWorldForYear(int year) {
			TimeSceneData data = MainGameManager.Instance.GetSceneDataForYear(year);
			if(data != null) {
				Debug.Log("SetWorld: building=" + data.building + " sub=" + data.subject);
				SetWorld(data.building, data.subject);
			}
		}

		public void SetWorld(string building, string subjects = "") {
			UpdateBuilding(building);
			UpdateSubjects(subjects);
		}

		public void UpdateBuilding(string name) {
			GameObject newBuildingPrefab = LoadBuildingPrefab(name);
			if(newBuildingPrefab == null) {
				Debug.Log("UpdateBuilding: no prefab. name=" + name);
				return;
			}

			string modelName = "building";

			Transform current = transform.Find(modelName);
			if(current != null) {
				GameObject.Destroy(current.gameObject);
			}

			// Add child 
			GameObject newModel = GameObject.Instantiate(newBuildingPrefab);
			newModel.name = modelName;
			Transform tf = newModel.transform;

			tf.SetParent(transform, false);
			tf.localPosition = Vector3.zero;
			newModel.SetActive(true);
		}

		public GameObject LoadBuildingPrefab(string name) {
			string path = "Prefab/Scene/building/building_" + name;

			return Resources.Load(path, typeof(GameObject)) as GameObject;
		}


		public void UpdateSubjects(string name) {
			string modelName = "subjects";

			Transform current = transform.Find(modelName);
			if(current != null) {
				GameObject.Destroy(current.gameObject);
			}

			if(name == "") {
				return;
			}

			GameObject newPrefab = LoadSubjectPrefab(name);
			if(newPrefab == null) {
				Debug.Log("UpdateSubjects: no prefab. name=" + name);
				return;
			}		

			// Add child 
			GameObject newModel = GameObject.Instantiate(newPrefab);
			
			newModel.name = modelName;
			Transform tf = newModel.transform;

			tf.SetParent(transform, false);
			tf.localPosition = subjectPosition;
			newModel.SetActive(true);
		}


		public GameObject LoadSubjectPrefab(string name) {
			string path = "Prefab/Scene/subjects/subjects_" + name;

			return Resources.Load(path, typeof(GameObject)) as GameObject;
		}
	}
}