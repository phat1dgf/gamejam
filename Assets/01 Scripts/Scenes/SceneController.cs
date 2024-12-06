using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;
    public static SceneController Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        if (_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(CONSTANTS.GameScene);
        Observer.Notify(CONSTANTS.PlayGame_ACTION);
    }
    public void MoveToMainMenu()
    {
        SceneManager.LoadScene(CONSTANTS.MainMenuScene);
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
