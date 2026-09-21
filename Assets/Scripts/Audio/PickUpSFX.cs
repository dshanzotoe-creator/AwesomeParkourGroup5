using UnityEngine;

public class PickUpSFX : MonoBehaviour
{
    [SerializeField, Tooltip("Add the SFXManager Prefab in prefab/Audio")] private SFXManager sfxManager;
    [SerializeField] private float sfxVolume;


    private void HandlePickUpSFX()
    {
        SFXManager.Instance.PlaySFXClipRandomPitch(SFXManager.Instance.GetAudioClip("PickUpSFX"), transform, sfxVolume);
    }

}
