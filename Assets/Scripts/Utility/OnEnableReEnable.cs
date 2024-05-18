using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableReEnable : MonoBehaviour
{

    [SerializeField]
    private GameObject[] gObjects;

    private void OnEnable()
    {
        foreach (GameObject gO in gObjects) 
        {
            gO.SetActive(true); 
        }
    }
}
