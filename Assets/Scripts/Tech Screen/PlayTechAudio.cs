using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayTechAudio : MonoBehaviour {

	AudioSource audioS;
	public AudioClip audioClip;
	public string audioClipName;
	public string element;

	public GameObject playpause;
	public Sprite playimg;
	public Sprite pauseimg;

	void Start () {

		element = GameObject.Find ("GameController").GetComponent<TechniqueScreens> ().element;

		audioClipName = GameObject.Find ("GameController").GetComponent<TechniqueScreens> ().technique;
		audioClip = (AudioClip)Resources.Load ("Tech/" + audioClipName);

		audioS = gameObject.GetComponent<AudioSource> ();
		audioS.clip = audioClip;


	}

	public void Play (){

		if (audioS.isPlaying == true) {
			audioS.Pause ();
			playpause.GetComponent<Image> ().sprite = playimg;

		}else{
			if (audioS.isPlaying == false) {
				audioS.Play ();
				playpause.GetComponent<Image> ().sprite = pauseimg;
			}
		}
	
	}

}
