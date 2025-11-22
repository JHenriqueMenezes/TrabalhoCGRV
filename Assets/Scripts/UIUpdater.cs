using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIUpdater : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Level Info")]
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Slider progressSlider;
    GameWinCondition gameWinCondition;

    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        gameWinCondition = FindFirstObjectByType<GameWinCondition>();
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("000");
        healthSlider.value = playerHealth.GetHealth();

        if (gameWinCondition != null)
        {
            timeText.text = gameWinCondition.GetRemainingTime().ToString("00");
            progressSlider.value = gameWinCondition.GetProgress();
        }
    }
}
