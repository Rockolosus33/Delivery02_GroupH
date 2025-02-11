using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _movement;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (_movement._lookDirection.x < 0 && (_movement._lookDirection.y < 0 || _movement._lookDirection.y > 0) 
            || _movement._lookDirection.x > 0 && (_movement._lookDirection.y < 0 || _movement._lookDirection.y > 0))
        {
            _animator.SetBool("isInDiagonal", true);
        }
        else
        {
            _animator.SetBool("isInDiagonal", false);
        }

        _animator.SetFloat("directionX", _movement._lookDirection.x);
        _animator.SetFloat("directionY", _movement._lookDirection.y);
    }
}
