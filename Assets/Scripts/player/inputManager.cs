using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput input;
    private InputAction movementAction;
    private InputAction cameraMovement;

    private InputAction crouchAction;

    private InputAction jumpAction;

    private InputAction sprintAction;
    private Vector2 rawCameraMovement;

    public Vector2 MovementInput;

    public Vector2 CameraMovement;

    public bool InputJumping;
    public bool InputCrouching;

    public bool InputSprinting;

    public bool IsIdle;

    public bool InputWalking;

    public float MouseSentitivity = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        movementAction = input.actions["Move"];
        cameraMovement = input.actions["Look"];
        crouchAction = input.actions["Crouch"];
        jumpAction = input.actions["Jump"];
        sprintAction = input.actions["Sprint"];


        jumpAction.started += Jumped;
        jumpAction.canceled += Jumped;

        sprintAction.started += Sprinting;
        sprintAction.canceled += Sprinting;

        crouchAction.started += Crouching;
        crouchAction.canceled += Crouching;

    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        MovementInput = movementAction.ReadValue<Vector2>();
        rawCameraMovement =  Mouse.current.delta.ReadValue();

        CameraMovement.x = rawCameraMovement.x * MouseSentitivity;
        CameraMovement.y = rawCameraMovement.y * MouseSentitivity;
    }

<<<<<<< Updated upstream
=======

    private void Walking(InputAction.CallbackContext _){

        if(_.started)
            { 
            InputWalking = true;
            }
        if(_.canceled)
            { 
            InputWalking = false;
            }

    }


>>>>>>> Stashed changes
    private void Jumped(InputAction.CallbackContext _)
    {
        if (_.started) {
            InputJumping = true;
        }
        

        if (_.canceled)
        {
            InputJumping = false;

        }
           
    }

    private void Sprinting(InputAction.CallbackContext _) {
    
        if(_.started) InputSprinting = true;

        if(_.canceled) InputSprinting = false;
    }

    private void Crouching(InputAction.CallbackContext _) {

        if (_.started) { InputCrouching = true; }
    
        if (_.canceled) { InputCrouching = false; }
    }




    


}
