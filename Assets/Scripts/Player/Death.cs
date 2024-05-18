using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    [SerializeField]
    private UnityEvent DeathEvent;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            DeathEvent.Invoke();
        }
    }
}
