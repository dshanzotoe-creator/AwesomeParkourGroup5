using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(WorldScore))]
public class WorldTimer : MonoBehaviour
{

    public Text timeText;
    private float time;
    [SerializeField] private float timeMax;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    void Update()
    {
        time += Time.deltaTime;
        int timeMaxInMinutes = Mathf.RoundToInt(timeMax/60);
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        if(minutes >= timeMaxInMinutes)
        {
            GetComponent<WorldScore>().SetScore(time);
            SceneManager.LoadScene(0);
        }
    }
}
