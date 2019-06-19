using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsTechniques : MonoBehaviour {

    private string points;

    // Use this for initialization
    void Update () {

		if (gameObject.name == "txtPointsCore")
			points = (PlayerPrefs.GetInt ("Core Status", 0)).ToString ();
		if (gameObject.name == "txtPointsVision")
			points = (PlayerPrefs.GetInt("Vision Status", 0)).ToString ();
        if (gameObject.name == "txtPointsMission")
			points = (PlayerPrefs.GetInt("Mission Status", 0)).ToString ();
        if (gameObject.name == "txtPointsInteractions")
			points = (PlayerPrefs.GetInt("Interactions Status", 0)).ToString ();
        if (gameObject.name == "txtPointsStructure")
			points = (PlayerPrefs.GetInt("Structure Status", 0)).ToString ();
        if (gameObject.name == "txtPointsSynergy")
			points = (PlayerPrefs.GetInt("Synergy Status", 0)).ToString ();


		if (gameObject.name == "txtPoints") {

			points = PlayerPrefs.GetInt (GoToTechnique.elementload + " Status").ToString ();
		}

		gameObject.GetComponent<Text> ().text = points.ToString ();


    }
}
