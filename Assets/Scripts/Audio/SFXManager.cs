using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioSource sfxObject;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);        // Spawn in gameObject

        audioSource.clip = audioClip;        // Assign audioClip that is being passed in above

        audioSource.volume = volume;        // Assign volume

        audioSource.Play();        // Play sound

        float clipLength = audioSource.clip.length;        // Get length of SFX

        Destroy(audioSource.gameObject, clipLength);        // Destroy SFX after it's done playing
    }

    public void PlayRandomSFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        int rand = Random.Range(0, audioClip.Length);        // Assign a random index

        float randomPitch = Random.Range(lowPitchRange, highPitchRange);        // Slightly changes the pitch of the random sound to create variety

        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);        // Spawn in gameObject

        audioSource.clip = audioClip[rand];        // Assign audioClip randomly selected thanks to the int rand above

        audioSource.volume = volume;        // Assign volume

        audioSource.Play();        // Play sound

        float clipLength = audioSource.clip.length;        // Get length of SFX

        Destroy(audioSource.gameObject, clipLength);        // Destroy SFX after it's done playing
    }
}
