using UnityEngine;

public class PickupCounter : MonoBehaviour
{
    [SerializeField] int remainingPickups;
    [SerializeField] int heldPickups = 0;
    
    void Start()
    {
 
    }

    public void AddPickup()
    {
        heldPickups++;
    }

    public void DecrementPickups()
    {
        remainingPickups -= heldPickups;
        SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("InsertCollector"), transform, 0.5f);   //Plays sound when delivering pickups to collector
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
