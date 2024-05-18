using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventWithRandomChanceOnTriggerEnter : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnTriggerEnterEvent;

    [SerializeField] 
    private string tagName;

    [SerializeField]
    private int maxRange;

    [SerializeField]
    private int targetValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag(tagName))
        {
            int randNum = Random.Range(0, maxRange);

            if(randNum == targetValue)
            {
                OnTriggerEnterEvent.Invoke();
            }
            
        }
    }
}
