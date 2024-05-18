using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyShoot : MonoBehaviour
{
    public EnemyBullet bullet;
    public Transform bulletSpawnPoint;

    private EnemyBulletSpawner bulletSpawner;


    private void Start()
    {
        bulletSpawner = GetComponent<EnemyBulletSpawner>();
    }


    public void HandleEnemyGunShooting()
    {
        bulletSpawner._pool.Get();
    }
}
