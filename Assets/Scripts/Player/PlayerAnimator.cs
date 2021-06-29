using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMover playerMover;
    private bool isRun = false;

    private void Awake()
    {
        playerMover = GetComponent<PlayerMover>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerMover.Move += OnPlayerMove;
        playerMover.Stay += OnPlayerStay;
    }

    private void OnDisable()
    {
        playerMover.Move -= OnPlayerMove;
        playerMover.Stay -= OnPlayerStay;

    }
    private void OnPlayerMove()
    {
        if (isRun == false)
        {
            animator.SetBool("IsRun", true);
            isRun = true;
        }
    }
    private void OnPlayerStay()
    {
        if (isRun)
        {
            animator.SetBool("IsRun", false);
            isRun = false;
        }
    }
}
