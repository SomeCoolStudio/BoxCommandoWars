using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyingEnemyMove : MonoBehaviour
{
    [SerializeField] 
    private Transform transformBody;
    [SerializeField] 
    private Transform startPosition;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float offset;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float newSpeed;
    [SerializeField]
    private float newMaxSpeed;
    [SerializeField]
    private UnityEvent FlyingEnemyReachedStopPoint;

  
    private void OnEnable()
    {
        transformBody.rotation = Quaternion.Euler(0, 0, 0);
        transformBody.position = new Vector2 (startPosition.position.x - offset, transform.position.y);
        Move();
    }

    private void Move()
    {
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, 0, maxSpeed), rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("FlyingEnemyStopPoint"))
        {
            transformBody.rotation = Quaternion.Euler(0, 180, 0);
            rb.velocity = Vector2.zero;
            rb.AddForce(-transform.right * newSpeed, ForceMode2D.Impulse);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, 0, newMaxSpeed), rb.velocity.y);
            FlyingEnemyReachedStopPoint.Invoke();
        }
    }
}
