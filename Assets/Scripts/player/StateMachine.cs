using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class StateMachine : MonoBehaviour
{

    public MovementState state;
    public enum MovementState{
        StateWalking,
        StateSprinting,
        StateCrouching,
        StateSliding,
        StateWallRunning,
        StateJumping

    }


    private CharacterController controller;
    private InputManager inputManager;
    private PlayerStats playerStats;
   
    public bool stateWalking;
    public bool stateSprinting;
    public bool StateCrouching;

    public bool StateSliding;
    public bool StateWallRunning;
    public bool StateJumping;


    private float crouchSpeed;
    private float walkSpeed;
    private float sprintSpeed;

    [Header("Wallrun")]
    public float wallCheckDistance;
    private float minWallrunHeight;
    private RaycastHit leftWallHit;
    private RaycastHit rightWallHit;
    private bool wallLeft;
    private bool wallRight;



    [Header("Movement")]
    private Vector3 platformMovementDelta = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 playerForward;
    private Vector3 playerRight;
    private Vector2 playerMovementSpeed;


    [Header("Reference")]
    public Transform orientation;


    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerStats = GetComponent<PlayerStats>();
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        crouchSpeed = 2.5f;
        walkSpeed = 5f;
        sprintSpeed = 10f;
    }


    void Update()
    {
        HandleState();
    }

    private void HandleState()
    {


        switch (state)
        {
            case MovementState.StateWalking:


                StateWalking();






                break;


            case MovementState.StateSprinting:
               
                StateSprinting();

                break;


            case MovementState.StateCrouching:







                break;


            default:



                break;

        }






    }




    public void StateWalking()
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
            state = MovementState.StateSprinting;
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





    public void StateSprinting()
    {






        if (!inputManager.IsSprinting)
        {
            state = MovementState.StateWalking;
        }


        if (inputManager.IsJumping && controller.isGrounded)
        {
            state = MovementState.StateJumping;
        }

        if (inputManager.IsCrouching)
        {
            state = MovementState.StateSliding;
        }

    }

    private bool IsPlayerTooCloseToGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minWallrunHeight);
    }

    public void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallCheckDistance);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallCheckDistance);
    }

    public void SetPlatformMovement(Vector3 delta)
    {
        platformMovementDelta = delta;
    }



    }
