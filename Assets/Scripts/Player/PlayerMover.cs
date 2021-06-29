using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerMover : MonoBehaviour
{
    public event UnityAction OnMove;
    public event UnityAction OnStay;

    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;

    private Transform cachedTransform;

    private void Awake()
    {
        cachedTransform = this.transform;
    }

    public bool TryMoveY(float translation)
    {
        bool canMove = CanMove(translation);
        if (canMove)
        {
            MoveY(translation);
            OnMove?.Invoke();
        }
        else
        {
            OnStay?.Invoke();
        }
        return canMove;
    }

    private bool CanMove(float translation)
    {
        if (translation == 0)
            return false;
        float nextPositionY = translation + cachedTransform.position.y;
        bool canMove = nextPositionY < maxHeight && nextPositionY > minHeight;
        return canMove;
    }

    private void MoveY(float translation)
    {
        Vector3 moveStep = new Vector3(0, translation, 0);
        cachedTransform.Translate(moveStep);
    }
}
