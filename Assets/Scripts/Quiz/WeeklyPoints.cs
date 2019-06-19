using UnityEngine;
using System.Collections;

public class WeeklyPoints : MonoBehaviour {
	
	public GameObject earnedtxt;

	void Start () {

		if (Balance.showPts == true)
		{
			earnedtxt.SetActive (true);
			Balance.showPts = false;
		}
	}
}