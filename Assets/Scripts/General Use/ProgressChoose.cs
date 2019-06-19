using UnityEngine;
using System.Collections;

public class ProgressChoose : MonoBehaviour {

	public GameObject tabsParent;
	private GameObject topTab;
	private GameObject otherTab1;
	private GameObject otherTab2;
	private GameObject topChart;
	private GameObject otherChart1;
	private GameObject otherChart2;

	void Update () {

		topTab = tabsParent.transform.GetChild (2).gameObject;
		topChart = topTab.transform.GetChild (0).gameObject;

		topChart.SetActive (true);

		otherTab1 = tabsParent.transform.GetChild (0).gameObject;
		otherTab2 = tabsParent.transform.GetChild (1).gameObject;

		otherChart1 = otherTab1.transform.GetChild (0).gameObject;
		otherChart2 = otherTab2.transform.GetChild (0).gameObject;

		otherChart1.SetActive (false);
		otherChart2.SetActive (false);
	
	}
}
