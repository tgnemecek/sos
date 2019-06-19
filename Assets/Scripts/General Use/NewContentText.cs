using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NewContentText : MonoBehaviour {

	public GameObject itemnameOBJ;
	public GameObject itemtypeOBJ;
	private string itemnameSTR;
	private string itemtypeSTR;

	void Start () {

		itemnameSTR = CheckUnlock.unlockedItem;
		itemtypeSTR = CheckUnlock.unlockedItemType;

		itemnameOBJ.GetComponent<Text> ().text = itemnameSTR;
		if (itemtypeSTR == "mus") {
			itemtypeOBJ.GetComponent<Text> ().text = "New Music!";
		}
		if (itemtypeSTR != "mus" && itemtypeSTR != "amb") {
			itemtypeOBJ.GetComponent<Text> ().text = itemtypeSTR + " Technique!";
		}
	}
}