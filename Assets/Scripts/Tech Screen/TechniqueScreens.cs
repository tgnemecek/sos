using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TechniqueScreens : MonoBehaviour {

	// Use this for initialization
	//public static string element;

	public string element;
	public string technique;

	public Text txtTitle;
	public Text instructions;
	public Text txtPoints;
	public int points;

	public MeshRenderer bkg;


	void Awake (){


		txtTitle = GameObject.Find ("Title").GetComponent<Text> ();
		instructions = GameObject.Find ("txtInstructions").GetComponent<Text> ();
		txtPoints = GameObject.Find ("txtPoints").GetComponent<Text> ();
		bkg = GameObject.Find ("Bkg").GetComponent<MeshRenderer> ();

		technique = GoToTechnique.techload;
		if (technique == null) {
			technique = "Breath A Smile In";
		}


		element = GoToTechnique.elementload;
		if (element == null) {
			element = "Core";
		}


		//determinados pelo nome da técnica

		txtTitle.text = technique;


        foreach (TechList item in Database.techList)
        {

            if (technique == item.name) {
                instructions.text = item.description;
                break;
        }
    }
		if (element == ("Core")){
			points = (PlayerPrefs.GetInt ("Core Status"));
			bkg.material.color = new Color32 (178, 178, 80, 255);
		}

		if (element == ("Interactions")){
			points = (PlayerPrefs.GetInt ("Interactions Status"));
			bkg.material.color = new Color32 (102, 157, 159, 255);
		}

		if (element == ("Mission")){
			points = (PlayerPrefs.GetInt ("Mission Status"));
			bkg.material.color = new Color32 (159, 54, 54, 255);
		}

		if (element == ("Structure")){
			points = (PlayerPrefs.GetInt ("Structure Status"));
			bkg.material.color = new Color32 (144, 113, 14, 255);
		}
	
		if (element == ("Synergy")){
			points = (PlayerPrefs.GetInt ("Synergy Status"));
			bkg.material.color = new Color32 (116, 116, 116, 255);
		}

		if (element == ("Vision")){
			points = (PlayerPrefs.GetInt ("Vision Status"));
			bkg.material.color = new Color32 (62, 62, 141, 255);
		}
	}
}