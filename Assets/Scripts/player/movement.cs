using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private InputManager inputManager;

    private PlayerStats playerStats;
    private Camera camera;
    private float lookAngle = 0f;
    private float lookAngleLimit = 90f;

    private Vector2 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
        camera = GetComponent<Camera>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.Set(inputManager.MovementInput.y, inputManager.MovementInput.x);


        controller.Move(moveDirection * Time.deltaTime * playerStats.GetSpeed());


        Debug.Log(inputManager.RawCameraMovement);
        HandleCameraMovement(inputManager.RawCameraMovement);


        
    }

    private void HandleCameraMovement(Vector2 rawCameraMovement)
    {

        lookAngle += -rawCameraMovement.y * inputManager.MouseSentitivity;

        lookAngle = Mathf.Clamp(lookAngle, -lookAngleLimit, lookAngleLimit);
        camera.transform.localRotation = Quaternion.Euler(lookAngle,0,0);
        transform.rotation *= Quaternion.Euler(0, rawCameraMovement.x * inputManager.MouseSentitivity,0);
        Debug.Log(rawCameraMovement);
    }
}
