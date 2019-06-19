using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class playaudioToggle : MonoBehaviour {

	public AudioSource techAudio;
	public bool toggle = false;
	GameObject playImg;
	public Sprite play;
	public Sprite pause;

	// Use this for initialization

	void Start(){
		techAudio = GetComponent<AudioSource>();
		playImg = GameObject.Find("playaudioimg");
	}

	public void Toggle (){
		if (GetComponent<Toggle>().isOn == false){
			techAudio.Stop();
			playImg.GetComponent<Image>().sprite = play;
		}
		if (GetComponent<Toggle>().isOn == true){
			techAudio.Play();
			playImg.GetComponent<Image>().sprite = pause;
		}
	}
}
