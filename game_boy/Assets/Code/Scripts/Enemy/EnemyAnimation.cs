using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Code.Scripts.Enemy;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _an;
    private Rigidbody2D _rb;
    private BaseEnemyController _ec;
    private void Awake()
    {
        _an = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _ec = GetComponent<BaseEnemyController>();
    }

    public void HandleAnimation()
    {
        int x = 0;
        int y = 0;
        if (_ec.EnemyAngle >= -45f && _ec.EnemyAngle <= 45f) //right
        {
            x = -1;
            y = 0;
            UpdateAnimation(x, y);
        }
        else if (_ec.EnemyAngle >= 45f && _ec.EnemyAngle <= 135f) //up
        {
            x = 0;
            y = 1;
            UpdateAnimation(x, y);
        }
        else if (_ec.EnemyAngle >= -135f && _ec.EnemyAngle <= -45f) //down
        {
            x = 0;
            y = -1;
            UpdateAnimation(x, y);
        }
        else //left
        {
            x = 1;
            y = 0;
            UpdateAnimation(x, y);
        }
    }

    private void UpdateAnimation(int x, int y)
    {
        _an.SetFloat("MovementX", x);
        _an.SetFloat("MovementY", y);
    }
}
