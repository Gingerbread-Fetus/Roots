using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealthPoints;
    [HideInInspector]
    public float healthPoints;

    private void Awake()
    {
        healthPoints = maxHealthPoints;
    }
    public void dealDamage(float damage)
    {
        healthPoints -= damage;
        if(healthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
