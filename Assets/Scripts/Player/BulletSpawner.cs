using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    public ObjectPool<Bullet> _pool;

    private Shoot shoot;


    private void Start()
    {
        shoot = GetComponent<Shoot>();
        _pool = new ObjectPool<Bullet>(CreateBullet, OnTakeBulletFromPool, OnReturnBulletToPool, OnDestroyBullet, true, 100, 200);
    }

    private Bullet CreateBullet()
    {
        //spawn new instance of the bullet
        Bullet bullet = Instantiate(shoot.bullet, shoot.bulletSpawnPoint.position, shoot.gameObject.transform.rotation);

        //assign the bullet's pool
        bullet.SetPool( _pool );

        return bullet;
    }

    //what we want to do when we take an object from the pool
    private void OnTakeBulletFromPool(Bullet bullet)
    {
        //set the transform and rotation
        bullet.transform.position = shoot.bulletSpawnPoint.position;
        bullet.transform.right = shoot.gameObject.transform.right;
        //activate
        bullet.gameObject.SetActive( true );
    }

    //what we want to do when we return an object to the pool
    private void OnReturnBulletToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive( false );
    }

    //what we want to do when we want to destroy an object instead of returning to the pool
    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject); 
    }
}

