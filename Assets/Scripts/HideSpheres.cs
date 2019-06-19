using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpheres : MonoBehaviour {

    public GameObject trigger1;
    public GameObject trigger2;


    void Update () {
        if (trigger1.activeInHierarchy == true || trigger2.activeInHierarchy == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

	}
}
