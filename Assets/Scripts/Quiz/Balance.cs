using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Balance : MonoBehaviour {

	public List<string> alpha = new List<string>{"Core", "Vision", "Mission", "Interactions", "Structure", "Synergy"};

	private GameObject core;
	private GameObject vision;
	private GameObject mission;
	private GameObject interactions;
	private GameObject structure;
	private GameObject synergy;

	private int pointsEarned = 30;

	public static TimeSpan timeSinceBalance;
	public static DateTime lastBalance;
	public static bool showPts = false;


	public Toggle toggle1;
	public Toggle toggle2;
	public Toggle toggle3;
	public Toggle toggle4;
	public Toggle toggle5;
	public Toggle toggle6;

	public int coreCount = 0;
	public int visionCount = 0;
	public int missionCount = 0;
	public int interactionsCount = 0;
	public int structureCount = 0;
	public int synergyCount = 0;

	public int numberofAnswers = 0;

	//Progress Charts variables
	private string progressCore;
	private string progressVision;
	private string progressMission;
	private string progressInteractions;
	private string progressStructure;
	private string progressSynergy;
	private string progressDate;

	private string currentCore;
	private string currentVision;
	private string currentMission;
	private string currentInteractions;
	private string currentStructure;
	private string currentSynergy;

	public int totalCount = 0;

	public int coreRelative = 0;
	public int visionRelative = 0;
	public int missionRelative = 0;
	public int interactionsRelative = 0;
	public int structureRelative = 0;
	public int synergyRelative = 0;



	// Use this for initialization
	void Awake () {
		RandomizeElements ();
        PrepareLists();
	}


	void RandomizeElements(){
		for (int i = 0; i < alpha.Count; i++) {
			string temp = alpha[i];
			int randomIndex = UnityEngine.Random.Range(i, alpha.Count);
			alpha[i] = alpha[randomIndex];
			alpha[randomIndex] = temp;
		}
	}

	//Ao apertar 'Next'

	public void CountandShuffle(){

		core = GameObject.Find ("Core");
		vision = GameObject.Find ("Vision");
		mission = GameObject.Find ("Mission");
		interactions = GameObject.Find ("Interactions");
		structure = GameObject.Find ("Structure");
		synergy = GameObject.Find ("Synergy");

		toggle1 = core.GetComponentInChildren<Toggle> ();
		toggle2 = vision.GetComponentInChildren<Toggle> ();
		toggle3 = mission.GetComponentInChildren<Toggle> ();
		toggle4 = interactions.GetComponentInChildren<Toggle> ();
		toggle5 = structure.GetComponentInChildren<Toggle> ();
		toggle6 = synergy.GetComponentInChildren<Toggle> ();


		if (toggle1.isOn == true && numberofAnswers < 3) {
			coreCount += 1;			
		}
		if (toggle2.isOn == true && numberofAnswers < 3) {
			visionCount += 1;			
		}
		if (toggle3.isOn == true && numberofAnswers < 3) {
			missionCount += 1;	
		}
		if (toggle4.isOn == true && numberofAnswers < 3) {
			interactionsCount += 1;		
		}
		if (toggle5.isOn == true && numberofAnswers < 3) {
			structureCount += 1;	
		}
		if (toggle6.isOn == true && numberofAnswers < 3) {
			synergyCount += 1;		
		} 

		//Finalizar quiz e ir para o Summary

		if (numberofAnswers == 2) {

			int totalCount = coreCount + visionCount + missionCount + interactionsCount + structureCount + synergyCount;
			 
			int.TryParse((Mathf.Round (coreCount*200 / totalCount)).ToString(), out coreRelative);
			int.TryParse((Mathf.Round (visionCount*200 / totalCount)).ToString(), out visionRelative);
			int.TryParse((Mathf.Round (missionCount*200 / totalCount)).ToString(), out missionRelative);
			int.TryParse((Mathf.Round (interactionsCount*200 / totalCount)).ToString(), out interactionsRelative);
			int.TryParse((Mathf.Round (structureCount*200 / totalCount)).ToString(), out structureRelative);
			int.TryParse((Mathf.Round (synergyCount*200 / totalCount)).ToString(), out synergyRelative);

			PlayerPrefs.SetInt ("Core Grade", coreCount);
			PlayerPrefs.SetInt ("Vision Grade", visionCount);
			PlayerPrefs.SetInt ("Mission Grade", missionCount);
			PlayerPrefs.SetInt ("Interactions Grade", interactionsCount);
			PlayerPrefs.SetInt ("Structure Grade", structureCount);
			PlayerPrefs.SetInt ("Synergy Grade", synergyCount);

			PlayerPrefs.SetInt("Core Status", 10 + coreRelative);
			PlayerPrefs.SetInt("Vision Status", 10 + visionRelative);
			PlayerPrefs.SetInt("Mission Status", 10 + missionRelative);
			PlayerPrefs.SetInt("Interactions Status", 10 + interactionsRelative);
			PlayerPrefs.SetInt("Structure Status", 10 + structureRelative);
			PlayerPrefs.SetInt("Synergy Status", 10 + synergyRelative);


			SceneManager.LoadScene ("Weekly Balance Animation");

			PlayerPrefs.SetInt("Player Points", PlayerPrefs.GetInt("Player Points") + pointsEarned);
			PlayerPrefs.Save();


			//Aqui acontecem os processos de checar se o quiz foi feito após uma semana e, se confirmado, salvar as infos de progresso
			if (PlayerPrefs.HasKey ("Last Balanced")) {
				lastBalance = System.Convert.ToDateTime (PlayerPrefs.GetString ("Last Balanced"));
			} else {lastBalance = DateTime.Now;}

			timeSinceBalance = (DateTime.Now).Subtract (lastBalance);
			int hourssince = (int)timeSinceBalance.TotalHours;

			if (hourssince >= 167 || PlayerPrefs.GetString("Last Balanced", "null") == "null") { 

				lastBalance = DateTime.Now;
				PlayerPrefs.SetString("Last Balanced", (lastBalance.ToString()));
				showPts = true;

				progressCore = PlayerPrefs.GetString ("Progress Core", "");
				progressVision = PlayerPrefs.GetString ("Progress Vision", "");
				progressMission = PlayerPrefs.GetString ("Progress Mission", "");
				progressInteractions = PlayerPrefs.GetString ("Progress Interactions", "");
				progressStructure = PlayerPrefs.GetString ("Progress Structure", "");
				progressSynergy = PlayerPrefs.GetString ("Progress Synergy", "");
				progressDate = PlayerPrefs.GetString ("Progress Date", "");

				currentCore = PlayerPrefs.GetInt ("Core Status").ToString ();
				currentVision = PlayerPrefs.GetInt ("Vision Status").ToString ();
				currentMission = PlayerPrefs.GetInt ("Mission Status").ToString ();
				currentInteractions = PlayerPrefs.GetInt ("Interactions Status").ToString ();
				currentStructure = PlayerPrefs.GetInt ("Structure Status").ToString ();
				currentSynergy = PlayerPrefs.GetInt ("Synergy Status").ToString ();

				if (PlayerPrefs.HasKey ("Progress Core")) {
					PlayerPrefs.SetString ("Progress Core", progressCore + "_" + currentCore);
					PlayerPrefs.SetString ("Progress Vision", progressVision + "_" + currentVision);
					PlayerPrefs.SetString ("Progress Mission", progressMission + "_" + currentMission);
					PlayerPrefs.SetString ("Progress Interactions", progressInteractions + "_" + currentInteractions);
					PlayerPrefs.SetString ("Progress Structure", progressStructure + "_" + currentStructure);
					PlayerPrefs.SetString ("Progress Synergy", progressSynergy + "_" + currentSynergy);
					PlayerPrefs.SetString ("Progress Date", progressDate + "_" + DateTime.Now.ToString ("MM/dd/yy"));
				} else
				{
					PlayerPrefs.SetString ("Progress Core", currentCore);
					PlayerPrefs.SetString ("Progress Vision", currentVision);
					PlayerPrefs.SetString ("Progress Mission", currentMission);
					PlayerPrefs.SetString ("Progress Interactions", currentInteractions);
					PlayerPrefs.SetString ("Progress Structure", currentStructure);
					PlayerPrefs.SetString ("Progress Synergy", currentSynergy);
					PlayerPrefs.SetString ("Progress Date", DateTime.Now.ToString ("MM/dd/yy"));
				}
				PlayerPrefs.Save();
			}

		}

		//Próxima repetição do quiz
		if (numberofAnswers < 2){
			numberofAnswers += 1;
			toggle1.isOn = false;
			toggle2.isOn = false;
			toggle3.isOn = false;
			toggle4.isOn = false;
			toggle5.isOn = false;
			toggle6.isOn = false;

			RandomizeElements ();

            core.GetComponent<RandomQuestion>().GenerateText();
            vision.GetComponent<RandomQuestion>().GenerateText();
            mission.GetComponent<RandomQuestion>().GenerateText();
            interactions.GetComponent<RandomQuestion>().GenerateText();
            structure.GetComponent<RandomQuestion>().GenerateText();
            synergy.GetComponent<RandomQuestion>().GenerateText();



		}
	}

    public static List<string> coreList = new List<string>();
    public static List<string> visionList = new List<string>();
    public static List<string> missionList = new List<string>();
    public static List<string> interactionsList = new List<string>();
    public static List<string> structureList = new List<string>();
    public static List<string> synergyList = new List<string>();


    void PrepareLists()
    {
        coreList.Add("Detached");
        coreList.Add("Unaware of exterior reality");
        coreList.Add("Self-absorbed");
        coreList.Add("Withdrawn");
        coreList.Add("Take things personally");
        coreList.Add("Low esteem");
        coreList.Add("Low self aware");
        coreList.Add("Overly stressed");
        coreList.Add("Passive");
        coreList.Add("Inward");
        coreList.Add("Monkish");
        coreList.Add("Inconsistent");
        coreList.Add("Weak identity");
        coreList.Add("Worried");

        visionList.Add("Too cerebral");
        visionList.Add("Abstract");
        visionList.Add("Not in touch");
        visionList.Add("Get lost in ideas");
        visionList.Add("Pessimistic");
        visionList.Add("Unimaginative");
        visionList.Add("Negative");
        visionList.Add("Don't plan");
        visionList.Add("Over-analyse");
        visionList.Add("Live in future");
        visionList.Add("Hyper-critical");
        visionList.Add("Slow to move to new ideas");
        visionList.Add("Confused");
        visionList.Add("Uninspired");

        missionList.Add("Workaholic");
        missionList.Add("Too competitive");
        missionList.Add("Have to win");
        missionList.Add("Adrenaline");
        missionList.Add("Unclear goals");
        missionList.Add("Lack of purpose");
        missionList.Add("Little pride");
        missionList.Add("Apathetic");
        missionList.Add("Dominating");
        missionList.Add("Bullying");
        missionList.Add("Angry");
        missionList.Add("Hesitant");
        missionList.Add("Accommodate");
        missionList.Add("Procrastinate");

        interactionsList.Add("Defer to others");
        interactionsList.Add("Overly-accommodating");
        interactionsList.Add("Compliant");
        interactionsList.Add("Too emotional");
        interactionsList.Add("Uninvolved");
        interactionsList.Add("Cold-hearted");
        interactionsList.Add("Intolerant");
        interactionsList.Add("Low social skills");
        interactionsList.Add("Mood swings");
        interactionsList.Add("Creates drama");
        interactionsList.Add("Touchy-feely");
        interactionsList.Add("Self-isolating");
        interactionsList.Add("Rude");
        interactionsList.Add("Pushy");

        structureList.Add("Stick-in-mud");
        structureList.Add("Plodding");
        structureList.Add("Bureaucratic");
        structureList.Add("Rigid");
        structureList.Add("Impractical");
        structureList.Add("Inefficient");
        structureList.Add("Flakey");
        structureList.Add("Unrealistic");
        structureList.Add("Don't try new things");
        structureList.Add("Focus on past");
        structureList.Add("Picky");
        structureList.Add("Poor finances");
        structureList.Add("Unpredictable");
        structureList.Add("Poor body care");

        synergyList.Add("Don't see forest for trees");
        synergyList.Add("Always focus on big picture");
        synergyList.Add("Don't tend to specifics");
        synergyList.Add("Magical thinking");
        synergyList.Add("Easily thrown off-balance");
        synergyList.Add("Blame others");
        synergyList.Add("Dump problems");
        synergyList.Add("Lack vitality");
        synergyList.Add("Laziness");
        synergyList.Add("Don't accept reality");
        synergyList.Add("Don't tend to details");
        synergyList.Add("Efforts dissipate");
        synergyList.Add("Work too hard for results");
        synergyList.Add("Can't see forest for trees");

    }
}
