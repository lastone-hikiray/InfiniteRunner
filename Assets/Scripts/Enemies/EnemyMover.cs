using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float speed;

    private Transform cachedTransform;

    private void Start()
    {
        cachedTransform = this.transform;
    }
    private void Update()
    {
        cachedTransform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
