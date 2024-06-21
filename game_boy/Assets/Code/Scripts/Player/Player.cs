using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : UnitSprite
{

    private Rigidbody2D _rb;

    [SerializeField]private Vector2 _movementSpeed;

     private Vector2 _movement;

    [SerializeField] private float playerFriction;

    [SerializeField] private float _xSpeed;
    [SerializeField] private float _ySpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        HandleMovement();
    }

    Vector2 playerMovement()
    { 
        return Vector2.Lerp(_rb.velocity, _movement.normalized * _movementSpeed * Time.fixedDeltaTime, playerFriction);
    }
    
    public override void Die()
    {
        Destroy(this);
        Debug.Log("Kill Player.");

        //RESTART GAME
    }
    
    public void HandleMovementInput(Vector2 input)
    {
        _movement = input;
    }

    private void HandleMovement()
    {
        _movementSpeed = new Vector2(_xSpeed, _ySpeed);

        _rb.velocity = playerMovement();
    }
}
