using UnityEngine;
using System.Collections;
using System;

public class PlayerPrefsDebug : MonoBehaviour {

	public GameObject pointsObj;
	public GameObject printpprefs;

//	void Start ()
//	{
//		if (Debug.isDebugBuild)
//			maxPoints.SetActive (true);
//			printpprefs.SetActive (true);
//	}
		
	public void SelectedPoints (int selectedPoints)
	{
		PlayerPrefs.SetInt ("Player Points", selectedPoints);
		PlayerPrefs.Save();
	}


	//Atualizado em 19/01/2017
	public void PrintPlayerPrefs ()
	{

		print ("Lista de Player Prefs atualizada em 19-01-2017\n" +
			
			"\n" +

			"Player Points: " +
			PlayerPrefs.GetInt ("Player Points").ToString () + "\n" +

			"\n" +

			"Core Status: " +
			PlayerPrefs.GetInt ("Core Status").ToString () + "\n" +
			"Vision Status: " +
			PlayerPrefs.GetInt ("Vision Status").ToString () + "\n" +
			"Mission Status: " +
			PlayerPrefs.GetInt ("Mission Status").ToString () + "\n" +
			"Interactions Status: " +
			PlayerPrefs.GetInt ("Interactions Status").ToString () + "\n" +
			"Structure Status: " +
			PlayerPrefs.GetInt ("Structure Status").ToString () + "\n" +
			"Synergy Status: " +
			PlayerPrefs.GetInt ("Synergy Status").ToString () + "\n" +

			"\n" +

			"First Time Intro: " +
			PlayerPrefs.GetString("First Time Intro", "null") + "\n" +
			"Help Enabled: " +
			PlayerPrefs.GetString("Help Enabled", "null") + "\n" +
			"New Object Unlocked: " +
			PlayerPrefs.GetString("New Object Unlocked", "null") + "\n" +
			"Last Balanced: " +
			PlayerPrefs.GetString("Last Balanced", "null") + "\n" +
			"Technique List Show Help: " +
			PlayerPrefs.GetString("Technique List Show Help", "null") + "\n" +
			"Element List Show Help: " +
			PlayerPrefs.GetString("Element List Show Help", "null") + "\n" +
			"General Tech Screen Show Help: " +
			PlayerPrefs.GetString("General Tech Screen Show Help", "null") + "\n" +

			"\n" +

			"Progress Core: " +
			PlayerPrefs.GetString("Progress Core", "null") + "\n" +
			"Progress Vision: " +
			PlayerPrefs.GetString("Progress Vision", "null") + "\n" +
			"Progress Mission: " +
			PlayerPrefs.GetString("Progress Mission", "null") + "\n" +
			"Progress Interactions: " +
			PlayerPrefs.GetString("Progress Interactions", "null") + "\n" +
			"Progress Structure: " +
			PlayerPrefs.GetString("Progress Structure", "null") + "\n" +
			"Progress Synergy: " +
			PlayerPrefs.GetString("Progress Synergy", "null") + "\n" +

			"\n" +

			"Progress Date: " +
			PlayerPrefs.GetString("Progress Date", "null") + "\n" +

			"\n" +

			"Progress Gather: " +
			PlayerPrefs.GetString("Progress Gather", "null") + "\n" +
			"Last Gather: " +
			PlayerPrefs.GetString("Last Gather", "null") + "\n" +
			"Gather Core: " +
			PlayerPrefs.GetString("Gather Core", "null") + "\n" +
			"Gather Vision: " +
			PlayerPrefs.GetString("Gather Vision", "null") + "\n" +
			"Gather Mission: " +
			PlayerPrefs.GetString("Gather Mission", "null") + "\n" +
			"Gather Interactions: " +
			PlayerPrefs.GetString("Gather Interactions", "null") + "\n" +
			"Gather Structure: " +
			PlayerPrefs.GetString("Gather Structure", "null") + "\n" +
			"Gather Synergy: " +
			PlayerPrefs.GetString("Gather Synergy", "null") + "\n" +

			"\n" +

			"Progress Moods: " +
			PlayerPrefs.GetString("Progress Moods", "null") + "\n" +
			"Last Mood: " +
			PlayerPrefs.GetString("Last Mood", "null") + "\n" +
			"Mood Dates: " +
			PlayerPrefs.GetString("Mood Dates", "null") + "\n"
		);
	}

	public void AddDaysToPrefs(){
		PlayerPrefs.SetString("Progress Date", "01/22/17_02/22/17_03/22/17_04/22/17_05/22/17_06/22/17_07/22/17_08/22/17_09/22/17_10/22/17_11/22/17_12/22/17_13/22/17_14/22/17_15/22/17_16/22/17_17/22/17_18/22/17_19/22/17_20/22/17_21/22/17_22/22/17_23/22/17_24/22/17_25/22/17_26/22/17_27/22/17_28/22/17_29/22/17_30/22/17");
		PlayerPrefs.SetString("Progress Core", "10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10");
		PlayerPrefs.SetString("Progress Vision", "10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10");
		PlayerPrefs.SetString("Progress Mission", "10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10");
		PlayerPrefs.SetString("Progress Interactions", "10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10");
		PlayerPrefs.SetString("Progress Structure", "10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10");
		PlayerPrefs.SetString("Progress Synergy", "10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10_10");

        PlayerPrefs.SetString("Gather Date", "01/22/17_02/22/17_03/22/17_04/22/17_05/22/17_06/22/17_07/22/17_08/22/17_09/22/17_10/22/17_11/22/17_12/22/17_13/22/17_14/22/17_15/22/17_16/22/17_17/22/17_18/22/17_19/22/17_20/22/17_21/22/17_22/22/17_23/22/17_24/22/17_25/22/17_26/22/17_27/22/17_28/22/17_29/22/17_30/22/17");
        PlayerPrefs.SetString("Progress Gather", "10_1_20_15_16_9_50_45_51_16_20_30_40_50_60_50_20_10_10_10_15_25_35_45_55_65_10_9_18_17");

        PlayerPrefs.SetString("Mood Dates", "04/22/17_05/22/17_06/22/17_07/22/17_08/22/17_09/22/17_10/22/17_11/22/17_12/22/17_13/22/17_14/22/17_15/22/17_16/22/17_17/22/17_18/22/17_19/22/17_20/22/17_21/22/17_22/22/17_23/22/17_24/22/17_25/22/17_26/22/17_27/22/17_28/22/17_29/22/17_30/22/17");
        PlayerPrefs.SetString("Progress Moods", "1_1_2_1_1_5_5_4_5_1_2_3_4_5_1_5_2_1_1_1_5_2_3_4_5_5_1_2_2_3");

    }
}
