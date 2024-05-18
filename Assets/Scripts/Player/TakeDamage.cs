using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health;

    [SerializeField]
    private UnityEvent PlayerDeathEvent;

    [SerializeField]
    private UnityEvent PlayerDamageEvent;


    public void Damage(float damage)
    {
        PlayerDamageEvent.Invoke();
        Death();
    }

    public void InstantDeath()
    {
        Death();
    }

    public void Death()
    {
        if (health <= 0f)
        {
            PlayerDeathEvent.Invoke();
        }
    }
}
