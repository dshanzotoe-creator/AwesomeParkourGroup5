using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pickup))]
public class PickupMovement : MonoBehaviour
{
    #region variables
    IEnumerator movementCoroutine;
    [SerializeField] List<Transform> anchors = new();
    Transform currentAnchor;
    Pickup pickupScript;
    GameObject player;
    float speedBoost = 0;
    [SerializeField] float maxSpeedBoost;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GameObject.Find("Player");
        pickupScript = gameObject.GetComponent<Pickup>();
    }

    public void StartMovingToAnchor() // scrap?
    {
        movementCoroutine = MoveTowardsAnchor();
        float lowestDot = 0;
        List<float> dotProducts = new();
        foreach (Transform anchor in anchors)
        {
            dotProducts.Add(Vector3.Dot(player.transform.position, anchor.position));
        }
        foreach (float dotProduct in dotProducts)
        {
            if (lowestDot == 0) { lowestDot = dotProduct; }
            Debug.Log(dotProduct);
        }
        StartCoroutine(movementCoroutine);
    }

    IEnumerator MoveTowardsAnchor()
    {
        while (transform.position != anchors[0].position)
        yield return new WaitForEndOfFrame();
    }

    public bool IsMoving()
    {
        if (movementCoroutine is not null) return true;
        return false;
    }

    public void StartMovingFromPlayer()
    {
        movementCoroutine = MoveFromPlayer();
        StartCoroutine(movementCoroutine);
    }

    IEnumerator MoveFromPlayer()
    {
        while (pickupScript.InRange())
        {
            BoostSpeedWhileInRadius();
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -Time.deltaTime * speedBoost);
            yield return new WaitForEndOfFrame();
        }
        ResetState(); // only triggers on exit. 
    }

    void BoostSpeedWhileInRadius()
    {
        if (speedBoost < maxSpeedBoost)
        {
            speedBoost = Mathf.Lerp(speedBoost, maxSpeedBoost, maxSpeedBoost / 10 * Time.deltaTime);
        }
    }

    void ResetState()
    {
        speedBoost = 0;
        movementCoroutine = null;
    }
}
