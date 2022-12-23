using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnLevelWon = new UnityEvent();

    #region Singleton
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    #endregion

    private int _enemiesCount = 0;
    private int _enemiesDeaths = 0;

    #region Unity Events
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    #endregion

    public void SubscribeTank(Respawn respawn)
    {
        _enemiesCount ++;
        respawn.OnDeath.AddListener(OnDeath_Handler);
    }

    private void OnDeath_Handler(bool arg0)
    {
        _enemiesDeaths ++;
        if (_enemiesCount == _enemiesDeaths)
        {
            OnLevelWon?.Invoke();
            Invoke(nameof(LoadNextLevel), 5f);
        }
    }

    private void LoadNextLevel()
    {
        var indexNextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (indexNextScene >= SceneManager.sceneCountInBuildSettings)
        {
            // If there are no more scenes, load first level, the main menu.
            SceneManager.LoadScene(0);
        }
        else
        {
            // Load next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
