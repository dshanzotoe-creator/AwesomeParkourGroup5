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

    public bool IsJumping;
    public bool IsCrouching;

    public bool IsSprinting;

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
        sprintAction.started += Sprinting;
        sprintAction.canceled += Sprinting;

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

    private void Jumped(InputAction.CallbackContext _)
    {
        if (_.started)
        IsJumping = true;
    }

    private void Sprinting(InputAction.CallbackContext _) {
    
        if(_.started) IsSprinting = true;

        if(_.canceled) IsSprinting = false;
    }

    private void NotSprinting(InputAction.CallbackContext _){
        IsSprinting = false;
    }



    


}
