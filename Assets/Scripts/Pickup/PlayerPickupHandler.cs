using UnityEngine;

public class PlayerPickupHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.GetComponent<Pickup>().HandlePickup();
        }

        else if (other.CompareTag("Collector"))
        {
            PickupCounter pickupCounter = GameObject.Find("PickupCounter").GetComponent<PickupCounter>();
            if (pickupCounter.ReportHeldPickups() > 0)
            {
                pickupCounter.DecrementPickups();
            }
        }
    }
}
