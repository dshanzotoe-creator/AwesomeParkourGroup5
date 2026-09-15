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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPickup()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collector")
        {
            if (heldPickups > 0)
            {
                remainingPickups -= heldPickups;
            }
        }
    }
}
