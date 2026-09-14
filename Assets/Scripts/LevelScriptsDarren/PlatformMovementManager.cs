using Unity.VisualScripting;
using UnityEngine;

public class PlatformMovementManager : MonoBehaviour
{
    //Darren Scott
    
    //A short guide on how to use the Movement Manager. 
   



    Vector3 startpos;

    Vector3 centerPoint;

    [SerializeField] float radius = 5;

    [SerializeField] float speed = 2;

    private float currentAngle = 0; 

    [SerializeField] float frequency = 0.85f;

    [SerializeField] float amplitude = 0.6f;



    [Header("Choose between 1-4. Each number gives a different cube movement.")]
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
        number = Mathf.Clamp(number, 1,4);


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

        }
           
    }

    void WaveMovement()
    {
        float newY = startpos.y + Mathf.Cos(Time.time * frequency) * amplitude;

        transform.position = new Vector3(startpos.x, newY, startpos.y);
    }
    void BackAndForthMovement()
    {
        float newY = startpos.y + Mathf.Cos(Time.time * frequency) * amplitude;

        transform.position = new Vector3(startpos.x, startpos.y, newY);
    }

    void SideToSideMovement()
    {
        float newY = startpos.y + Mathf.Cos(Time.time * frequency) * amplitude;

        transform.position = new Vector3(newY, startpos.y, startpos.z);
    }


    void CircularOrbit()
    {
        currentAngle += speed * Time.deltaTime;

        float xOffset = Mathf.Cos(currentAngle) * radius;
        float zOffset = Mathf.Sin(currentAngle) * radius;

        Vector3 newPosition = new Vector3(centerPoint.x + xOffset, centerPoint.y, centerPoint.z + zOffset);

        Vector3 moveDirection = newPosition - transform.position; 
    
        if(moveDirection != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(moveDirection);

        transform.position = newPosition;
    } 
}
