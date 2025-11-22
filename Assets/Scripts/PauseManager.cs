using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    
    bool isPaused = false;
    InputAction pauseAction;

    void Start()
    {
        pauseAction = InputSystem.actions.FindAction("Pause");

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }

    void Update()
    {
        if (pauseAction != null && pauseAction.WasPressedThisFrame())
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
