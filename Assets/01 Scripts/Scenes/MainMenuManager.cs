using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button _play, _setting, _tutorial, _exit;
    [SerializeField] Canvas _tutorialCanvas;
    private void Start()
    {
        _play.onClick.AddListener(() => SceneController.Instance.PlayGame());
        _exit.onClick.AddListener(() => SceneController.Instance.ExitGame());
        _tutorial.onClick.AddListener(() => ShowTutorial());

    }
    private void ShowTutorial()
    {
        _tutorialCanvas.gameObject.SetActive(true);
    }
}
