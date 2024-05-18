using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerEnterBox : MonoBehaviour
{
    [SerializeField] 
    private float instantDeathDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            damageable?.Damage(instantDeathDamage);

            IDisable disable = other.gameObject.GetComponent<IDisable>();
            disable?.Disable();
        }
    }
}
