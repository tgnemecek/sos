using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioTextName : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.GetComponentInChildren<Text> ().text = gameObject.name;
	
	}
}
