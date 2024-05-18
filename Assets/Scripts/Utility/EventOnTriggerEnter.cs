using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTriggerEnter : MonoBehaviour
{
    [Header("Unity Event")]
    [SerializeField]
    private UnityEvent OnTriggerEnterEvent;

    [Header("Target")]
    [SerializeField]
    private string tagName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag(tagName))
        {
            OnTriggerEnterEvent.Invoke();
        }
    }
}
