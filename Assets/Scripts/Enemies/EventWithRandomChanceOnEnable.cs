using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventWithRandomChanceOnEnable : MonoBehaviour
{
    [SerializeField]
    private UnityEvent RandomChanceEvent;

    [SerializeField]
    private int maxRange;

    [SerializeField]
    private int targetValue;


    private void OnEnable()
    {
        int randNum = Random.Range(0, maxRange);

        if (randNum == targetValue)
        {
            RandomChanceEvent.Invoke();
        }
    }
}
