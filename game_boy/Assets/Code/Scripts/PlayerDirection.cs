using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private PlayerController _pc;
    private Rigidbody2D _rb;
    
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
        
    }

    public int GetDirectionY()
    {
        int directionY = 0;
        if (_rb.velocity.y < 0) //facing down
            directionY = -1;
        else if (_rb.velocity.y > 0) //facing up
            directionY = 1;
        return directionY;
    }

    public int GetDirectionX()
    {
        int directionX = 0;
        if (_rb.velocity.y < 0.5) //facing 
            directionX = -1;
        else if (_rb.velocity.y > -0.5) //facing 
            directionX = 1;
        return directionX;
    }
}
