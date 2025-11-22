using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class HighscoreEntry
{
    public int score;
    // public string playerName;
}

[System.Serializable]
public class Highscores
{
    public List<HighscoreEntry> highscoreEntryList;
}

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;
    private List<HighscoreEntry> highscoresList;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighscores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int score)
    {
        HighscoreEntry newEntry = new HighscoreEntry { score = score };
        
        highscoresList.Add(newEntry);

        highscoresList.Sort((x, y) => y.score.CompareTo(x.score));

        if (highscoresList.Count > 5)
        {
            highscoresList.RemoveRange(5, highscoresList.Count - 5);
        }

        SaveHighscores();
    }

    public List<HighscoreEntry> GetHighscores()
    {
        return highscoresList;
    }

    private void SaveHighscores()
    {
        Highscores highscores = new Highscores { highscoreEntryList = highscoresList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private void LoadHighscores()
    {
        string json = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(json);

        if (highscores != null && highscores.highscoreEntryList != null)
        {
            highscoresList = highscores.highscoreEntryList;
        }
        else
        {
            highscoresList = new List<HighscoreEntry>();
        }
    }
}
