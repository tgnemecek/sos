using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ListGenerator : MonoBehaviour {

	public AudioSource audioOutput;
	public GameObject audioButton;

	//	audioInfo.SetAudioOut (audioOutput);

	public bool isThisAmbience;
	public bool isThisMusic;

	public void MusicListGenerator (){

		if (isThisMusic == true){

		List<MusList> musicList = Database.musList;

		TechniqueScreens techScreen = GameObject.Find ("GameController").GetComponent<TechniqueScreens>();


		foreach (MusList item in musicList) {

				if (techScreen.element == item.element) {
				
					GameObject newButton = (GameObject)Instantiate (audioButton, gameObject.transform);
					newButton.GetComponentInChildren<ButtonAgent> ().itemName = item.name;
					newButton.GetComponentInChildren<Text> ().text = item.name;
				}
			}
		}
	}

	public void AmbListGenerator (){

		if (isThisAmbience == true){
		
		List<AmbList> ambList = Database.ambList;

			foreach (AmbList item in ambList) {

				GameObject newButton = (GameObject)Instantiate (audioButton, gameObject.transform);
				newButton.GetComponentInChildren<ButtonAgent> ().itemName = item.name;
				newButton.GetComponentInChildren<Text> ().text = item.name;
			}
		}
	}
	void Start () {
		MusicListGenerator ();
		AmbListGenerator ();
	}
}
