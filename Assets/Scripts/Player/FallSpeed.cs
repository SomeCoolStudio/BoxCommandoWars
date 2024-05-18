using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpeed : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField] 
    private float baseGravity;

    [SerializeField]
    private float fallSpeed;

    [SerializeField]
    private float maxFallSpeed;


    void Update()
    {
        Gravity();
    }   

    private void Gravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeed;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }
        else 
        {
            rb.gravityScale = baseGravity;
        }
    }
}
