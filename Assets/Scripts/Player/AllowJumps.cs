using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowJumps : MonoBehaviour
{

    [Header("Jumping")]
    [SerializeField]
    private int allowedJumps;

    [Header("Dependencies")]
    [SerializeField]
    private IntVariable jumpsLeft;

    private void Start()
    {
        jumpsLeft.SetValue(allowedJumps);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("Ground"))
        {
            jumpsLeft.SetValue(allowedJumps);
        }
    }
}
