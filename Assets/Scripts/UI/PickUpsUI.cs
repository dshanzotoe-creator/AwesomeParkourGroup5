using UnityEngine;
using UnityEngine.UI;


public class PickUpsUI : MonoBehaviour
{
    [SerializeField] Text remainingPickups;
    [SerializeField] Text heldPickups;

    [SerializeField] PickupCounter pickupCounter;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        remainingPickups.text = "Remaining Pickups: " + pickupCounter.ReportRemainingPickups();
        heldPickups.text = "Held Pickups: " + pickupCounter.ReportHeldPickups();
    }
}
