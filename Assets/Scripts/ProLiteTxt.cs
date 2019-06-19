using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProLiteTxt : MonoBehaviour {
	
		void Start () {
		if (LiteProControl.appVersion == "lite") {
			gameObject.GetComponent<Text> ().text = "Lite";
		} else {
			gameObject.GetComponent<Text> ().text = "Pro";
		}
		
	}

}
