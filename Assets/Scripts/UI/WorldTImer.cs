using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(WorldScore))]
public class WorldTimer : MonoBehaviour
{
    public Text timeText;
    private float time;

    [SerializeField] private float timeMax;

    private WorldScore worldScore;

    void Start()
    {
        worldScore = GetComponent<WorldScore>();

        timeMax = 600;
    }

    void Update()
    {
        time += Time.deltaTime;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        timeText.text = string.Format(
            "{0:00}:{1:00}:{2:000}",
            minutes,
            seconds,
            milliseconds
        );

        float remainingTime = Mathf.Max(0, timeMax - time);

        GetComponent<WorldScore>().SetScore(remainingTime);

        if (time >= timeMax)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Finish()
    {
        float remainingTime = Mathf.Max(0, timeMax - time);

        worldScore.SetScore(remainingTime);

        SceneManager.LoadScene(0);
    }
}