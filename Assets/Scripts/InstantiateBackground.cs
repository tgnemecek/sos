using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBackground : MonoBehaviour
{

    public GameObject background;

    void Awake()
    {
        if (GameObject.Find(background.name + "(Clone)") == null)
        {
            Instantiate(background);
        }
    }
}