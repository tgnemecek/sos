using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Progress : MonoBehaviour {


	public GameObject thistab;
	public GameObject othertab1;
	public GameObject othertab2;

	public void TabOrder(){

		thistab.transform.SetAsLastSibling ();

		if (gameObject.name == "Tab3 Holder") {
			othertab1.transform.SetAsFirstSibling ();
		}
		if (gameObject.name == "Tab1 Holder") {
			othertab2.transform.SetAsFirstSibling ();
		}
	}
}