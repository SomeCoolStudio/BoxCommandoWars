using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableEvent : MonoBehaviour
{

    [Header("Unity Event")]
    [SerializeField]
    private UnityEvent EnableEvent;

    private void OnEnable()
    {
        EnableEvent.Invoke();
    }
}
