using NUnit.Framework;
using UnityEngine;

public class PlayerSFX : MonoBehaviour

{


    [SerializeField] private SFXManager sfxManager;
    [SerializeField] private float volume;
    private float timer;
    private float clipLength;

    private InputManager inputManager;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {

        // Timer counting up from zero
        timer += Time.deltaTime;
        HandlePlayerSFX();
    }

    private void HandlePlayerSFX()
    {

        // If the Player is sprinting
        if (inputManager.IsSprinting == true)
        {                
            clipLength = SFXManager.Instance.GetClipLength(SFXManager.Instance.GetAudioClip("Breathing"));

            // If the timer is more or equal to the length of the current clip, play the next sound
            if (timer >= clipLength)
            {
                // Play sounds that contains the relevant terms, ie "running" or "breathing"
                SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("Breathing"), transform, volume);
                
                // Resets timer so that the AudioClip can be played again
                timer = 0f;
            }
        }
    }
}
