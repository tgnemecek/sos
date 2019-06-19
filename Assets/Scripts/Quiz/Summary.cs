using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Summary : MonoBehaviour {

	// Use this for initialization

	private int pointsEarned = 50;

	private float coreStatus;
	private float visionStatus;
	private float missionStatus;
	private float interactionsStatus;
	private float structureStatus;
	private float synergyStatus;
	private float statusTotal;

	private int coreCount;
	private int visionCount;
	private int missionCount;
	private int interactionsCount;
	private int structureCount;
	private int synergyCount;

	private Text txtCore;
	private Text txtVision;
	private Text txtMission;
	private Text txtInteractions;
	private Text txtStructure;
	private Text txtSynergy;

	private GameObject barCore;
	private GameObject barVision;
	private GameObject barMission;
	private GameObject barInteractions;
	private GameObject barStructure;
	private GameObject barSynergy;

	private float greatSize = 1f;
	private float okSize = 0.75f;
	private float badSize = 0.35f;
	private float urgentSize = 0.1f;

	private int greatY = -31;
	private int okY = -80;
	private int badY = -148;
	private int urgentY = -190;

	//Weekly message:
	public GameObject earnedtxt;


	void Start () {

		if (Balance.showPts == true)
		{
			earnedtxt.SetActive (true);
			Balance.showPts = false;
		}
			


		coreStatus = (float)PlayerPrefs.GetInt ("Core Status", 0);
		visionStatus = (float)PlayerPrefs.GetInt ("Vision Status", 0);
		missionStatus = (float)PlayerPrefs.GetInt ("Mission Status", 0);
		interactionsStatus = (float)PlayerPrefs.GetInt ("Interactions Status", 0);
		structureStatus = (float)PlayerPrefs.GetInt ("Structure Status", 0);
		synergyStatus = (float)PlayerPrefs.GetInt ("Synergy Status", 0);

		statusTotal = coreStatus + visionStatus + missionStatus + interactionsStatus + structureStatus + synergyStatus;

		coreCount = PlayerPrefs.GetInt ("Core Grade", 1);
		visionCount = PlayerPrefs.GetInt ("Vision Grade", 1);
		missionCount = PlayerPrefs.GetInt ("Mission Grade", 1);
		interactionsCount = PlayerPrefs.GetInt ("Interactions Grade", 1);
		structureCount = PlayerPrefs.GetInt ("Structure Grade", 1);
		synergyCount = PlayerPrefs.GetInt ("Synergy Grade", 1);


		txtCore = GameObject.Find ("Core Grade").GetComponent<Text> ();
		txtVision = GameObject.Find ("Vision Grade").GetComponent<Text> ();
		txtMission = GameObject.Find ("Mission Grade").GetComponent<Text> ();
		txtInteractions = GameObject.Find ("Interactions Grade").GetComponent<Text> ();
		txtStructure = GameObject.Find ("Structure Grade").GetComponent<Text> ();
		txtSynergy = GameObject.Find ("Synergy Grade").GetComponent<Text> ();

		barCore = GameObject.Find ("Core Bar");
		barVision = GameObject.Find ("Vision Bar");
		barMission = GameObject.Find ("Mission Bar");
		barInteractions = GameObject.Find ("Interactions Bar");
		barStructure = GameObject.Find ("Structure Bar");
		barSynergy = GameObject.Find ("Synergy Bar");


		//CORE
		if (coreCount == 3) {
			txtCore.text = "Urgent";
			barCore.transform.localScale = new Vector2 (urgentSize, barCore.transform.localScale.y);
			barCore.transform.localPosition = new Vector2 (barCore.transform.localPosition.x, urgentY);
		}
		if (coreCount == 2) {
			txtCore.text = "Weak";
			barCore.transform.localScale = new Vector2 (badSize, barCore.transform.localScale.y);
			barCore.transform.localPosition = new Vector2 (barCore.transform.localPosition.x, badY);
		}
		if (coreCount == 1) {
			txtCore.text = "OK";
			barCore.transform.localScale = new Vector2 (okSize, barCore.transform.localScale.y);
			barCore.transform.localPosition = new Vector2 (barCore.transform.localPosition.x, okY);
		}
		if (coreCount == 0) {
			txtCore.text = "Great";
			barCore.transform.localScale = new Vector2 (greatSize, barCore.transform.localScale.y);
			barCore.transform.localPosition = new Vector2 (barCore.transform.localPosition.x, greatY);
		}


		//VISION
		if (visionCount == 3) {
			txtVision.text = "Urgent";
			barVision.transform.localScale = new Vector2 (urgentSize, barVision.transform.localScale.y);
			barVision.transform.localPosition = new Vector2 (barVision.transform.localPosition.x, urgentY);
		}
		if (visionCount == 2) {
			txtVision.text = "Weak";
			barVision.transform.localScale = new Vector2 (badSize, barVision.transform.localScale.y);
			barVision.transform.localPosition = new Vector2 (barVision.transform.localPosition.x, badY);
		}
		if (visionCount == 1) {
			txtVision.text = "OK";
			barVision.transform.localScale = new Vector2 (okSize, barVision.transform.localScale.y);
			barVision.transform.localPosition = new Vector2 (barVision.transform.localPosition.x, okY);
		}
		if (visionCount == 0) {
			txtVision.text = "Great";
			barVision.transform.localScale = new Vector2 (greatSize, barVision.transform.localScale.y);
			barVision.transform.localPosition = new Vector2 (barVision.transform.localPosition.x, greatY);
		}

		//MISSION
		if (missionCount == 3) {
			txtMission.text = "Urgent";		
			barMission.transform.localScale = new Vector2 (urgentSize, barMission.transform.localScale.y);
			barMission.transform.localPosition = new Vector2 (barMission.transform.localPosition.x, urgentY);
		}
		if (missionCount == 2) {
			txtMission.text = "Weak";
			barMission.transform.localScale = new Vector2 (badSize, barMission.transform.localScale.y);
			barMission.transform.localPosition = new Vector2 (barMission.transform.localPosition.x, badY);
		}
		if (missionCount == 1) {
			txtMission.text = "OK";
			barMission.transform.localScale = new Vector2 (okSize, barMission.transform.localScale.y);
			barMission.transform.localPosition = new Vector2 (barMission.transform.localPosition.x, okY);
		}
		if (missionCount == 0) {
			txtMission.text = "Great";
			barMission.transform.localScale = new Vector2 (greatSize, barMission.transform.localScale.y);
			barMission.transform.localPosition = new Vector2 (barMission.transform.localPosition.x, greatY);
		}

		//INTERACTIONS
		if (interactionsCount == 3) {
			txtInteractions.text = "Urgent";	
			barInteractions.transform.localScale = new Vector2 (urgentSize, barInteractions.transform.localScale.y);
			barInteractions.transform.localPosition = new Vector2 (barInteractions.transform.localPosition.x, urgentY);
		}
		if (interactionsCount == 2) {
			txtInteractions.text = "Weak";
			barInteractions.transform.localScale = new Vector2 (badSize, barInteractions.transform.localScale.y);
			barInteractions.transform.localPosition = new Vector2 (barInteractions.transform.localPosition.x, badY);
		}
		if (interactionsCount == 1) {
			txtInteractions.text = "OK";
			barInteractions.transform.localScale = new Vector2 (okSize, barInteractions.transform.localScale.y);
			barInteractions.transform.localPosition = new Vector2 (barInteractions.transform.localPosition.x, okY);
		}
		if (interactionsCount == 0) {
			txtInteractions.text = "Great";
			barInteractions.transform.localScale = new Vector2 (greatSize, barInteractions.transform.localScale.y);
			barInteractions.transform.localPosition = new Vector2 (barInteractions.transform.localPosition.x, greatY);
		}

		//STRUCTURE
		if (structureCount == 3) {
			txtStructure.text = "Urgent";			
			barStructure.transform.localScale = new Vector2 (urgentSize, barStructure.transform.localScale.y);
			barStructure.transform.localPosition = new Vector2 (barStructure.transform.localPosition.x, urgentY);
		}
		if (structureCount == 2) {
			txtStructure.text = "Weak";
			barStructure.transform.localScale = new Vector2 (badSize, barStructure.transform.localScale.y);
			barStructure.transform.localPosition = new Vector2 (barStructure.transform.localPosition.x, badY);
		}
		if (structureCount == 1) {
			txtStructure.text = "OK";
			barStructure.transform.localScale = new Vector2 (okSize, barStructure.transform.localScale.y);
			barStructure.transform.localPosition = new Vector2 (barStructure.transform.localPosition.x, okY);
		}
		if (structureCount == 0) {
			txtStructure.text = "Great";
			barStructure.transform.localScale = new Vector2 (greatSize, barStructure.transform.localScale.y);
			barStructure.transform.localPosition = new Vector2 (barStructure.transform.localPosition.x, greatY);
		}

		//SYNERGY
		if (synergyCount == 3) {
			txtSynergy.text = "Urgent";	
			barSynergy.transform.localScale = new Vector2 (urgentSize, barSynergy.transform.localScale.y);
			barSynergy.transform.localPosition = new Vector2 (barSynergy.transform.localPosition.x, urgentY);
		}
		if (synergyCount == 2) {
			txtSynergy.text = "Weak";
			barSynergy.transform.localScale = new Vector2 (badSize, barSynergy.transform.localScale.y);
			barSynergy.transform.localPosition = new Vector2 (barSynergy.transform.localPosition.x, badY);
		}
		if (synergyCount == 1) {
			txtSynergy.text = "OK";
			barSynergy.transform.localScale = new Vector2 (okSize, barSynergy.transform.localScale.y);
			barSynergy.transform.localPosition = new Vector2 (barSynergy.transform.localPosition.x, okY);
		}
		if (synergyCount == 0) {
			txtSynergy.text = "Great";
			barSynergy.transform.localScale = new Vector2 (greatSize, barSynergy.transform.localScale.y);
			barSynergy.transform.localPosition = new Vector2 (barSynergy.transform.localPosition.x, greatY);
		}
	}
}
