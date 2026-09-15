using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMovementAnchor : MonoBehaviour
{
    [SerializeField] List<Vector3> anchors = new();
    Vector3 currentAnchor = new();
    GameObject player;
    IEnumerator anchorMovement;
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    public void StartMovingToAnchor()
    {
        anchorMovement = MoveTowardsAnchor();
        List<float> dotProducts = new();
        foreach (Vector3 anchor in anchors)
        {
            dotProducts.Add(Vector3.Dot(player.transform.position, anchor));
        }
        StartCoroutine(anchorMovement);
    }

    IEnumerator MoveTowardsAnchor()
    {
        while (transform.position != anchors[0])
        yield return new WaitForEndOfFrame();
    }

    public bool IsMovingToAnchor()
    {
        if (anchorMovement is not null) return true;
        return false;
    }
}
