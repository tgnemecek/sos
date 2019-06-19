using UnityEngine;
using System.Collections;

public class ElementAudioSelector : MonoBehaviour {

	public string element;
	public TechniqueScreens techscreenscript;

	void Start () {
		element = techscreenscript.element;

		gameObject.transform.Find (element + "List").gameObject.SetActive (true);
		
	
	}

}
