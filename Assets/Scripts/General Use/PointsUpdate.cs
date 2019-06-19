using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsUpdate : MonoBehaviour {

	private int playerPoints;
	GameObject pointsDisplay;

	// Update is called once per frame
	void Update () {

		playerPoints = PlayerPrefs.GetInt ("Player Points");
		pointsDisplay = gameObject.transform.Find ("Points Display Text").gameObject;
		pointsDisplay.GetComponent<Text> ().text = playerPoints.ToString ();

	}
}
