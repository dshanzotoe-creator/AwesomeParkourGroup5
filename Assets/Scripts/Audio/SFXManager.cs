using UnityEditor.Timeline.Actions;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }
    [SerializeField] private AudioSource sfxObject;
    [SerializeField] private AudioClip[] audioClips;

    private void Awake()
    {        
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    { 
        // Spawn in gameObject
        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);

        // Assign audioClip that is being passed in above
        audioSource.clip = audioClip;

        // Assign volume
        audioSource.volume = volume;

        // Play sound
        audioSource.Play();

        // Get length of SFX
        float clipLength = audioSource.clip.length;

         // Destroy SFX after it's done playing
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlaySFXClipRandomPitch(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        if (audioClip == null) return;

        // Spawn in gameObject
        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);

        // Assign audioClip randomly selected thanks to the int rand above
        audioSource.clip = audioClip;

        // Assign volume
        audioSource.volume = volume;

        // Assign random pitch to played audioClip
        audioSource.pitch = Random.Range(0.95f, 1.05f);

        // Play sound, might change from PlayOneShot to just Play() in the future since the if-statement theoretically stops all the sounds from playing at once
        audioSource.Play();

        // Changes clipLength to the length of the audioSource
        float clipLength = audioSource.clip.length;

        // Destroy SFX after it's done playing
        Destroy(audioSource.gameObject, clipLength);
    }

    public float GetClipLength(AudioClip clip)
    {
        return clip.length;
    }

    public AudioClip GetAudioClip(string clipToPlay)
    {
        foreach (AudioClip clip in audioClips)
        {
            if (clip.name == clipToPlay)
            {
                return clip;
            }
        }
        Debug.Log("No sound found");
        return null;
    }
}
