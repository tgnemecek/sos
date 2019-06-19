using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInPro : MonoBehaviour {

	void Awake ()
	{
		if (LiteProControl.appVersion == "pro") {
			gameObject.SetActive(false);
		}
	}
}
