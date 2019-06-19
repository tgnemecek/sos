using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	private IEnumerator coroutine;
	public GameObject skipButton;

	// Use this for initialization
	void Start () {
		coroutine = WaitForAnimation (30.0f);
		StartCoroutine (coroutine);
	}

	IEnumerator WaitForAnimation (float animationLenght){
		yield return new WaitForSeconds (animationLenght);
		SceneManager.LoadScene ("Balance Quiz");
        PlayerPrefs.SetString("First Time Intro", "true");
		PlayerPrefs.Save();
    }

	public void SkipIntro()
	{
		if (PlayerPrefs.GetString ("First Time Intro", "false") == "true") {
			SceneManager.LoadScene ("Technique List");
		} else {
			SceneManager.LoadScene ("Balance Quiz");
			PlayerPrefs.SetString("First Time Intro", "true");
			PlayerPrefs.Save();
		}

	}
}
