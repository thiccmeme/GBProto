using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string loadScene;
    public void StartGame()
    {
        SceneManager.LoadScene(loadScene);
    }
}
