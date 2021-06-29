using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyPool : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>(); 
    public Enemy GetEnemy(Enemy original, Vector3 position, Quaternion rotation)
    {
        if (TryGetUnused(original, out Enemy notUsedEnemy))
        {
            notUsedEnemy.transform.position = position;
            notUsedEnemy.transform.rotation = rotation;
            notUsedEnemy.gameObject.SetActive(true);
            return notUsedEnemy;
        }
        else
        {
            return GetNewEnemy(original, position, rotation);
        }
    }
    private bool TryGetUnused(Enemy reference, out Enemy notUsedEnemy)
    {
        notUsedEnemy = enemies.FirstOrDefault(e => e.gameObject.activeSelf == false && e.IsIdentical(reference));
        return notUsedEnemy != null;
    }
    private Enemy GetNewEnemy(Enemy original, Vector3 position, Quaternion rotation)
    {
        Enemy newEnemy = Instantiate(original, position, rotation);
        enemies.Add(newEnemy);
        return newEnemy;
    }
}
