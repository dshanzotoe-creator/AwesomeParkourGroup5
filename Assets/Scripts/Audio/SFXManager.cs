using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }
    [SerializeField] private AudioSource sfxObject;
    [SerializeField] private AudioClip[] audioClips;
    private float randomPitch;

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

    void Update()
    {
        randomPitch = Random.Range(0.95f, 1.05f);
    }

    public void PlaySFXClipRandomPitch(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        if (audioClip == null) return;

        // Spawn in gameObject
        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        // Assign volume
        audioSource.volume = volume;

        // Assign random pitch to played audioClip
        audioSource.pitch = randomPitch;

        audioSource.Play();

        // Changes clipLength to the length of the audioSource
        float clipLength = audioSource.clip.length;

        // Destroy SFX after it's done playing
        Destroy(audioSource.gameObject, clipLength);
    }
    
    // Method that helps other scripts to receive the current audio clips length
    public float GetClipLength(AudioClip clip)
    {
        float clipLength = clip.length;
        return clipLength;
    }

    // Makes other scripts able to call upon specific SFX depending on the name of the audio clip
    // If there isn't any SFX with the requested name, a debug.log will be sent
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
