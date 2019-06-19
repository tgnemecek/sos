using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YouEarnedPointsTXT : MonoBehaviour
{

    private int pointsEarned = 50;

    // Use this for initialization
    void Start()
    {

        gameObject.GetComponent<Text>().text = pointsEarned + " Energy Points";

    }
}
	
