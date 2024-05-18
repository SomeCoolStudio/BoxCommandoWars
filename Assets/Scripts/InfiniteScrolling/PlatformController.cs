using UnityEngine;
using UnityEngine.Events;


public class PlatformController : MonoBehaviour
{

    [Header("Unity Event")]
    [SerializeField]
    private UnityEvent PlatformMovingEvent;

    [Header("Dependencies")]
    [SerializeField]
    private GameObject cam;
   
    [Header("Infinite Scrolling Settings")]
    [SerializeField]
    private int moveDistanceMultiplier;

    private float length;


    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
      
        float movement = cam.transform.position.x;

        // If background has reached the end of its length, adjust its position for infinite scrolling
        if (movement > transform.position.x + length)
        {
            transform.position = new Vector2 (length * moveDistanceMultiplier, transform.position.y);
            moveDistanceMultiplier += 2;
            PlatformMovingEvent.Invoke();
        }
       
    }
}
