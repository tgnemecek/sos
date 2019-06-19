using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetPlayerPrefs : MonoBehaviour {

	public void OnClick(){
		PlayerPrefs.DeleteAll ();
	}


}
