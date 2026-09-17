using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioSource sfxObject;

    public float clipLength;
    public float timer = 0f;

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

    private void Update()
    {
        timer += Time.deltaTime;
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

    public void PlayRandomSFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        if (timer >= clipLength)
        {
            // Assign a random index
            int rand = Random.Range(0, audioClip.Length);

            // Slightly changes the pitch of the random sound to create variety
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);

            // Spawn in gameObject
            AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);

            // Assign audioClip randomly selected thanks to the int rand above
            audioSource.clip = audioClip[rand];

            // Assign random pitch to played audioClip
            audioSource.pitch = randomPitch;

            // Assign volume
            audioSource.volume = volume;

            // Play sound, might change from PlayOneShot to just Play() in the future since the if-statement theoretically stops all the sounds from playing at once
            audioSource.PlayOneShot(audioSource.clip);

            // Changes clipLength to the length of the audioSource
            clipLength = audioSource.clip.length;

            // Destroy SFX after it's done playing
            Destroy(audioSource.gameObject, clipLength);

            timer = 0f;
        }
    }
}
