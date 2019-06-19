using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PointstoUnlockTech : MonoBehaviour {

	string techname;
	string needed;
	Text textshown;
	GameObject child1;

	// Use this for initialization
	void Start () {

		child1 = gameObject.transform.Find ("List Lock").gameObject;
		textshown = child1.transform.Find ("lock L").GetComponent<Text> ();
		techname = GetComponentInChildren<Text>().text.ToString ();

		List<JSONObject> techlist =  Database.techDB;

		foreach (JSONObject item in techlist) {
			if (item.list [0].str == techname) {
				needed = item.list [1].str;
			}
		}
		textshown.text = needed + "\n EP";
	
	}

}
