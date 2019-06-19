using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleCount : MonoBehaviour {

	public Toggle toggle;

	public static int counting;

	void Awake () {
		counting = 0;
	}

	public void Count(){

		toggle = gameObject.GetComponent<Toggle> ();
			
		if (toggle.isOn == true) {
			counting += 1;		
		}
		if (toggle.isOn == false) {
			counting -= 1;		
		}
	
	}

}
