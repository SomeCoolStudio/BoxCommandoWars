using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    [SerializeField]
    private BoolVariable isGrounded;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground")) 
        {
            isGrounded.SetValue(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded.SetValue(false);
        }
    }


}
