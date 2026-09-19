using NUnit.Framework;
using UnityEngine;

public class PlayerSFX : MonoBehaviour

{

    float timer;
    float clipLength;

    [SerializeField] private SFXManager sfxManager;
    private InputManager inputManager;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Timer counting up from zero
        timer =+ Time.deltaTime;
        handlePlayerSFX();
    }

    private void handlePlayerSFX()
    {
        // If the Player is sprinting
        if (inputManager.IsSprinting == true)
        {
            // If the timer is more or equal to the length of the current clip, play the next clip

            //if (timer >= sfxManager.GetClipLength)
            //{

            //}

            // If-statement if
            
            // Play sounds that contains the relevant terms, ie "running" or "breathing"
        }
    }

}
