using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RandomQuestion : MonoBehaviour {

	public string element;
	public Text shownText;
	private int maxRandom;
	public int n;
	public GameObject balance;
	public string slot;

    public List<string> usedList;


	public int firstUsed;
	public int secondUsed;

	public int generateCount;


	// Use this for initialization

	void Start () {
		
		balance = GameObject.Find ("GameController");
		slot = gameObject.name;
        GetElement();
        GenerateText();


	}

    void Update() {
        GetElement();
    }

	public void GetElement(){

		if (slot == "Slot 1") {
			element = balance.GetComponent<Balance> ().alpha [0];		
		}
		if (slot == "Slot 2") {
			element = balance.GetComponent<Balance> ().alpha [1];		
		}
		if (slot == "Slot 3") {
			element = balance.GetComponent<Balance> ().alpha [2];		
		}
		if (slot == "Slot 4") {
			element = balance.GetComponent<Balance> ().alpha [3];		
		}
		if (slot == "Slot 5") {
			element = balance.GetComponent<Balance> ().alpha [4];		
		}
		if (slot == "Slot 6") {
			element = balance.GetComponent<Balance> ().alpha [5];		
		}
		gameObject.name = element;
    }


    public void GenerateText () {

                if(element == "Core"){
            usedList = Balance.coreList;
        }
                if(element == "Vision"){
            usedList = Balance.visionList;
        }
                if(element == "Mission"){
            usedList = Balance.missionList;
        }
                if(element == "Interactions"){
            usedList = Balance.interactionsList;
        }
                if(element == "Structure"){
            usedList = Balance.structureList;
        }
                if(element == "Synergy"){
            usedList = Balance.synergyList;
        }


        int index = Random.Range(0, usedList.Count);
        string chosen = usedList[index].ToString();
        ;
		shownText = gameObject.GetComponent<Text> ();
        shownText.text = chosen;
        usedList.RemoveAt(index);
    
	}
}
