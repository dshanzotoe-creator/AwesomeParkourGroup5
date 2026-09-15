using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private InputManager inputManager;

    private PlayerStats playerStats;
    private Camera camera;

    private SphereCollider groundCheck;


    private float lookAngle = 0f;
    private float lookAngleLimit = 90f;

    private Vector3 moveDirection = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
        camera = GetComponent<Camera>();
        groundCheck = GetComponent<SphereCollider>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        


       
        HandleCameraMovement();

        HandleMovement();

        if (controller.isGrounded)
        {
            inputManager.IsJumping = false;
        }
        
    }

    private void HandleCameraMovement()
    {

        lookAngle += -inputManager.RawCameraMovement.y * inputManager.MouseSentitivity;

        lookAngle = Mathf.Clamp(lookAngle, -lookAngleLimit, lookAngleLimit);
        camera.transform.localRotation = Quaternion.Euler(lookAngle,0,0);
        transform.rotation *= Quaternion.Euler(0, inputManager.RawCameraMovement.x * inputManager.MouseSentitivity,0);
        
    }


    public void HandleMovement() 
    {

        if (inputManager.IsSprinting) {
            playerStats.SetSpeed(10f);
        }
        else
        {
            playerStats.SetSpeed(3f);
        }
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float oldY = moveDirection.y;

        Vector2 newSpeed = new Vector2(inputManager.MovementInput.y * playerStats.GetSpeed(), inputManager.MovementInput.x * playerStats.GetSpeed());

        moveDirection = (forward * newSpeed.x) + (right * newSpeed.y);
        if(inputManager.IsJumping && controller.isGrounded)
        {
            moveDirection.y = playerStats.GetJumpForce();
        }
        else
        {
            moveDirection.y = oldY;
        }

        if (!controller.isGrounded)
        {
            moveDirection.y += playerStats.GetGravity() * Time.deltaTime;
        }

            controller.Move(moveDirection * Time.deltaTime);
    }
}
