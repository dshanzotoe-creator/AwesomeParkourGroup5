using UnityEngine;

public class BeamFacePlayer : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        // get player later on
    }

    void Update()
    {
        if (player == null) return;


        Vector3 direction = player.position - transform.position;
        
        direction.y = 0; 

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(-direction);
            transform.rotation = targetRotation;
        }
    }
}
