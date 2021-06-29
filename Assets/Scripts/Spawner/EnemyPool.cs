using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyPool : MonoBehaviour
{
    private List<Enemy> unusedEnemies = new List<Enemy>(); 
    
    public Enemy GetEnemy(Enemy original, Vector3 position, Quaternion rotation)
    {
        if (TryGetUnused(original, out Enemy unusedEnemy))
        {
            unusedEnemy.transform.position = position;
            unusedEnemy.transform.rotation = rotation;
            unusedEnemy.gameObject.SetActive(true);
            unusedEnemy.Died += OnEnemyDie;
            return unusedEnemy;
        }
        else
        {
            return GetNewEnemy(original, position, rotation);
        }
    }
    private bool TryGetUnused(Enemy reference, out Enemy unusedEnemy)
    {
        unusedEnemy = unusedEnemies.FirstOrDefault(e => reference.Equals(e));
        bool have = unusedEnemy != null;
        if (have)
        {
            unusedEnemies.Remove(unusedEnemy);
        }
        return have;
    }
    private Enemy GetNewEnemy(Enemy original, Vector3 position, Quaternion rotation)
    {
        Enemy newEnemy = Instantiate(original, position, rotation);
        newEnemy.Died += OnEnemyDie;
        return newEnemy;
    }

    private void OnEnemyDie(Enemy enemy)
    {
        enemy.Died -= OnEnemyDie;
        enemy.gameObject.SetActive(false);
        unusedEnemies.Add(enemy);
    }
}
