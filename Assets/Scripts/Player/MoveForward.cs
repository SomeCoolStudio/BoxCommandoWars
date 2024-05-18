using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField] 
    private float speed;

    [SerializeField]
    private float maxSpeed;


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        rb.velocity = new Vector2(Mathf.Clamp (rb.velocity.x,0, maxSpeed), rb.velocity.y);
    }
}
