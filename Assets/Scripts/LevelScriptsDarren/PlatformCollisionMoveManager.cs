using System.Collections;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformCollisionMoveManager : MonoBehaviour
{

    [SerializeField] float movementTypeNumber = 0;
    Vector3 startPos;

    [SerializeField] float fallSpeed = 5f;

    Quaternion originalRotation;

    bool moving = false;

    MeshRenderer meshRenderer;

    [SerializeField] BoxCollider boxCollider;

    [SerializeField] Collider childBoxCollider; 

    Coroutine spinRoutine; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;       
        originalRotation = transform.rotation;
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        childBoxCollider = transform.GetChild(0).GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !moving)
        {
            Debug.Log("Player has landed on the platform.");
            ChooseMovement(movementTypeNumber);
        }
    }
    IEnumerator FallAfterPlayerLanding()
    {
        float timeBeforeFall = 1.5f;
        moving = true;

        
        yield return new WaitForSeconds(timeBeforeFall);

        while (transform.position.y > startPos.y - 10f) 
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
            yield return null;
        }

        meshRenderer.enabled = false;
        boxCollider.enabled = false;
        childBoxCollider.enabled = false;

        yield return new WaitForSeconds(1f);

        meshRenderer.enabled = true;
        boxCollider.enabled = true;
        childBoxCollider.enabled = true;

        while (transform.position.y < startPos.y)
        {
            transform.position += Vector3.up * fallSpeed * Time.deltaTime;
            yield return null;
        }   

        moving = false;
    }

    IEnumerator Rotate90DegreesAfterPlayerLanding()
    {
        float timeBeforeRotation = 1.5f;
        moving = true;
        yield return new WaitForSeconds(timeBeforeRotation);
        float rotationSpeed = 60f; // degrees per second
        float originalRotation = transform.eulerAngles.z;
        float targetRotation = transform.eulerAngles.z + 90f;
        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetRotation)) > 0.1f)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, step);
            yield return null;
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, targetRotation);

        yield return new WaitForSeconds(timeBeforeRotation);

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, originalRotation)) > 0.1f) 
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -step);
            yield return null;
        }
        moving = false;

    }

    IEnumerator Spin()
    {
        bool spinning = true;
        moving = true; 
        float rotationSpeed = 90f; // degrees per second

        float targetRotation = originalRotation.eulerAngles.y + 90f;

        while (spinning)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.Rotate(0, step, 0);
            yield return null;
        }
    }


    void ChooseMovement(float number)
    {
        number = Mathf.Clamp(number, 1, 3);

        switch (number)
        {
            case 1:
                StartCoroutine(FallAfterPlayerLanding());
                break;
            case 2:
                StartCoroutine(Rotate90DegreesAfterPlayerLanding());
                break;
            case 3:
                spinRoutine = StartCoroutine(Spin());
                break;
        }
    }
}
