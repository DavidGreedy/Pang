using System;

public class Score : ListComponent<Score>
{
    private int score;

    public event Action<int> OnScore;

    public int ScoreValue { get { return score; } }

    public void AddScore(int amount)
    {
        score += amount;
        if (OnScore != null)
        {
            OnScore.Invoke(score);
        }
    }
}