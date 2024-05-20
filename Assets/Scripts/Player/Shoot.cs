using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    [Header("Unity Events")]
    [SerializeField]
    private UnityEvent ShootEvent;
    [SerializeField]
    private UnityEvent BulletSpawnedEvent;
    [SerializeField]
    private UnityEvent ShootStopEvent;

    [Header("Shoot Settings")]
    [SerializeField]
    private float fireRate;

    public Bullet bullet;
    public Transform bulletSpawnPoint;

    private BulletSpawner bulletSpawner;

    private Coroutine fireCoroutine;
    private WaitForSeconds fireWait;

    private void Awake()
    {
        fireWait = new WaitForSeconds (1 / fireRate);
    }

    private void Start()
    {
        bulletSpawner = GetComponent<BulletSpawner>();
    }

    public void HandleGunShooting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ShootEvent.Invoke();
            fireCoroutine = StartCoroutine(RapidFire());
        }

        if (context.canceled) 
        {
            ShootStopEvent.Invoke();
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator RapidFire()
    {
        while (true) 
        {
            BulletSpawnedEvent.Invoke();
            bulletSpawner._pool.Get();
            yield return fireWait;
        }
    }
}
