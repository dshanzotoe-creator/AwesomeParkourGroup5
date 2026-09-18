using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pickup))]
public class PickupMovement : MonoBehaviour
{
    #region variables
    bool shouldMove = false;
    IEnumerator movementCoroutine;
    Pickup pickupScript;
    GameObject player;
    float speedBoost = 0;
    [SerializeField] float maxSpeedBoost;
    [SerializeField] float floatDistance;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GameObject.Find("Player");
        pickupScript = gameObject.GetComponent<Pickup>();
        StartCoroutine(ShouldMove());
    }

    void Start()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
        {
            Debug.Log(hit.transform.gameObject.name);
            transform.position = new(transform.position.x, hit.transform.position.y + transform.localScale.y/2 + hit.transform.localScale.y/2 + floatDistance, transform.position.z);
        }
    }

    void Update()
    {
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
        while (shouldMove)
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

    IEnumerator ShouldMove()
    {
        while (true)
        {
            if (Physics.Raycast(transform.position, Vector3.down, 2f, LayerMask.GetMask("Floor")) && pickupScript.InRange())
            {
                shouldMove = true;
            }
            else shouldMove = false;
            yield return new WaitForEndOfFrame();
        }
    }
}
