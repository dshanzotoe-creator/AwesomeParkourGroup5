using System.Collections;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    #region variables
    [SerializeField] Type type;
    GameObject player;
    PickupMovement pickupMovement;
    PickUpSFX pickupSFX;    // Variable for Pickup SFX script
    float distanceToPlayer = 0;
    float minimumDistance = 0; // to player
    bool pickedUp = false;
    #endregion

    void Awake()
    {
        player = GameObject.Find("Player");
        pickupMovement = gameObject.GetComponent<PickupMovement>();
        switch (type)
        {
            case Type.idle:
                minimumDistance = 0;
                break;
            case Type.moving:
                minimumDistance = 7.5f;
                StartCoroutine(CheckDistance());
                break;
        }
        pickupSFX = gameObject.GetComponent<PickUpSFX>();   // Assign Pickup SFX script to variable
    }

    public void HandlePickup()
    {
        GameObject.Find("PickupCounter").GetComponent<PickupCounter>().AddPickup();
        pickupSFX.HandlePickUpSFX();    // Plays the Pickup SFX as the player picks it up.
        gameObject.SetActive(false);
    }

    IEnumerator CheckDistance()
    {
        while (!pickedUp)
        {
            distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
            if (!pickupMovement.IsMoving() && distanceToPlayer < minimumDistance)
            {
                pickupMovement.StartMovingFromPlayer();
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public bool InRange()
    {
        if (distanceToPlayer < minimumDistance) return true;
        return false;
    }

    enum Type
    {
        idle,
        moving
    }
}
