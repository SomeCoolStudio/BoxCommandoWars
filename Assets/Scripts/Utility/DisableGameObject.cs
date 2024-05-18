using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : MonoBehaviour, IDisable
{
    [Header("Object to disable")]
    [SerializeField]
    private GameObject gO;

    public void Disable()
    {
        gO.SetActive(false);
    }
}
