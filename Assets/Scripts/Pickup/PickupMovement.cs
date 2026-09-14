using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Pickup))]
public class PickupMovement : MonoBehaviour
{
    #region variables
    IEnumerator moveFromPlayer;
    Pickup pickupScript;
    GameObject player;
    float speedBoost = 0;
    [SerializeField] float maxSpeedBoost;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        pickupScript = GetComponent<Pickup>();
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
