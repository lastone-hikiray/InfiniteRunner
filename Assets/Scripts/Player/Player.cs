using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private bool Dead;

    private void Start()
    {
        HealthChanged?.Invoke(health);
    }
    public void ApplyDamage(int damage)
    {
        if (Dead)
            return;
        health -= damage;
        health = Math.Max(health, 0);
        HealthChanged?.Invoke(health);
        if (health <= 0)
            Die();
    }
    private void Die()
    {
        Dead = true;
        Died?.Invoke();
    }

}
