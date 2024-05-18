using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushUpForce : MonoBehaviour
{

    private Rigidbody2D rb;

    [Header("Push Settings")]
    [SerializeField]
    private float pushPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void PushUp()
    {
        rb.velocity = new Vector2(rb.velocity.x, pushPower);
    }
}
