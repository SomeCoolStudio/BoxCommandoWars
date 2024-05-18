using UnityEngine;
using UnityEngine.Events;

public class DyingEventOnTriggerEnter : MonoBehaviour
{
    [SerializeField]
    private UnityEvent DyingEvent;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            DyingEvent.Invoke();
        }
    }
}
