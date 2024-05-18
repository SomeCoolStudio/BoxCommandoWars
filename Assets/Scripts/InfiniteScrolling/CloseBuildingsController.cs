using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBuildingsController : MonoBehaviour
{


    [Header("Dependencies")]
    [SerializeField]
    private GameObject cam;

    [Header("Parallax Settings")]
    [SerializeField]
    private float parallaxEffect; // The speed at which the background should move relative to the camera

    private float startPos, length;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect; // 0 = move with cam || 1 = won't move || 0.5 = half
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        // If background has reached the end of its length, adjust its position for infinite scrolling
        if (movement > startPos + length)
        {
            startPos += length * 2;
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
