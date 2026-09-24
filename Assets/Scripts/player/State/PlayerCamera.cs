using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CameraScript: MonoBehaviour
{
    private InputManager inputManager;


    [SerializeField] Camera camera;




    [Header("Camera")]
    private float lookAngleY = 0f;
    private float lookAngleX = 0f;
    public float nearFoV = 70f;
    public float farFoV = 90f;
    private float lookAngleLimit = 90f;





    


    void Awake()
    {
        inputManager = GetComponent<InputManager>();


    }
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update() 
    {

        HandleCameraMovement();

        
    }



    private void HandleCameraMovement()
    {

        lookAngleY -= inputManager.CameraMovement.y;
        lookAngleX += inputManager.CameraMovement.x;
        lookAngleY = Mathf.Clamp(lookAngleY, -lookAngleLimit, lookAngleLimit);

        camera.transform.localRotation = Quaternion.Euler(lookAngleY,0f,0f);
        camera.transform.rotation = Quaternion.Euler(lookAngleY,lookAngleX, 0);
        
    }


    public void setFoV(float amount)
    {
        if (inputManager.IsSprinting)
        {
            var currentFoV = camera.fieldOfView;
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, farFoV, 0.02f);     
        }
        else
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, nearFoV, 0.05f);
        }
    }









}
