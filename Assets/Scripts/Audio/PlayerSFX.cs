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
    }

    public void PlayerWalkEnter()
    {
        // Calls for the length of the clip to be played within this method
        float clipLength = SFXManager.Instance.GetClipLength(SFXManager.Instance.GetAudioClip("Step"));

        // If timer is equal or more than the length of the audio clip, play the audio clip
        // and then reset timer, to stop several sounds to be played at once
        if (timer >= clipLength)
        {
            // Play sounds that contains the relevant terms, ie "running" or "breathing" from the
            // SFX Manager
            SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("Step"), transform, sfxVolume);
            timer = 0f;        
        }
    }

    public void PlayerRunSteps()
    {
        float clipLength = SFXManager.Instance.GetClipLength(SFXManager.Instance.GetAudioClip("Running"));

        if (timer >= clipLength)
        {
            SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("Running"), transform, sfxVolume);
            timer = 0f;
        }
    }

    public void PlayerJumpEnter()
    {
        SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("JumpEnter"), transform, sfxVolume);
    }

    public void PlayerJumpExit()
    {
        SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("JumpExit"), transform, sfxVolume);
    }
}
