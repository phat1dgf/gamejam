using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] Button _mainMenu, _replay;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        _mainMenu.onClick.AddListener(() => SceneController.Instance.MoveToMainMenu());
        _replay.onClick.AddListener(() => SceneController.Instance.PlayGame());
    }

    public void GameOver()
    {
        this.gameObject.SetActive(true);
    }
}
