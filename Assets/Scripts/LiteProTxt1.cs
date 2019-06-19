using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiteProTxt1 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (LiteProControl.appVersion == "lite") {
			gameObject.GetComponent<Text> ().text = "Your more problematic elements (determined by your Balance Quiz) are worth more Energy Points, which are used to unlock more techniques.";
		} else {
			gameObject.GetComponent<Text> ().text = "Your more problematic elements (determined by your Balance Quiz) are worth more Energy Points.";
		}
		
	}

}
