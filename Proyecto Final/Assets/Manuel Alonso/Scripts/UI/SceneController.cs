using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Called from button
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;
    }

    // Called from button
    public void ExitGame()
    {
        Debug.Log($"Call to Application Quit");
        Application.Quit();
    }
}
