using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if (collision.gameObject.TryGetComponent(out player))
        {
            player.ApplyDamage(damage);
        }
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public override bool Equals(object other)
    {
        Enemy otherEnemy = other as Enemy;
        if (otherEnemy == null)
            return false;
        return otherEnemy.damage == damage;
        
    }
}
