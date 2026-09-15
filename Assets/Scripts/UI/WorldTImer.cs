using TMPro;
using UnityEngine;

public class WorldTimer : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    private float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    void Update()
    {
        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        if(minutes >= 20)
        {
            Application.Quit();
        }
    }
}
