using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
//using UnityEditor;

public class ButtonAgent : MonoBehaviour {

	public AudioSource audioOutput; //definido via script

	public AudioClip buttonTrack; //pode ser definido no Inspector, mas é automaticamente definido no runtime

	public string itemName;

	public GameObject playimg;


	public void OnUserClick(){

		buttonTrack = (AudioClip)Resources.Load(itemName);

		audioOutput = GetComponentInParent<ListGenerator> ().audioOutput;

		audioOutput.clip = buttonTrack;

		if (audioOutput.isPlaying == false) {
			audioOutput.Play ();
		} else {
			audioOutput.Stop ();
		}
	}
}