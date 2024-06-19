using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerDirection _dir;
    private Rigidbody2D _rb;
    private Animator _an;
    private SpriteRenderer _spr;
    private PlayerController _pc;
    private void Awake()
    {
        _dir = GetComponent<PlayerDirection>();
        _rb = GetComponent<Rigidbody2D>();
        _an = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();
        _pc = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        HandleAnimation();
        UpdateDirection();
    }

    private void HandleAnimation()
    {
        _an.SetFloat("MovementX", _pc.movement.x);
        _an.SetFloat("MovementY", _pc.movement.y);
        if (IsMoving())
        {
            _an.SetFloat("Speed", _pc.movement.sqrMagnitude);
        }
        else
            _an.SetFloat("Speed", 0f);
    }

    private void UpdateDirection()
    {
        switch (_dir.directionX)
        {
            case -1:
                _an.SetFloat("DirectionX", -1f); //left
                _spr.flipX = false;
                break;
            case 1:
                _an.SetFloat("DirectionX", 1f); //right
                _spr.flipX = true;
                break;
        }
        switch (_dir.directionY)
        {
            case -1:
                _an.SetFloat("DirectionY", -1f); //down
                break;
            case 1:
                _an.SetFloat("DirectionY", 1f); //up
                break;
        }
    }

    private bool IsMoving()
    {
        if (_pc.movement.y == 0 && _pc.movement.x == 0)  
            return false;
        else 
            return true;
    }
}
