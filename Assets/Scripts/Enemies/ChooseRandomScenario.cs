using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChooseRandomScenario : MonoBehaviour
{

    [Header("Scenarios")]
    [SerializeField]
    private GameObject[] scenarios;
    [SerializeField]
    private GameObject dummyScenario;

    [Header("Settings")]
    [SerializeField]
    private int timesToRetry;
    [SerializeField]
    private int minNum;
    [SerializeField]
    private bool chooseOnStart;
    [SerializeField]
    private bool isDummyScenario;

    [Header("Random Numbers")]
    [SerializeField]
    private int lastRandNum;
    [SerializeField]
    private int newRandNum;

    private void Start()
    {
        if (chooseOnStart)
        {
            newRandNum = Random.Range(minNum, scenarios.Length);
            scenarios[newRandNum].SetActive(true);
        }
    }

    public void Choose()
    {
        if (isDummyScenario)
        {
            dummyScenario.SetActive(false);
            isDummyScenario = false;
        }
    
        scenarios[lastRandNum].SetActive(false);
        newRandNum = Random.Range(minNum, scenarios.Length);
        int counter = 0;

        while (newRandNum == lastRandNum && counter < timesToRetry)
        {
            newRandNum = Random.Range(0, scenarios.Length);
            counter++;
        }

        scenarios[newRandNum].SetActive(true);

        lastRandNum = newRandNum;
    }
}
