using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _movement;

    private PlayerAnimationsStates _currentAnimation;

    enum PlayerAnimationsStates
    {
        PlayerLeftAnimation,
        PlayerRightAnimation,
        PlayerFrontAnimation,
        PlayerBackAnimation
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
        _currentAnimation = PlayerAnimationsStates.PlayerFrontAnimation;
        _animator.SetInteger("numAnim", 2);
    }

    void Update()
    {
        Vector2 lookDirection = _movement._lookDirection;

        if (lookDirection.x < 0 && _currentAnimation != PlayerAnimationsStates.PlayerLeftAnimation && lookDirection.y == 0)
        {
            ChangeAnimation(PlayerAnimationsStates.PlayerLeftAnimation, 0);
        }
        else if (lookDirection.x > 0 && _currentAnimation != PlayerAnimationsStates.PlayerRightAnimation && lookDirection.y == 0)
        {
            ChangeAnimation(PlayerAnimationsStates.PlayerRightAnimation, 1);
        }
        else if (lookDirection.y < 0 && _currentAnimation != PlayerAnimationsStates.PlayerFrontAnimation)
        {
            ChangeAnimation(PlayerAnimationsStates.PlayerFrontAnimation, 2);
        }
        else if (lookDirection.y > 0 && _currentAnimation != PlayerAnimationsStates.PlayerBackAnimation)
        {
            ChangeAnimation(PlayerAnimationsStates.PlayerBackAnimation, 3);
        }
    }

    void ChangeAnimation(PlayerAnimationsStates newAnimation, int number)
    {
        _currentAnimation = newAnimation;
        _animator.SetInteger("numAnim", number);
        _animator.SetTrigger("runAnimation");
    }
}