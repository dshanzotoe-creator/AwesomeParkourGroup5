using Unity.VisualScripting;
using UnityEngine;

public class PlatformMovementManager : MonoBehaviour
{
   



    Vector3 startpos;

    Vector3 centerPoint;

    [SerializeField] float radius = 5;

    [SerializeField] float orbitSpeed = 2;

    private float currentAngle = 0; 

    [SerializeField] float frequency = 0.85f;

    [SerializeField] float amplitude = 0.6f;



    [Header("Choose between 1-5. Each number gives a different cube movement.")]
    [SerializeField] float movementTypeNumber; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startpos = transform.position;

        if (centerPoint == Vector3.zero)
            centerPoint = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        ChosenMovement(movementTypeNumber);
    }

    void ChosenMovement(float number)
    {
        number = Mathf.Clamp(number, 1,5);


        switch (number)
        {
            case 1:
                WaveMovement();
                break;
            case 2:
                BackAndForthMovement();
                break;
            case 3: 
                SideToSideMovement();
                break;
            case 4:
                CircularOrbit();
                break;
            case 5:
                FerrisWheelOrbit();
                break;

        }
           
    }

    void WaveMovement()
    {
        float newY = startpos.y + Mathf.Cos(Time.time * frequency) * amplitude;

        transform.position = new Vector3(startpos.x, newY, startpos.z);
    }
    void BackAndForthMovement()
    {
        float newZ = startpos.z + Mathf.Cos(Time.time * frequency) * amplitude;

        transform.position = new Vector3(startpos.x, startpos.y, newZ);
    }

    void SideToSideMovement()
    {
        float newX = startpos.x + Mathf.Cos(Time.time * frequency) * amplitude;

        transform.position = new Vector3(newX, startpos.y, startpos.z);
    }


    void CircularOrbit()
    {
        currentAngle += orbitSpeed * Time.deltaTime;

        float xOffset = Mathf.Cos(currentAngle) * radius;
        float zOffset = Mathf.Sin(currentAngle) * radius;

        Vector3 newPosition = new Vector3(centerPoint.x + xOffset, centerPoint.y, centerPoint.z + zOffset);

        Vector3 moveDirection = newPosition - transform.position; 

        transform.position = newPosition;
    } 

    void FerrisWheelOrbit()
    {
        currentAngle += orbitSpeed * Time.deltaTime;
        float xOffset = Mathf.Cos(currentAngle) * radius;
        float yOffset = Mathf.Sin(currentAngle) * radius;
        Vector3 newPosition = new Vector3(centerPoint.x + xOffset, centerPoint.y + yOffset, centerPoint.z);
        Vector3 moveDirection = newPosition - transform.position;
        transform.position = newPosition;
    }
}
