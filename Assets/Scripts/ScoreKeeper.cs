using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;

    int score = 0;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int scoreToAdd)
    {
        score += scoreToAdd;
        score = Mathf.Clamp(score, 0, int.MaxValue);
        print(score);
    }

    public void ResetScore()
    {
        score = 0;
        kills = 0;
        finalScore = 0;
    }

    int kills = 0;

    public void IncrementKills()
    {
        kills++;
    }

    public int GetKills()
    {
        return kills;
    }

    int finalScore = 0;

    public void SetFinalScore(int score)
    {
        finalScore = score;
    }

    public int GetFinalScore()
    {
        return finalScore;
    }
}
