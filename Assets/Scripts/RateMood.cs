using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RateMood : MonoBehaviour {

	string prevMoods;
	string prevDates;
	public static TimeSpan timeSinceMood;
	public static DateTime lastMood;
	public GameObject child;

	int hourssince = 0;

	void Start()
	{
		prevMoods = PlayerPrefs.GetString ("Progress Moods", "null");
		prevDates = PlayerPrefs.GetString ("Mood Dates", "null");

		if (PlayerPrefs.HasKey ("Last Mood")) {
			lastMood = System.Convert.ToDateTime (PlayerPrefs.GetString ("Last Mood"));
			timeSinceMood = (DateTime.Now).Subtract (lastMood);
			hourssince = (int)timeSinceMood.TotalHours;
		}

		if (hourssince >= 24 || PlayerPrefs.GetString("Last Mood", "null") == "null") {
			child.SetActive (true);
		}
	}

	public void Rate (string moodGrade)
	{
		if(PlayerPrefs.GetString("Progress Moods", "null") != "null")
		{
			PlayerPrefs.SetString ("Progress Moods", prevMoods + "_" + moodGrade);
		}
		else
		{
			PlayerPrefs.SetString ("Progress Moods", moodGrade);
		}

		PlayerPrefs.SetString("Last Mood", (DateTime.Now.ToString()));
		child.SetActive (false);

		if (prevDates != "null") {
			PlayerPrefs.SetString ("Mood Dates", prevMoods + "_" + (DateTime.Now.Date.ToString ("MM/dd/yy")));
		}
		else
		{
			PlayerPrefs.SetString ("Mood Dates", (DateTime.Now.Date.ToString ("MM/dd/yy")));
		}
	}
}
