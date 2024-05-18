using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReadyNextScenario : MonoBehaviour
{
    [SerializeField]
    private UnityEvent ReachedValue;

    [SerializeField]
    private int counter;

    [SerializeField]
    private int value;

    public void IncrementCounter()
    { 
        counter++;

        if (counter >= value)
        {
            ReachedValue.Invoke();
            counter = 0;
        }
    }
}
