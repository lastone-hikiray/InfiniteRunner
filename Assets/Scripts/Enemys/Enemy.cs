using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(damage);
        }
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public bool IsIdentical(Enemy other)
    {
        if (other == null)
            return false;
        return other.damage == damage;
        
    }
}
