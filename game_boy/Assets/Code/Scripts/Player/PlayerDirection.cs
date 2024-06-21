using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private PlayerController _pc;
    private Rigidbody2D _rb;
    
    public float directionY { get; private set; }
    public float directionX { get; private set; }
    
    private void Awake()
    {
        _pc = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Debug.Log(GetFacingDirection());
        //Debug.Log("x = " + directionX + ", y = " + directionX);
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
        directionY = movement.y;
    }

    private void GetDirectionX(Vector2 movement)
    {
        directionX = movement.x;
    }

    public int GetFacingDirection() //this is horrible
    {
        float x = directionX;
        float y = directionY;
        int ret = 0;
        if (x == 0 && y == 0) //0, 0 - no direction
            ret = 0;
        if (x == 0 && y < 0) //0, -1 - facing down
            ret = 1;
        if (x > 0 && y < 0) //1, -1 - facing down and right
            ret = 2;
        if (x > 0 && y == 0) //1, 0 - facing right
            ret = 3;
        if (x > 0 && y > 0) //1, 1 - facing up and right
            ret = 4;
        if (x == 0 && y > 0) //0, 1 - facing up
            ret = 5;
        if (x < 0 && y > 0) //-1, 1 - facing up and left
            ret = 6;
        if (x < 0 && y == 0) //-1, 0 - facing left
            ret = 7;
        if (x < 0 && y < 0) //-1, -1 - facing down and left
            ret = 8;
        return ret;
    }
}
