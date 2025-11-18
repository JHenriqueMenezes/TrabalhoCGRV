using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame() 
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() 
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }


}
