using UnityEngine;

public class WorldScore : MonoBehaviour
{
    int score;

    public void SetScore(float time)
    {
        score = Mathf.RoundToInt(time * 1000);
    }

    public int ReportScore()
    {
        return score;
    }
}
