using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    public void LoadGame() 
    {
        StartCoroutine(WaitAndLoad("GameScene", 1f));
        scoreKeeper.ResetScore();
    }

    public void LoadMainMenu() 
    {
        StartCoroutine(WaitAndLoad("MainMenu", 1f));
    }

    public void LoadGameOver() 
    {
        StartCoroutine(WaitAndLoad("GameOver", 1f));
    }

    public void LoadGameWin() 
    {
        StartCoroutine(WaitAndLoad("WinGame", 1f));
    }

    public void SetDifficultyEasy()
    {
        DifficultyManager.Instance.SetDifficulty(Difficulty.Easy);
    }

    public void SetDifficultyMedium()
    {
        DifficultyManager.Instance.SetDifficulty(Difficulty.Medium);
    }

    public void SetDifficultyHard()
    {
        DifficultyManager.Instance.SetDifficulty(Difficulty.Hard);
    }

    public void QuitGame() 
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}


