using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateElementList : MonoBehaviour {

	public int shownCount = 0;

	public string element;
	public GameObject audioButton;
	string key;
	string technique;



	void Start () {


		
		if (SceneManager.GetActiveScene ().name == "Core List") {
			element = "Core";
		}
		if (SceneManager.GetActiveScene ().name == "Vision List") {
			element = "Vision";
		}
		if (SceneManager.GetActiveScene ().name == "Mission List") {
			element = "Mission";
		}
		if (SceneManager.GetActiveScene ().name == "Interactions List") {
			element = "Interactions";
		}
		if (SceneManager.GetActiveScene ().name == "Structure List") {
			element = "Structure";
		}
		if (SceneManager.GetActiveScene ().name == "Synergy List") {
			element = "Synergy";
		}

        List<TechList> techlist = Database.techList;

        foreach (TechList item in techlist)
        {

					if (element == item.element){
						shownCount += 1;
						GameObject newButton = (GameObject)Instantiate (audioButton, gameObject.transform);
						newButton.SendMessage ("SetInfo", item.name);
                        newButton.transform.localScale = new Vector3(1, 1, 1);

                }
		}
	}
}