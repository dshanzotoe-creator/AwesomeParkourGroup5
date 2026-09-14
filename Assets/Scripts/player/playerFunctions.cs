using UnityEngine;

public class playerFunctions : MonoBehaviour
{

    PlayerStats playerStats;
    void awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.CompareTag("HurtBox");
        //trigger the TakeDamage function and set amount here

    }

    private void TakeDamage(float amount)
    {
        playerStats.SetHealth(amount);
    }
}
