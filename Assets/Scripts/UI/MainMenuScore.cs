using UnityEngine;

public class MainMenuScore : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI scoreText;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int savedScore = PlayerPrefs.GetInt("HighScore", 0);

        scoreText.text = "High Score: " + savedScore.ToString();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
