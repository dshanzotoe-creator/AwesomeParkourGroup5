using UnityEngine;

public class PlayerAttatchToPlatform : MonoBehaviour
{


    private StateMachine playerMovementScript;

    private Vector3 lastPlatformPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPlatformPosition = transform.position; // Update the last known position of the platform
    }

    private void LateUpdate()
    {
        Vector3 platformMovement = transform.position - lastPlatformPosition;

        // 2. Send that data to the player script if they are inside the trigger
        if (playerMovementScript != null)
        {
            playerMovementScript.SetPlatformMovement(platformMovement);
        }

        lastPlatformPosition = transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            playerMovementScript = other.GetComponent<StateMachine>();
            Debug.Log("Player has entered the platform trigger.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has exited the platform trigger.");

            if (playerMovementScript != null)
            {
                playerMovementScript.SetPlatformMovement(Vector3.zero);
            }

            playerMovementScript = null; // Clear the reference to the player's Movement script
          
        }
    }
}
