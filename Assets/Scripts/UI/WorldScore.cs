using UnityEngine;
using UnityEngine.UI;

public class WorldScore : MonoBehaviour
{
    int score;

    [SerializeField] Text currentScore;
    [SerializeField] Text highScoreText;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    private void Update()
    {
        currentScore.text = "Current Score: " + score.ToString();
    }

    public void SetScore(float time)
    {
        score = Mathf.RoundToInt(time * 1000);

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }

    public int ReportScore()
    {
        return score;
    }
}