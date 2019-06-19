using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHelp : MonoBehaviour {

	public GameObject confirmObj;

	public void OnClick()
	{
		confirmObj.SetActive (true);
		PlayerPrefs.SetString("Help Enabled", "true");
		PlayerPrefs.SetString("Technique List Show Help", "true");
		PlayerPrefs.SetString("Element List Show Help", "true");
		PlayerPrefs.SetString("General Tech Screen Show Help", "true");
		PlayerPrefs.Save();
	}
}