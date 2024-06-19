using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _rb;

    [SerializeField]private Vector2 _movementSpeed;

    private Vector2 _movement;

    [SerializeField] private float playerFriction;

    [SerializeField] public float _xSpeed; 
    [SerializeField] public float _ySpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    Vector2 playerMovement()
    { 
        return Vector2.Lerp(_rb.velocity, _movement.normalized * _movementSpeed * Time.fixedDeltaTime, playerFriction);
    }
    
    
    public void HandleMovementInput(Vector2 input)
    {
        _movement = input;
        Debug.Log("fuck");
    }

    private void HandleMovement()
    {
        _movementSpeed = new Vector2(_xSpeed, _ySpeed);

        _rb.velocity = playerMovement();
        Debug.Log("EA");
    }
    
    
    
    
    
    
}