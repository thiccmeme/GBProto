using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _rb;

    [SerializeField] private float _movementSpeed = 5f;

    public Vector2 movement;

    [SerializeField] private float playerFriction;

    [SerializeField] private float _xSpeed; 
    [SerializeField] private float _ySpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        PlayerMovement();
    }

    Vector2 playerMovement()
    { 
        return Vector2.Lerp(_rb.velocity, _movement.normalized * _movementSpeed * Time.fixedDeltaTime, playerFriction);
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