using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Help : MonoBehaviour {

    public GameObject helpParent;
	public string activeScene;

	void Start () {
		if (SceneManager.GetActiveScene ().name == "Core List" || SceneManager.GetActiveScene ().name == "Vision List" || SceneManager.GetActiveScene ().name == "Mission List" || SceneManager.GetActiveScene ().name == "Interactions List" || SceneManager.GetActiveScene ().name == "Structure List" || SceneManager.GetActiveScene ().name == "Synergy List") {
			activeScene = "Element List";
		}
		if (SceneManager.GetActiveScene ().name == "Technique List"){
			activeScene = "Technique List";
		}
		if (SceneManager.GetActiveScene ().name == "General Tech Screen"){
			activeScene = "General Tech Screen";
		}


		if (PlayerPrefs.GetString("Help Enabled") == "true" && PlayerPrefs.GetString(activeScene + " Show Help", "true") == "true")
        {
            helpParent.SetActive(true);
        }
	}

    public void DisableHelp () {
        PlayerPrefs.SetString("Help Enabled", "false");
        helpParent.SetActive(false);
		PlayerPrefs.Save();
    }

    public void EnableHelp()
    {
        PlayerPrefs.SetString("Help Enabled", "true");
		PlayerPrefs.Save();
    }

    public void DismissHelp()
    {
        helpParent.SetActive(false);
		PlayerPrefs.SetString(activeScene + " Show Help", "false");
		PlayerPrefs.Save();
    }
}