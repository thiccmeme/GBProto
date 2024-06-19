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
    private int animNum;
    private int prevAnimNum;
    private void Awake()
    {
        _dir = GetComponent<PlayerDirection>();
        _rb = GetComponent<Rigidbody2D>();
        _an = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //HandleAnimation();
        //ObjectAnimation();
        Debug.Log(_rb.velocity.y);
        //Debug.Log(IsMoving());
    }

    private void HandleAnimation()
    {
        
    }

   /*private void ObjectAnimation() //horrible. awful. don't do this
   {
       /*if (animNum == prevAnimNum)
           return;
        if (_dir.GetDirectionY() == -1)
        {
            if (!IsMoving())
            {
                _an.Play("an-p_idlefront");
            }
            else
                _an.Play("an-p_walkfront");
        }
        if (_dir.GetDirectionY() == 1)
        {
            if(!IsMoving())
                _an.Play("an-p_walkback");
            else
                _an.Play("an-p_idleback");
        }
    }

    private bool IsMoving()
    {
        if (_rb.velocity.x <= 0.05f && _rb.velocity.y <= 0.05f && _rb.velocity.x >= -0.05f && _rb.velocity.y >= -0.05f) 
            return false;
        else 
            return true;
    }

    private void UpdateAnimNumber(int num)
    {
        animNum = num;
        prevAnimNum = animNum;
    }*/
}
