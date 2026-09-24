using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSFX : MonoBehaviour

{
    #region variables
    [SerializeField, Tooltip("Add the SFXManager Prefab in prefab/Audio")] private SFXManager sfxManager;
    [SerializeField] private float sfxVolume;

    private float timer;

    private InputManager inputManager;
    private StateMachine stateMachine;
    private CharacterController controller;
    #endregion

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        stateMachine = GetComponent<StateMachine>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Timer counting up from zero
        timer += Time.deltaTime;
        // HandlePlayerSFX();
    }

    /*private void HandlePlayerSFX()
    {
        // If the player is not running, crouching and not standing still, play the walking sounds
        if (!inputManager.IsSprinting && !inputManager.IsJumping && !inputManager.IsCrouching )
        {
            clipLength = SFXManager.Instance.GetClipLength(SFXManager.Instance.GetAudioClip("Step"));

            // Marked the below if-statement to avoid to hear the walking steps until the above if-statement is working

            /*
            // If the timer is more or equal to the length of the current clip, play the next sound
            if (timer >= clipLength)
            {
                // Play sounds that contains the relevant terms, ie "running" or "breathing"
                SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("Step"), transform, sfxVolume);

                // Resets timer so that the AudioClip can be played again
                timer = 0f;
            }
            
        }
        
        // If the Player is sprinting
        else if (inputManager.IsSprinting)
        {                
            float clipLength = SFXManager.Instance.GetClipLength(SFXManager.Instance.GetAudioClip("Breathing"));

            // If the timer is more or equal to the length of the current clip, play the next sound
            if (timer >= clipLength)
            {
                // Play sounds that contains the relevant terms, ie "running" or "breathing"
                SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("Breathing"), transform, sfxVolume);
                
                // Resets timer so that the AudioClip can be played again
                timer = 0f;
            }
        }

        // else if (Player sliding)

        // else if (Player jumping)

        // else if (Player wall running)

    }*/

    public void PlayerWalkEnter()
    {
        float clipLength = SFXManager.Instance.GetClipLength(SFXManager.Instance.GetAudioClip("Step"));


        if (timer >= clipLength)
        {
            // Play sounds that contains the relevant terms, ie "running" or "breathing"
            SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("Step"), transform, sfxVolume);

            // Resets timer so that the AudioClip can be played again
            timer = 0f;        
        }
    }

    public void PlayerWalkExit()
    {
        SFXManager.Instance.StopAudio(SFXManager.Instance.GetAudioClip("Step"));
    }

    public void PlayerRun()
    {
        /*
        float clipLength = SFXManager.Instance.GetClipLength(SFXManager.Instance.GetAudioClip("Breathing"));

        if (timer >= clipLength)
        {
            // Play sounds that contains the relevant terms, ie "running" or "breathing"
            SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("Breathing"), transform, sfxVolume);

            // Resets timer so that the AudioClip can be played again
            timer = 0f;
        }
        */

        SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("Breathing"), transform, sfxVolume);

    }

    public void PlayerEnterJump()
    {
        SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("Step"), transform, sfxVolume);
    }

    public void PlayerExitJump()
    {
        SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("JumpExit"), transform, sfxVolume);
    }
}
