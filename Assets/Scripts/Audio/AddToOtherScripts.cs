using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    /*
     ----------------------------------------------------------------------------------------------------------------
        These needs to be added to any relevant script, so that you can add the matching SFX to 
        an array, from which the later lines of code can play random sounds.     
     ----------------------------------------------------------------------------------------------------------------

     * Example:
     * [SerializeField] private AudioClip[] "Matching Action"(ie breathing, walking, running)SFX; 
     * 
     * Player|Running:
     * [SerializeField] private AudioClip[] runningSFX;
     * [SerializeField] private AudioClip[] breathingSFX;
     * 
     * Player|Walking:
     * [SerializeField] private AudioClip[] walkingSFX;
     * 
     * Player|Wall Running:
     * [SerializeField] private AudioClip[] wallRunningSFX;
     * 

     ----------------------------------------------------------------------------------------------------------------        
        Add this script, with the correct Array, to the corresponding action. Makes it so the SFXManager Singleton
        can do it's magic to the sound files in the array.
     ----------------------------------------------------------------------------------------------------------------
     
     * Example:
     * SFXManager.instance.PlayRandomSFXClip("Matching Action"(ie breathing, walking, running)SFX, transform, 1f);      
     * 
     * Player|Running:
     * SFXManager.instance.PlayRandomSFXClip(runningSFX, transform, 1f);
     * SFXManager.instance.PlayRandomSFXClip(breathingSFX, transform, 1f);
     * 
     * Player|Walking:
     * SFXManager.instance.PlayRandomSFXClip(walkingSFX, transform, 1f);
     * 
     * Player|Wall Running:
     * SFXManager.instance.PlayRandomSFXClip(wallRunningSFX, transform, 1f);
      
     ----------------------------------------------------------------------------------------------------------------
        The if-statement checks if there is a SFXManager added to the scene. If a SFXManager is present, the clip plays. 
        If there's no SFXManager, it returns Debug message with instructions how to solve the problem.
     ----------------------------------------------------------------------------------------------------------------
     
     * if (SFXManager.instance != null)
     * {
     *      SFXManager.instance.PlayRandomSFXClip("Matching Action"(ie breathing, walking, running)SFX, transform, 1f);      
     * }
     * 
     * else ()
     * {
     * Debug.Log("SFX manager not added to current scene, go to Prefabs -> Audio and add SFXManager to the hierarchy");
     * }
     * 
     */
}
