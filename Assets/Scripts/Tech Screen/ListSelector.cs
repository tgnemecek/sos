using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ListSelector : MonoBehaviour {
	public GameObject mainList; //lista do botão, definida no Inspector
	public GameObject otherList; //outra lista, definidas no Inspector

	public void OnListSelect (){

		if (mainList.activeSelf == true) {
			mainList.SetActive (false);
		}else
		if (mainList.activeSelf == false && otherList.activeSelf == false) {
			mainList.SetActive (true);
		}else
		if (mainList.activeSelf == false && otherList.activeSelf == true) {
			otherList.SetActive (false);
			mainList.SetActive (true);
		}
	}
}
