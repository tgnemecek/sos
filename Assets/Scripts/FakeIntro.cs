using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeIntro : MonoBehaviour {

	// Use this for initialization
	public void Fake () {
		PlayerPrefs.SetString("First Time Intro", "true");
		PlayerPrefs.Save();
		
	}

}
