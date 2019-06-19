using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour {


    void Start() {
        StartCoroutine(SplashScreen());
    }

	IEnumerator SplashScreen () {
        yield return new WaitForSeconds(3);

		if (PlayerPrefs.GetString ("First Time Intro", "false") == "false") {
            PlayerPrefs.SetString("Help Enabled", "true");
            SceneManager.LoadScene("Intro");
			PlayerPrefs.Save();

        } else {
            SceneManager.LoadScene("Technique List");
		}
	
	}
}
