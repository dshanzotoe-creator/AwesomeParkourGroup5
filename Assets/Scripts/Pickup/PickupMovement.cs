using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Pickup))]
public class PickupMovement : MonoBehaviour
{
    #region variables
    IEnumerator moveFromPlayer;
    Vector3 desiredRotation = new();
    Vector3 nextRotation = new();
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
        StartCoroutine(RotateRandom());
    }

    public void StartMovingFromPlayer()
    {
        moveFromPlayer = MoveFromPlayer();
        StartCoroutine(moveFromPlayer);
    }

    IEnumerator MoveFromPlayer()
    {
        while (pickupScript.InRange())
        {
            Debug.Log("a");
            BoostSpeedWhileInRadius();
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -Time.deltaTime * speedBoost);
            yield return new WaitForEndOfFrame();
        }
        ResetState(); // only triggers on exit. 
    }

    IEnumerator RotateRandom()
    {
        StartCoroutine(DecideRotationAnchor());
        while (1 == 1)
        {
            transform.Rotate(desiredRotation*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator DecideRotationAnchor()
    {
        StartCoroutine(RerollRotationAnchor());
        while (1 == 1)
        {
            nextRotation = new(Random.Range(-60, 61), Random.Range(-60, 61), Random.Range(-60, 61));
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }

    IEnumerator RerollRotationAnchor()
    {
        while (1 == 1)
        {
            desiredRotation = Vector3.Lerp(desiredRotation, nextRotation, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
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
        moveFromPlayer = null;
    }

    public bool IsMovingFromPlayer()
    {
        if (moveFromPlayer is not null) return true;
        return false;
    }
}
