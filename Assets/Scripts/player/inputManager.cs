using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput input;
    private InputAction movementAction;
    private InputAction cameraMovement;


    private InputAction jumpAction;

    private InputAction sprintAction;
    private Vector2 rawCameraMovement;

    public Vector2 MovementInput;

    public Vector2 CameraMovement;

    public bool IsJumping;

    public bool IsSprinting;

    public bool IsIdle;

    public bool IsWalking;

    public float MouseSentitivity = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        movementAction = input.actions["Move"];
        cameraMovement = input.actions["Look"];
        jumpAction = input.actions["Jump"];
        sprintAction = input.actions["Sprint"];


        jumpAction.started += Jumped;
        jumpAction.canceled += Jumped;

        sprintAction.started += Sprinting;
        sprintAction.canceled += Sprinting;


        movementAction.started += Walking;
        movementAction.canceled += Walking;
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


    private void Walking(InputAction.CallbackContext _){

        if(_.started)
            { 
            IsWalking = true;
            }
        if(_.canceled)
            { 
            IsWalking = false;
            }

    }


    private void Jumped(InputAction.CallbackContext _)
    {
        if (_.started) {
            IsJumping = true;
        }
        

        if (_.canceled)
        {
            IsJumping = false;

        }
           
    }

    private void Sprinting(InputAction.CallbackContext _) {
    
        if(_.started) IsSprinting = true;

        if(_.canceled) IsSprinting = false;
    }




    


}
