using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaySingleMusic : MonoBehaviour {

	AudioSource audioS;
	public AudioClip audioClip;
	public string audioClipName;
	public string element;

	public GameObject playpause;
	public Sprite playimg;
	public Sprite pauseimg;

    bool startfadeout = false;

	void Start () {

		element = GameObject.Find ("GameController").GetComponent<TechniqueScreens> ().element;

		audioClipName = GameObject.Find ("GameController").GetComponent<TechniqueScreens> ().technique;
		audioClip = (AudioClip)Resources.Load ("Music/Music_" + element);

		audioS = gameObject.GetComponent<AudioSource> ();
		audioS.clip = audioClip;


	}

	public void Play (){

		if (audioS.isPlaying == true) {
            startfadeout = true;
			playpause.GetComponent<Image> ().sprite = playimg;

		}else{
			if (audioS.isPlaying == false) {
				audioS.Play ();
				playpause.GetComponent<Image> ().sprite = pauseimg;
			}
		}
	}
    void FixedUpdate()
    {
        if (startfadeout == true)
        {
            audioS.volume = audioS.volume - (Time.deltaTime);
            if(audioS.volume == 0)
            {
                startfadeout = false;
                audioS.Pause();
            }
        }
    }


}
