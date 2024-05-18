using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brakes : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;


    public void PumpBrakes()
    {
        rb.velocity = Vector3.zero;
    }
}
