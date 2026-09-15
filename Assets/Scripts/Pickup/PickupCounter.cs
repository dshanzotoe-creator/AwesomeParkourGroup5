using UnityEngine;

public class PickupCounter : MonoBehaviour
{
    int maxPickups = 10;
    int remainingPickups = 10;
    int heldPickups = 0;
    
    void Start()
    {
        remainingPickups = maxPickups;
    }

    public void AddPickup()
    {
        heldPickups++;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            if (heldPickups > 0)
            {
                remainingPickups -= heldPickups;
            }
        }
    }
}
