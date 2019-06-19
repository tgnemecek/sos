using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

	// Use this for initialization

	private IEnumerator coroutine;

	void Start () {

		coroutine = WaitForLoading (5.0f);
		StartCoroutine(coroutine);
	}

	private IEnumerator WaitForLoading (float waitTime){
		yield return new WaitForSeconds (waitTime);
		SceneManager.LoadScene ("Weekly Summary");
	}
}
