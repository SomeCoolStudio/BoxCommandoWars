using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBulletSpawner : MonoBehaviour
{
    public ObjectPool<EnemyBullet> _pool;

    private EnemyShoot enemyShoot;


    private void Start()
    {
        enemyShoot = GetComponent<EnemyShoot>();
        _pool = new ObjectPool<EnemyBullet>(CreateBullet, OnTakeBulletFromPool, OnReturnBulletToPool, OnDestroyBullet, true, 50, 100);
    }

    private EnemyBullet CreateBullet()
    {
        //spawn new instance of the bullet
        EnemyBullet bullet = Instantiate(enemyShoot.bullet, enemyShoot.bulletSpawnPoint.position, enemyShoot.gameObject.transform.rotation);

        //assign the bullet's pool
        bullet.SetPool(_pool);

        return bullet;
    }

    //what we want to do when we take an object from the pool
    private void OnTakeBulletFromPool(EnemyBullet bullet)
    {
        //set the transform and rotation
        bullet.transform.position = enemyShoot.bulletSpawnPoint.position;
        bullet.transform.right = enemyShoot.gameObject.transform.right;
        //activate
        bullet.gameObject.SetActive(true);
    }

    //what we want to do when we return an object to the pool
    private void OnReturnBulletToPool(EnemyBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    //what we want to do when we want to destroy an object instead of returning to the pool
    private void OnDestroyBullet(EnemyBullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
