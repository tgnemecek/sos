using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeAudioClip : MonoBehaviour {

	public AudioSource speaker;
	public List<AudioClip> listofmus = new List<AudioClip> ();
	public List<AudioClip> listofamb = new List<AudioClip> ();


	void ReceiveTrackName(string name) {
		foreach (AudioClip item in listofmus) {
			if (item.name == name){
				speaker.clip = item;
			}break;
		}
	}
}