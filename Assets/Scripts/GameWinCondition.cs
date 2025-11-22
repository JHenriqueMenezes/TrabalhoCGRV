using UnityEngine;

public class GameWinCondition : MonoBehaviour
{
    [Header("Win Conditions")]
    [SerializeField] float targetYDistance = 100f;
    [SerializeField] float timeLimit = 60f;
    [SerializeField] int minKills = 5;

    [Header("References")]
    [SerializeField] Transform player;
    
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    
    float timeElapsed;
    bool gameEnded = false;

    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        levelManager = FindFirstObjectByType<LevelManager>();

        if (DifficultyManager.Instance != null)
        {
            switch (DifficultyManager.Instance.CurrentDifficulty)
            {
                case Difficulty.Easy:
                    break;
                case Difficulty.Medium:
                    timeLimit = 45f;
                    minKills = 10;
                    break;
                case Difficulty.Hard:
                    timeLimit = 30f;
                    minKills = 15;
                    break;
            }
        }
    }

    void Update()
    {
        if (gameEnded) return;
        if (player == null) return;

        timeElapsed += Time.deltaTime;

        if (timeElapsed > timeLimit)
        {
            EndGame(false);
            return;
        }

        if (player.position.y >= targetYDistance)
        {
            CheckWinCondition();
        }
    }

    void CheckWinCondition()
    {
        int currentKills = scoreKeeper.GetKills();
        if (currentKills >= minKills)
        {
            EndGame(true);
        }
        else
        {
            EndGame(false);
        }
    }

    void EndGame(bool playerWon)
    {
        gameEnded = true;
        if (playerWon)
        {
            CalculateAndSaveScore();
            levelManager.LoadGameWin();
        }
        else
        {
            levelManager.LoadGameOver();
        }
    }

    void CalculateAndSaveScore()
    {
        float timeRemaining = GetRemainingTime();
        int enemiesDefeated = scoreKeeper.GetKills();
        float difficultyMultiplier = 1f;

        if (DifficultyManager.Instance != null)
        {
            difficultyMultiplier = DifficultyManager.Instance.GetDifficultyMultiplier();
        }

        float pointsPerKill = 100f;
        float pointsPerSecond = 10f;

        float rawScore = ((enemiesDefeated * pointsPerKill) + (timeRemaining * pointsPerSecond)) * difficultyMultiplier;
        int finalScore = Mathf.RoundToInt(rawScore);

        if (HighscoreManager.Instance != null)
        {
            HighscoreManager.Instance.AddScore(finalScore);
        }

        if (scoreKeeper != null)
        {
            scoreKeeper.SetFinalScore(finalScore);
        }
    }

    public float GetRemainingTime()
    {
        return Mathf.Max(0, timeLimit - timeElapsed);
    }

    public float GetProgress()
    {
        if (player == null) return 0;
        return Mathf.Clamp01(player.position.y / targetYDistance);
    }

    public void AddTime(float amount)
    {
        timeElapsed = Mathf.Max(0, timeElapsed - amount);
        Debug.Log($"Time Added: {amount}. New Time Elapsed: {timeElapsed}");
    }
}
