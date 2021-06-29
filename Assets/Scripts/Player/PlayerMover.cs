using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerMover : MonoBehaviour
{
    public event UnityAction Move;
    public event UnityAction Stay;

    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;

    public bool TryMoveY(float translation)
    {
        bool canMove = CanDoMove(translation);
        if (canMove)
        {
            MoveY(translation);
            Move?.Invoke();
        }
        else
        {
            Stay?.Invoke();
        }
        return canMove;
    }
    private bool CanDoMove(float translation)
    {
        if (translation == 0)
            return false;
        float nextPositionY = translation + this.transform.position.y;
        bool canMove = nextPositionY < maxHeight && nextPositionY > minHeight;
        return canMove;
    }
    private void MoveY(float translation)
    {
        Vector3 moveStep = new Vector3(0, translation, 0);
        transform.Translate(moveStep);
    }
}
