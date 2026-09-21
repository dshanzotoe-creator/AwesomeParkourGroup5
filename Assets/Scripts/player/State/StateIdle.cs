using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static StateMachine;

public class StateIdle : MonoBehaviour, IState
{

    InputManager inputManager;
    StateManager stateManager;
    CharacterController controller;
    PlayerStats playerStats;

    [Header("Movement")]
    private Vector3 platformMovementDelta = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 playerForward;
    private Vector3 playerRight;
    private Vector2 playerMovementSpeed;
    private float walkSpeed;

    public void Enter()
    {
        inputManager = GetComponent<InputManager>();
        stateManager = GetComponent<StateManager>();
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
    }

    public void Exit()
    { 

    }

    public void Update() 
    {
        playerForward = transform.TransformDirection(Vector3.forward);
        playerRight = transform.TransformDirection(Vector3.right);


        float oldY = moveDirection.y;

        playerMovementSpeed = new Vector2(inputManager.MovementInput.y * walkSpeed, inputManager.MovementInput.x * walkSpeed);

        moveDirection = (playerForward * playerMovementSpeed.x) + (playerRight * playerMovementSpeed.y);



        moveDirection.y = oldY;

        //apply gravity
        if (!controller.isGrounded)
        {
            moveDirection.y += playerStats.GetGravity() * Time.deltaTime;
        }



        Vector3 totalPlayerMovement = moveDirection * Time.deltaTime;

        Vector3 finalPlatformMovement = platformMovementDelta;

        if (!controller.isGrounded) finalPlatformMovement.y = 0f;




        controller.Move((totalPlayerMovement + finalPlatformMovement)); //This line applies both the player's movement and the platform's movement to the character controller. Only if there is actually a platform.


        platformMovementDelta = Vector3.zero; // Reset platform movement after applying it


        if (inputManager.IsSprinting)
        {
            stateManager.ChangeState();
        }

        if (inputManager.IsJumping && controller.isGrounded)
        {
            state = MovementState.StateJumping;
        }

        if (inputManager.IsCrouching)
        {
            state = MovementState.StateCrouching;
        }
    }
}
