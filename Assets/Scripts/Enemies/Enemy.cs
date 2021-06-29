using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [field : SerializeField] public EnemyRase rase { get; private set;}
    [SerializeField] private int damage;

    public event UnityAction<Enemy> Died;
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
        Died?.Invoke(this);
    }
    public bool Equals(Enemy other)
    {
        if (other == null)
            return false;
        return other.rase == rase;
        
    }
}


