using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private String loadScene;
    [SerializeField] private String mainMenu;
    [SerializeField] GameObject gameOverMenuUI;

    public void RestartGame()
    {
        SceneManager.LoadScene(loadScene);
        Time.timeScale = 1.0f;
    }
    
    public void QuitGame()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1.0f;
    }

    public void HandleGameOver()
    {
        //pause time/game
        Time.timeScale = 0f;

        gameOverMenuUI.SetActive(true);

        //enables the cursor and turns it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
