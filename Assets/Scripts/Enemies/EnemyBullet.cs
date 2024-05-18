using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private LayerMask whatDestroysBullets;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private float physicsBulletSpeed = 17.5f;
    [SerializeField] private float physicsBulletGravity = 3f;
    [SerializeField] private float physicsBulletDamage = 2f;

    private Rigidbody2D rb;
    private float damage;
    private ObjectPool<EnemyBullet> _pool;

    private Coroutine deactivateBulletAfterTimeCoroutine;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        SetGravity();
    }

    private void OnEnable()
    {
        deactivateBulletAfterTimeCoroutine = StartCoroutine(DeactivateBulletAfterTime());
        SetPhysicsVelocity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((whatDestroysBullets.value & (1 << collision.gameObject.layer)) > 0)
        {
            //damage enemy
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(physicsBulletDamage);
            }

            _pool.Release(this);

        }


    }

    public void SetPool(ObjectPool<EnemyBullet> pool)
    {
        _pool = pool;
    }

    private IEnumerator DeactivateBulletAfterTime()
    {
        float elapsedTime = 0f;
        while (elapsedTime < destroyTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //after timer is over
        _pool.Release(this);
    }

    private void SetPhysicsVelocity()
    {
        rb.velocity = transform.right * physicsBulletSpeed;
    }

    private void SetGravity()
    {
        rb.gravityScale = physicsBulletGravity;
    }
}
