using System.Collections;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    #region variables
    [SerializeField] Type type;
    GameObject player;
    PickupMovementDynamic pickupMovement;
    float distanceToPlayer = 0;
    float minimumDistance = 0; // to player
    bool pickedUp = false;
    #endregion

    void Awake()
    {
        player = GameObject.Find("Player");
        pickupMovement = gameObject.GetComponent<PickupMovementDynamic>();
        switch (type)
        {
            case Type.idle:
                minimumDistance = 0;
                break;
            case Type.movingDynamic:
                minimumDistance = 7.5f;
                StartCoroutine(CheckDistanceDynamic());
                break;
            case Type.movingAnchor:
                minimumDistance = 7.5f;
                StartCoroutine(CheckDistanceAnchor());
                break;
        }
    }

    public void HandlePickup()
    {
        // decrement via pickupcounter
        Destroy(gameObject);
    }

    IEnumerator CheckDistanceDynamic()
    {
        while (!pickedUp)
        {
            distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
            if (!pickupMovement.IsMovingFromPlayer() && distanceToPlayer < minimumDistance)
            {
                pickupMovement.StartMovingFromPlayer();
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator CheckDistanceAnchor()
    {
        while (!pickedUp)
        {
            distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
            if (!pickupMovement.IsMovingFromPlayer() && distanceToPlayer < minimumDistance)
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
        movingDynamic,
        movingAnchor
    }
}
