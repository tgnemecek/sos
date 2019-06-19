using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuizButton : MonoBehaviour {

	public Button button;

	void Start () {
		button = gameObject.GetComponent<Button> ();
	}


	void Update () {
		if (ToggleCount.counting >= 1) {
			button.interactable = true;
		}
		if (ToggleCount.counting == 0) {
			button.interactable = false;
		}
	}
}