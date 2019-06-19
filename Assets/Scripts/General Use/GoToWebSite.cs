using UnityEngine;
using System.Collections;

public class GoToWebSite : MonoBehaviour {

	public void OpenSite (string site){
		Application.OpenURL(site);
	}

}
