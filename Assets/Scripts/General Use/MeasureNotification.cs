using UnityEngine;
using System.Collections;
using System;

public class MeasureNotification : MonoBehaviour {

	public static TimeSpan timeSinceNotification;
	private static bool enableNotification;
	public static TimeSpan timeSinceBalance;
	public static DateTime lastBalance;
	public static DateTime lastNotification;

	public GameObject notificationbox;



	void Start () {

		if (PlayerPrefs.HasKey ("Last Balanced"))
		{
			lastBalance = System.Convert.ToDateTime (PlayerPrefs.GetString ("Last Balanced"));
		}

		if (PlayerPrefs.HasKey("Last Notification"))
		{
			lastNotification = System.Convert.ToDateTime (PlayerPrefs.GetString ("Last Notification"));
		}
		else
		{
			lastNotification = DateTime.Now;
		}


		timeSinceBalance = (DateTime.Now).Subtract (lastBalance);
		int hourssince = (int)timeSinceBalance.TotalHours;

		timeSinceNotification = (DateTime.Now).Subtract (lastNotification);
		int hoursinceNotification = (int)timeSinceNotification.TotalHours;

		if (hoursinceNotification >= 3)
		{
			enableNotification = true;
		}

		if (hourssince >= 167 && enableNotification == true) { 	//168 é a qtd de horas em uma semana
			notificationbox.SetActive (true);
			hoursinceNotification = 0;
		}
	}

	public void CloseBox ()
	{
		enableNotification = false;
		notificationbox.SetActive (false);

	}
}
