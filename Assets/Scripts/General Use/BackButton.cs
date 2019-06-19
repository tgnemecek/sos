using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

	private string levelToLoad;

	public void LoadLevel (string loading){

		levelToLoad = GameObject.Find ("GameController").GetComponent<TechniqueScreens> ().element;

		SceneManager.LoadScene (levelToLoad + " List");
	}
}

