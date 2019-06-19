using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Database : MonoBehaviour
{


    public static List<JSONObject> techDB;
    public static List<JSONObject> ambDB;
    public static List<JSONObject> musDB;

    public static List<MusList> musList;
    public static List<AmbList> ambList;
    public static List<TechList> techList;
    public static List<AllList> allList;

    string key;



    void Awake()
    {
            InitialSetup();
    }


    public void InitialSetup()
    {

        techDB = new JSONObject(Resources.Load<TextAsset>("Technique_Database").ToString())["AudioCollection"]["Tracks"].list;
        ambDB = new JSONObject(Resources.Load<TextAsset>("Ambience_Database").ToString())["AudioCollection"]["Tracks"].list;
        musDB = new JSONObject(Resources.Load<TextAsset>("Music_Database").ToString())["AudioCollection"]["Tracks"].list;


        //Creates TechList Static Class

        techList = new List<TechList>();


        foreach (JSONObject item in techDB)
        {
            techList.Add(new TechList(item.list[0].str, item.list[1].str, item.list[2].str, item.list[3].str));
            
        }

        //Creates MusList Static Class

        musList = new List<MusList>();

        foreach (JSONObject item in musDB)
        {
            musList.Add(new MusList(item.list[0].str, item.list[1].str, item.list[2].str));
        }

        //Creates AmbList Static Class

        ambList = new List<AmbList>();

        foreach (JSONObject item in ambDB)
        {
            ambList.Add(new AmbList(item.list[0].str, item.list[1].str));
        }

        //Creates AllList Static Class

        allList = new List<AllList>();

        foreach (TechList item in techList)
        {
			allList.Add(new AllList(item.name, item.points, item.element));
			if (item.points != 0 && (item.points > PlayerPrefs.GetInt("Player Points")))
            {
                PlayerPrefs.SetString(item.name, "locked");
            }
        }
        foreach (AmbList item in ambList)
        {
            allList.Add(new AllList(item.name, item.points, "amb"));
			if (item.points != 0 && (item.points > PlayerPrefs.GetInt("Player Points")))
            {
                PlayerPrefs.SetString(item.name, "locked");
            }
        }
        foreach (MusList item in musList)
        {
            allList.Add(new AllList(item.name, item.points, "mus"));
			if (item.points != 0 && (item.points > PlayerPrefs.GetInt("Player Points")))
            {
                PlayerPrefs.SetString(item.name, "locked");
            }
        }
		PlayerPrefs.Save();
    }
}