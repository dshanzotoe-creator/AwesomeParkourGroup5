using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    /*
     *This needs to be added to any relevant script, so that you can add the matching SFX to an array, from which the later lines of code can play random sounds.
     *
     *[SerializeField] private AudioClip[] "Matching Action"(ie breathing, walking, running)SFX; 
     */


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*
     * Add this script, with the correct Array, to the corresponding action. Makes it so the SFXManager Singleton
     * can do it's magic to the sound files in the array.
     * 
     * SFXManager.instance.PlayRandomSFXClip("Matching Action"(ie breathing, walking, running)SFX, transform, 1f);      
     * 
     * 
     */
}
