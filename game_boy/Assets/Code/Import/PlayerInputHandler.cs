using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerController playerController;


    CharacterInput characterInput;

    private void OnEnable()
    {
        playerController = GetComponent<PlayerController>();

        if(characterInput == null)
        {
                characterInput = new CharacterInput();
                characterInput.CharacterMovement.Movement.performed += i => playerController?.HandleMovementInput(i.ReadValue<Vector2>());
            
        }

        characterInput.Enable();
    }
    
}
