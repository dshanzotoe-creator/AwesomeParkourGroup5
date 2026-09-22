using UnityEngine;
using UnityEngine.InputSystem.XR;

public class player : MonoBehaviour
{

    private CharacterController controller;
    private InputManager inputManager;
    private PlayerStats playerStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerStats = GetComponent<PlayerStats>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
