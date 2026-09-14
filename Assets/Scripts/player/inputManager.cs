using UnityEngine;
using UnityEngine.InputSystem;

public class inputManager : MonoBehaviour
{

    private PlayerInput input;
    private InputAction action;
    public static Vector2 Movement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void awake()
    {
        input = GetComponent<PlayerInput>();
    }
    void Start()
    {
        input = GetComponent<PlayerInput>();
        action = input.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        Movement = action.ReadValue<Vector2>();
    }
}
