﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 _lookDirection;

    [SerializeField] private float Speed = 5.0f;

    Rigidbody2D _rigidbody;

    private int score = 2000;

    public static Action<float> OnDistanceUploated;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        var inputVal = value.Get<Vector2>();

        Vector2 velocity = inputVal * Speed;
        _rigidbody.linearVelocity = velocity;
        _lookDirection = inputVal;
    }

    public void OnSaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        score = PlayerPrefs.GetInt("Score");
    }
}