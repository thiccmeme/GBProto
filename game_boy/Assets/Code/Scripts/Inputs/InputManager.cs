using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private CharacterInput _characterInput;

    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        _characterInput = new CharacterInput();
        _characterInput.CharacterMovement.Movement.performed += i => _player?.HandleMovementInput(i.ReadValue<Vector2>());
        
    }
}
