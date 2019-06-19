using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelString : MonoBehaviour {

	public static string lastLevel;

	public void LoadLevel (string lvlname){
		lastLevel = SceneManager.GetActiveScene ().ToString();
		SceneManager.LoadScene (lvlname);
	
	}
}
