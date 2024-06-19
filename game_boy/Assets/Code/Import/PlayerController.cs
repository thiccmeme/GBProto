using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _rb;

    [SerializeField] private float _movementSpeed = 5f;

    private Vector2 _movement;

    [SerializeField] private float playerFriction;

    [SerializeField] public float _xSpeed; 
    [SerializeField] public float _ySpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        PlayerMovement();
    }
    
    public void HandleMovementInput(Vector2 input)
    {
        _movement = input;
        Debug.Log("fuck");
    }
    
    private void PlayerMovement()
    { 
        //_rb.velocity = Vector2.Lerp(_rb.velocity, _movement.normalized * _movementSpeed * Time.fixedDeltaTime, playerFriction);
        _rb.velocity = _movement * _movementSpeed * Time.fixedDeltaTime;
    }
    
    
    
    
    
    
}