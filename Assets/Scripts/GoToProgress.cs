using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToProgress : MonoBehaviour {

	public GameObject text;

	public void OnClick()
	{
		if (PlayerPrefs.HasKey ("Progress Gather") && PlayerPrefs.HasKey ("Progress Moods")) {
			SceneManager.LoadScene ("Progress");
		} else {
			text.SetActive (true);
		}
	}

}
