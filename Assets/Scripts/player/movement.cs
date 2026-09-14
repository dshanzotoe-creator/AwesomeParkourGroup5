using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private inputManager inputManager;

    private PlayerStats playerStats;
    
    private Vector2 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputManager = GetComponent<inputManager>();
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.Set(inputManager.Movement.x, inputManager.Movement.y);
        controller.Move(moveDirection * Time.deltaTime * playerStats.GetSpeed());

        Debug.Log(moveDirection);
    }
}
