using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{


        [Header("Movement")]
    private Vector3 platformMovementDelta = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    private Vector2 playerMovementSpeed;




    public Vector3 GetNormalMovement(Vector3 playerForward, Vector3 playerRight,float speed, bool isGrounded,bool isJumping, Vector2 movementInput, float gravity, float jumpForce)
    {

        float oldY = moveDirection.y;

        playerMovementSpeed = new Vector2(movementInput.y * speed, movementInput.x * speed);

        moveDirection = (playerForward * playerMovementSpeed.x) + (playerRight * playerMovementSpeed.y);

        if(isJumping && isGrounded)
        {
            moveDirection.y = jumpForce;
        }
        else
        {
            moveDirection.y = oldY;
        }

        //apply gravity
        if (!isGrounded)
        {
            if (gravity < 30){
                moveDirection.y -= gravity * Time.deltaTime;
            }
            
 
        }



        Vector3 totalPlayerMovement = moveDirection * Time.deltaTime;

        Vector3 finalPlatformMovement = platformMovementDelta;

        if (!isGrounded) finalPlatformMovement.y = 0f;

        platformMovementDelta = Vector3.zero;

        //This line applies both the player's movement and the platform's movement to the character controller. Only if there is actually a platform.

        return totalPlayerMovement + finalPlatformMovement;
         // Reset platform movement after applying it
    }

    public void SetPlatformMovement(Vector3 delta)
    {
        platformMovementDelta = delta;
    }
}
