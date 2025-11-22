using TMPro;
using UnityEngine;

public class UIWinGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = "FINAL SCORE:\n" + scoreKeeper.GetFinalScore().ToString("000");
    }
}
