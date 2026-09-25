using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    PickupCounter pickupCounter; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickupCounter = GameObject.Find("PickupCounter").GetComponent<PickupCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickupCounter.ReportRemainingPickups() == 0)
           FinishGame();
        
    }

    void FinishGame()
    {
        SceneManager.LoadScene(0);
    }
}
