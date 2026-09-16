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


    private float lookAngleY = 0f;
    private float lookAngleX = 0f;
    private float nearFoV = 70f;
    private float farFoV = 90f;

    private float lookAngleLimit = 90f;

    private Vector3 moveDirection = Vector3.zero;

    private Vector3 platformMovementDelta = Vector3.zero;
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
        setRunningFoV();
        if (controller.isGrounded)
        {
            inputManager.IsJumping = false;
        }
        
    }

    public void SetPlatformMovement(Vector3 delta)
    {
        platformMovementDelta = delta;
    }

    private void HandleCameraMovement()
    {

        lookAngleY -= inputManager.CameraMovement.y;
        lookAngleX += inputManager.CameraMovement.x;
        lookAngleY = Mathf.Clamp(lookAngleY, -lookAngleLimit, lookAngleLimit);

        transform.localRotation = Quaternion.Euler(lookAngleY,0f,0f);
        transform.rotation = Quaternion.Euler(lookAngleY,lookAngleX, 0);
        
    }


    public void HandleMovement() 
    {

        if (inputManager.IsSprinting) {
            playerStats.SetSpeed(10f);
        }
        else
        {
            playerStats.SetSpeed(5f);
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

        Vector3 totalPlayerMovement = moveDirection * Time.deltaTime;

        Vector3 finalPlatformMovement = platformMovementDelta;

        if (!controller.isGrounded) finalPlatformMovement.y = 0f; 

        //controller.Move(Vector3.Lerp(controller.velocity ,moveDirection, 0.1f) * Time.deltaTime);

        controller.Move((totalPlayerMovement + finalPlatformMovement)); //This line applies both the player's movement and the platform's movement to the character controller. Only if there is actually a platform.

        platformMovementDelta = Vector3.zero; // Reset platform movement after applying it

    }

    public void setRunningFoV()
    {
        if (inputManager.IsSprinting)
        {
            var currentFoV = camera.fieldOfView;
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, farFoV, 0.02f);     
        }
        else
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, nearFoV, 0.05f);
        }
    }
}
