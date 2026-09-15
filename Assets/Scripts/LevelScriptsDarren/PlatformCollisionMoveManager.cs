using System.Collections;
using TreeEditor;
using UnityEngine;

public class PlatformCollisionMoveManager : MonoBehaviour
{

    [SerializeField] float movementTypeNumber = 0;
    Vector3 startPos; 

   [SerializeField] float fallSpeed = 5f; 

    bool moving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !moving)
        {
            Debug.Log("Player has landed on the platform");
            StartCoroutine(FallAfterPlayerLanding());
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

        Destroy(gameObject);
    }

    IEnumerator Rotate90DegreesAfterPlayerLanding()
    {
        float timeBeforeRotation = 1.5f;
        moving = true;
        yield return new WaitForSeconds(timeBeforeRotation);
        float rotationSpeed = 90f; // degrees per second
        float targetRotation = transform.eulerAngles.z + 90f;
        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetRotation)) > 0.1f)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, step);
            yield return null;
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, targetRotation);
    }

}
