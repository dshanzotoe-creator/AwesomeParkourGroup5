using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private InputManager inputManager;
    private PlayerStats playerStats;

        [Header("Movement")]
    private Vector3 platformMovementDelta = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 playerForward;
    private Vector3 playerRight;
    private Vector2 playerMovementSpeed;
    private float walkSpeed;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerStats = GetComponent<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetMovement(Vector3 playerForward, Vector3 playerRight,float speed, bool isGrounded, Vector2 movementInput, float gravity)
    {
        //playerForward = transform.TransformDirection(Vector3.forward);
        //playerRight = transform.TransformDirection(Vector3.right);


        float oldY = moveDirection.y;

        playerMovementSpeed = new Vector2(movementInput.y * speed, movementInput.x * speed);

        moveDirection = (playerForward * playerMovementSpeed.x) + (playerRight * playerMovementSpeed.y);



        moveDirection.y = oldY;

        //apply gravity
        if (!isGrounded)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }



        Vector3 totalPlayerMovement = moveDirection * Time.deltaTime;

        Vector3 finalPlatformMovement = platformMovementDelta;

        if (!isGrounded) finalPlatformMovement.y = 0f;


        platformMovementDelta = Vector3.zero;

        //This line applies both the player's movement and the platform's movement to the character controller. Only if there is actually a platform.

        return totalPlayerMovement + finalPlatformMovement;
         // Reset platform movement after applying it
    }
}
