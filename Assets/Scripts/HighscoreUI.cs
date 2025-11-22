using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (HighscoreManager.Instance == null) return;

        List<HighscoreEntry> highscores = HighscoreManager.Instance.GetHighscores();
        highscoreText.text = "Highscores:\n";

        for (int i = 0; i < highscores.Count; i++)
        {
            highscoreText.text += $"{i + 1}. {highscores[i].score}\n";
        }
    }
}
