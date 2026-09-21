using UnityEngine;

public class PickupCounter : MonoBehaviour
{
    int maxPickups = 10;
    [SerializeField] int remainingPickups = 10;
    [SerializeField] int heldPickups = 0;
    
    void Start()
    {
        remainingPickups = maxPickups;
    }

    public void AddPickup()
    {
        heldPickups++;
    }

    public void DecrementPickups()
    {
        remainingPickups -= heldPickups;
        heldPickups = 0;
    }

    public int ReportRemainingPickups()
    {
        return remainingPickups;
    }

    public int ReportHeldPickups()
    {
        return heldPickups;
    }
}
