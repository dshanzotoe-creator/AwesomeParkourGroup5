using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput input;
    private InputAction movementAction;
    private InputAction cameraMovement;

    private InputAction crouch;

    private InputAction jump;

    public Vector2 MovementInput;
    public Vector2 RawCameraMovement;
    

    public float MouseSentitivity = 0.2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        movementAction = input.actions["Move"];
        cameraMovement = input.actions["Look"];
        crouch = input.actions["Crouch"];
        jump = input.actions["Jump"];
    }
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        MovementInput = movementAction.ReadValue<Vector2>();
        RawCameraMovement =  Mouse.current.delta.ReadValue();
 


    }



}
