using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private PlayerController _pc;
    private Rigidbody2D _rb;
    
    public int directionY { get; private set; }
    public int directionX { get; private set; }
    /// <summary>
    /// X
    /// -1 is down
    /// 1 is up
    /// Y
    /// is left
    /// is right
    /// </summary>
    
    private void Awake()
    {
        _pc = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(_pc.movement.sqrMagnitude > 0.01f)
            UpdateFacingDirection();
    }

    private void UpdateFacingDirection()
    {
        GetDirectionY(_pc.movement);
        GetDirectionX(_pc.movement);
    }

    private void GetDirectionY(Vector2 movement)
    {
        if (movement.y < 0) //facing down
            directionY = -1;
        else if (movement.y > 0) //facing up
            directionY = 1;
    }

    private void GetDirectionX(Vector2 movement)
    {
        if (movement.x < 0) 
            directionX = -1;
        else if (movement.x > 0) 
            directionX = 1;
    }
}
