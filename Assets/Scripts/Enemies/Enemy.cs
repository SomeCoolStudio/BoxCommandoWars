using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour, IDamageable
{

    [SerializeField] 
    private UnityEvent EnemyDeathEvent;

    [SerializeField]
    private UnityEvent EnemyDamageEvent;

    [SerializeField]
    private float health;

    [SerializeField]
    private float startingHealth;

    [SerializeField]
    private IntVariable score;

    [SerializeField]
    private int scoreAdd;

    private void OnEnable()
    {
        health = startingHealth;
    }

    private void Start()
    {
        health = startingHealth;
    }

    public void Damage(float damage)
    {
        score.Value += scoreAdd;
        health -= damage;
        EnemyDamageEvent.Invoke();
        Death();
    }

    public void Death()
    {
        if (health <= 0f)
        {   
            EnemyDeathEvent.Invoke();
        }
    }
}
