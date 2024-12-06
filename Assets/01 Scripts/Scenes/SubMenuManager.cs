using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuManager : MonoBehaviour
{
    [SerializeField] Button _mainMenu, _resume;
    [SerializeField] Canvas _subMenu;

    private void Start()
    {
        
        _mainMenu.onClick.AddListener(()=> SceneController.Instance.MoveToMainMenu());
        _resume.onClick.AddListener(() => onResumeGame());
    }

    private void onResumeGame()
    {
        Debug.Log("ResumeGame");
        Time.timeScale = 1;
        _subMenu.gameObject.SetActive(false);
        
    }

  
}
