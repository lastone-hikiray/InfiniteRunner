using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyPool : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>(); 
    private bool TryGet(Enemy reference, out Enemy notUsedEnemy)
    {
        notUsedEnemy = enemies.FirstOrDefault(e => e.gameObject.activeSelf == false && reference.Equals(e));
        return notUsedEnemy != null;
    }
    public Enemy GetEnemy(Enemy original, Vector3 position, Quaternion rotation)
    {
        if (TryGet(original, out Enemy notUsedEnemy))
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
    public Enemy GetNewEnemy(Enemy original, Vector3 position, Quaternion rotation)
    {
        Enemy newEnemy = Instantiate(original, position, rotation);
        Add(newEnemy);
        return newEnemy;
    }
    public void Add(Enemy enemy)
    {
        enemies.Add(enemy);
    }
}
