using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void SubtractHealth(float damage)
    {
        currentHealth =- damage;
        DeathCheck(currentHealth);

    }

    private void DeathCheck(float health)
    {
        if (health <= 0)
        {
            Destroy(gameObject);

        }

    }
}
