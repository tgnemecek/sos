using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IsNew : MonoBehaviour {

	public string techname;
	public GameObject newMessage;

	void Start () {

		if (PlayerPrefs.GetString("New Object Unlocked", "null") == techname)
		{
			newMessage.SetActive (true);
		}
	}
}