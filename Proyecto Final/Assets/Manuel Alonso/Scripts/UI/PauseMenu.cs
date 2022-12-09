using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public KeyCode PauseKey = KeyCode.Escape;
    public GameObject PauseMenuGameObject;

    private bool _gamePaused = false;

    private void Start()
    {
        // On load level
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(PauseKey))
        {
            TooglePause();

            if (PauseMenuGameObject != null)
            {
                PauseMenuGameObject.SetActive(!PauseMenuGameObject.activeSelf);
            }
        }
    }

    // Called from button
    public void TooglePause()
    {
        if (_gamePaused)
        {
            Time.timeScale = 1.0f;
            _gamePaused = false;
            Cursor.visible = false;
        }
        else
        {
            Time.timeScale = 0f;
            _gamePaused = true;
            Cursor.visible = true;
        }
    }
}
