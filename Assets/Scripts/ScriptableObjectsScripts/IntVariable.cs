using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntVariable", menuName = "ScriptableObjects/Int")]
public class IntVariable : ScriptableObject
{
    public int Value;

    public void SetValue(int value)
    {
        Value = value;
    }

    public void SetValue(IntVariable value)
    {
        Value = value.Value;
    }
}

