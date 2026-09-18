using UnityEngine;

public class SpikeDmg : MonoBehaviour
{
    [SerializeField] GameObject deathScreen;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
