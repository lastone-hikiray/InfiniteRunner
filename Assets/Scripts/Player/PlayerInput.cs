using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private PlayerMover playerMover;
    private void Start()
    {
        playerMover = GetComponent<PlayerMover>();
    }
    private void Update()
    {
#if UNITY_STANDALONE_WIN

        float translation = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        playerMover.TryMoveY(translation);

#endif
    }
}
