using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActivatedInputField : MonoBehaviour
{
    
    [SerializeField]
    public TMP_InputField mainInputField;


    void Start()
    {
        mainInputField.ActivateInputField();
    }
}
