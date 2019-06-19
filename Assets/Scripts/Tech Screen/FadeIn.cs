using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	AudioSource audioS;

	void Start (){
		audioS = gameObject.GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (audioS.isPlaying == true && audioS.volume < 0.4f) {
			audioS.volume = audioS.volume + (Time.deltaTime / 3);		
		}
	}
}
