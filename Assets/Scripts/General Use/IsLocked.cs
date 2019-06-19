using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class IsLocked : MonoBehaviour {

	GameObject listlock;
	private int requiredPoints;
	string techname;


	void Start () {

		techname = gameObject.GetComponentInChildren<Text> ().text;

        List<TechList> techlist = Database.techList;

        foreach (TechList item in techlist)
        {
			if (techname == item.name && item.points <= PlayerPrefs.GetInt ("Player Points")) {
					UnLockItself ();
					break;
				}
			else
			{
				if(LiteProControl.appVersion == "pro"){
					UnLockItself ();
				}
			}
		}
	}

	void UnLockItself(){
		gameObject.GetComponent<Button> ().interactable = true;
		listlock = gameObject.transform.Find ("List Lock").gameObject;
		listlock.SetActive (false);
	}
}
