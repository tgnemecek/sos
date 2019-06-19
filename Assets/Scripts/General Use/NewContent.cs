using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewContent : MonoBehaviour {

	public GameObject newcontentmessage;

	void Start ()
	{
		if (SceneManager.GetActiveScene ().ToString () == "Weekly Summary" && LiteProControl.appVersion == "lite") {
			CheckUnlock.LookForUnlock ();
			if (CheckUnlock.somethingToUnlock == true) {
				newcontentmessage.SetActive (true);
				PlayerPrefs.SetString ("New Object Unlocked", CheckUnlock.unlockedItem);
				PlayerPrefs.Save();

			
			}
		}
	}

	 void OnClick () {
		CheckUnlock.LookForUnlock ();
		if (CheckUnlock.somethingToUnlock == true){
			newcontentmessage.SetActive (true);
			PlayerPrefs.SetString ("New Object Unlocked", CheckUnlock.unlockedItem);
			PlayerPrefs.Save();

		}
	}
}