using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class waitForDone : MonoBehaviour {

	private int scoreBefore;
	public int pointsGained;
	private string element;
	private int waitTime = 5;
	private Animation lightAnim;
	private Animation medalAnim;
	private ParticleSystem particle;
	public AudioSource audioS;

	// Use this for initialization
	void Start () {
		element = GameObject.Find ("GameController").GetComponent<TechniqueScreens> ().element;
		gameObject.GetComponent<Button>().interactable = false;
		lightAnim =	GameObject.Find ("Done Light").GetComponent<Animation> ();
		medalAnim = GameObject.Find ("Medal").GetComponent<Animation> ();
		particle = GetComponentInChildren<ParticleSystem> ();
		StartCoroutine (Wait ());

	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(waitTime);
		gameObject.GetComponent<Button>().interactable = true;
		lightAnim.Play ();

	}

    public void Done()
    {



        scoreBefore = PlayerPrefs.GetInt("Player Points");

        if (element == "Core")
        {
            pointsGained = PlayerPrefs.GetInt("Core Status");
            particle.startColor = new Color(1f, 1f, 0);
        }
        if (element == "Vision")
        {
            pointsGained = PlayerPrefs.GetInt("Vision Status");
            particle.startColor = new Color(0, 0, 0.7f);
        }
        if (element == "Mission")
        {
            pointsGained = PlayerPrefs.GetInt("Mission Status");
            particle.startColor = new Color(1f, 0, 0);
        }
        if (element == "Interactions")
        {
            pointsGained = PlayerPrefs.GetInt("Interactions Status");
            particle.startColor = new Color(0, 0.95f, 1f);
        }
        if (element == "Structure")
        {
            pointsGained = PlayerPrefs.GetInt("Structure Status");
            particle.startColor = new Color(0.89f, 0.67f, 0);
        }
        if (element == "Synergy")
        {
            pointsGained = PlayerPrefs.GetInt("Synergy Status");
            particle.startColor = new Color(1f, 1f, 1f);
        }

        //Salva progresso no Player Prefs
        string prevProgress = PlayerPrefs.GetString("Progress Gather", "null");
        string elementProgress = PlayerPrefs.GetString("Gather " + element, "null");
        string lastGather = PlayerPrefs.GetString("Last Gather", "null");
        string progressDate = PlayerPrefs.GetString("Progress Date", "");


        if (lastGather != DateTime.Today.Date.ToString())
        {
            if (prevProgress != "null")
            {
                PlayerPrefs.SetString("Progress Gather", prevProgress + "_" + pointsGained);
                PlayerPrefs.SetString("Last Gather", DateTime.Today.Date.ToString());
                PlayerPrefs.SetString("Gather Date", progressDate + "_" + DateTime.Now.ToString("MM/dd/yy"));

            }
            else
            {
                PlayerPrefs.SetString("Progress Gather", pointsGained.ToString());
                PlayerPrefs.SetString("Last Gather", DateTime.Today.Date.ToString());
                PlayerPrefs.SetString("Gather Date", DateTime.Now.ToString("MM/dd/yy"));

            }
        }


        if (elementProgress != "null")
        {
            PlayerPrefs.SetString("Gather " + element, elementProgress + "_" + pointsGained);
        }
        else
        {
            PlayerPrefs.SetString("Gather " + element, pointsGained.ToString());
        }

        PlayerPrefs.SetInt("Player Points", (scoreBefore + pointsGained));
        PlayerPrefs.Save();

        GameObject.Find("Medal Text").GetComponent<Text>().text = "+" + pointsGained.ToString();

        medalAnim.Play();
        lightAnim["donelight"].speed = -0.4f;
        lightAnim["donelight"].time = lightAnim["donelight"].length;
        lightAnim.Play();
        particle.Play();
        audioS.Play();
        gameObject.GetComponent<Button>().interactable = false;
    }
}