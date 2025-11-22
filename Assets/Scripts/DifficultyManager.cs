using UnityEngine;

public enum Difficulty { Easy, Medium, Hard }

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;
    public Difficulty CurrentDifficulty { get; private set; } = Difficulty.Medium;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        CurrentDifficulty = difficulty;
        Debug.Log("Dificuldade selecionada: " + difficulty);
    }

    public float GetDifficultyMultiplier()
    {
        switch (CurrentDifficulty)
        {
            case Difficulty.Easy: return 0.5f;
            case Difficulty.Medium: return 1f;
            case Difficulty.Hard: return 1.5f;
            default: return 1f;
        }
    }
}
