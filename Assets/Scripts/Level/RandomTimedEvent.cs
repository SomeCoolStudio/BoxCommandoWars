using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomTimedEvent : MonoBehaviour
{
    [Header("Unity Event")]
    [SerializeField]
    private UnityEvent TimerEvent;
    [Header("Timer Settings")]
    [SerializeField]
    private float time;
    [SerializeField]
    private bool reset;
    [Header("Fire Rate Settings")]
    [SerializeField]
    private float fastestFireRate;
    [SerializeField]
    private float slowestFireRate;

    private bool timer = true;
    private float elapsed;

    private void Start()
    {
        time = Random.Range(fastestFireRate, slowestFireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            Timer();
        }
    }

    public void Timer()
    {
        elapsed += Time.deltaTime;

        if (elapsed > time)
        {
            TimerEvent.Invoke();
            timer = false;
            if (reset)
            {
                timer = true;
                elapsed = 0f;
            }
        }
    }
}
