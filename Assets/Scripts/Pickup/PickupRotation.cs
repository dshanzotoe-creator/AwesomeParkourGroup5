using System.Collections;
using UnityEngine;

public class PickupRotation : MonoBehaviour
{
    Vector3 desiredRotation = new();
    Vector3 nextRotation = new();

    void Awake()
    {
        StartCoroutine(RotateRandom());
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
}
