using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static StateMachine;

public class StateWalking : MonoBehaviour, IState
{

    InputManager inputManager;

    CharacterController controller;
    PlayerStats playerStats;
    PlayerMovement movement;

    [Header("Movement")]
    private Vector3 platformMovementDelta = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 playerForward;
    private Vector3 playerRight;
    private Vector2 playerMovementSpeed;
    private float walkSpeed;

    public void StateEnter(StateManager _)
    {
        inputManager = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
        movement = GetComponent<PlayerMovement>();
    }

    public void StateExit(StateManager _)
    { 

    }

    public void StateUpdate(StateManager _) 
    {
        


        if (inputManager.IsSprinting)
        {
            _.ChangeState(_.stateSprinting);
        }

        if (inputManager.IsJumping && controller.isGrounded)
        {
            _.ChangeState(_.stateJumping);
        }

        if (inputManager.IsCrouching)
        { 
            _.ChangeState(_.stateCrouching);
        }
    }
}
