using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GoToTechnique : MonoBehaviour {

	private string techname;
	public static string techload;
	private string scene;
	public static string elementload;
	string technique;
	public GameObject newmsg;



	void Start () {

		techname = GetComponentInChildren<Text> ().text.ToString();

		if (SceneManager.GetActiveScene ().name == "Core List") {
			elementload = "Core";
		}
		if (SceneManager.GetActiveScene ().name == "Vision List") {
			elementload = "Vision";
		}
		if (SceneManager.GetActiveScene ().name == "Mission List") {
			elementload = "Mission";
		}
		if (SceneManager.GetActiveScene ().name == "Interactions List") {
			elementload = "Interactions";
		}
		if (SceneManager.GetActiveScene ().name == "Structure List") {
			elementload = "Structure";
		}
		if (SceneManager.GetActiveScene ().name == "Synergy List") {
			elementload = "Synergy";
		}
	}

	public void LoadNext(){
		techload = techname;
		SceneManager.LoadScene ("General Tech Screen");
		if (newmsg.activeInHierarchy == true) {
			PlayerPrefs.SetString ("New Object Unlocked", "null");
			PlayerPrefs.Save();
		}


	}
	public void SetInfo (string info){

		gameObject.GetComponentInChildren<Text> ().text = info;
		gameObject.GetComponent<IsNew> ().techname = info;
	}
}