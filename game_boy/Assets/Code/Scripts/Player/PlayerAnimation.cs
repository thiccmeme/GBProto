using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerDirection _dir;
    private Animator _an;
    private SpriteRenderer _spr;
    private PlayerController _pc;
    private void Awake()
    {
        _dir = GetComponent<PlayerDirection>();
        _an = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();
        _pc = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if(_pc.movement.sqrMagnitude > 0.01f)
            HandleAnimation();
        else
            SitStill(); 
    }

    private void HandleAnimation()
    {
        _an.SetFloat("MovementX", _pc.movement.x);
        _an.SetFloat("MovementY", _pc.movement.y);
        _an.SetFloat("Speed", _pc.movement.sqrMagnitude);

        switch (_dir.directionX)
        {
            case -1:
                _spr.flipX = false;
                break;
            case 1:
                _spr.flipX = true;
                break;
        }
    }

    private void SitStill()
    {
        if (_an.GetFloat("Speed") == 0f)
            return;
        _an.SetFloat("Speed", 0f);
    }

    /*private void UpdateDirection()
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
    }*/
}
