using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoving : MonoBehaviour
{

    [SerializeField]
    private MoveForward moveForward;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            moveForward.enabled = true;
        }
    }
}
