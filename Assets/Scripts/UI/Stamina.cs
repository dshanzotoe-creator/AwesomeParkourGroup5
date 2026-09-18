using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    PlayerStats stamina;
    [SerializeField] Image staminaBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.fillAmount = stamina.GetStamina();
    }
}
