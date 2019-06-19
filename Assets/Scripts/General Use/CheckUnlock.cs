using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public static class CheckUnlock {

    public static List<AllList> contentlist = Database.allList;
	public static List<TechList> techlist = Database.techList;
	public static List<MusList> muslist = Database.musList;
	public static bool somethingToUnlock;
	public static string unlockedItem;
	public static string unlockedItemType;

	public static void LookForUnlock(){

		somethingToUnlock = false;

	int playerPoints;



		playerPoints = PlayerPrefs.GetInt ("Player Points");

		if (LiteProControl.appVersion == "lite") {
			foreach (AllList item in contentlist) {
				if (item.points <= playerPoints && PlayerPrefs.GetString (item.name) == "locked") {
					unlockedItem = item.name;
					unlockedItemType = item.type;
					somethingToUnlock = true;
					PlayerPrefs.SetString (item.name, "new");
					PlayerPrefs.Save ();
				}
			}
		}
	}
}
