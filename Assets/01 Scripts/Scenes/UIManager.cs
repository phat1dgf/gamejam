using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] Image _red, _yellow, _blue,_firstColor,_secondColor, _mixedColor;
    [SerializeField] RectTransform _mixModeUI;
    [SerializeField] Canvas _subMenu;
    [SerializeField] Text _score;
    [SerializeField] int currentScore;
    private void Awake()
    {
        _mixModeUI.gameObject.SetActive(false);
        _subMenu.gameObject.SetActive(false);
    }
    private void Start()
    {
        Observer.AddListeners(CONSTANTS.ChooseColor_ACTION, onChooseColor);
        Observer.AddListeners(CONSTANTS.SetMixMode_ACTION, onSetMixMode);
        Observer.AddListeners(CONSTANTS.SetMixColor_ACTION, onSetMixColor);
        Observer.AddListeners(CONSTANTS.ConfirmColor_ACTION, onConfirmColor);
        Observer.AddListeners(CONSTANTS.NotMixMode_ACTION, onNotMixMode);
        Observer.AddListeners(CONSTANTS.PlayGame_ACTION, onPlayGame);
        Observer.AddListeners(CONSTANTS.DestroyEnemy_ACTION, onDestroyEnemy);
    }

    private void onPlayGame(object[] obj)
    {
        currentScore = 0;
        _score.text = "Score: " + currentScore;
    }

    private void onDestroyEnemy(object[] datas)
    {
        currentScore++;
        _score.text = "Score: " + currentScore;
    }

    private void onConfirmColor(object[] datas)
    {
        string _mixedColoTag = datas[0] == null ? "null" : (string)datas[0];

        _mixedColor.sprite = GetSpriteByTag(_mixedColoTag);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_subMenu.gameObject.activeSelf)
            {
                onPauseGame();
            }
            else
            {
                onResumeGame();
            }
        }
    }
    private void onResumeGame()
    {
        Time.timeScale = 1;
        _subMenu.gameObject.SetActive(false);
    }

    private void onPauseGame()
    {
        Time.timeScale = 0f;
        _subMenu.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Observer.RemoveListeners(CONSTANTS.ChooseColor_ACTION, onChooseColor);
        Observer.RemoveListeners(CONSTANTS.SetMixMode_ACTION, onSetMixMode);
        Observer.RemoveListeners(CONSTANTS.SetMixColor_ACTION, onSetMixColor);
        Observer.RemoveListeners(CONSTANTS.ConfirmColor_ACTION, onConfirmColor);
        Observer.RemoveListeners(CONSTANTS.NotMixMode_ACTION, onNotMixMode);
        Observer.RemoveListeners(CONSTANTS.DestroyEnemy_ACTION, onDestroyEnemy);
        Observer.RemoveListeners(CONSTANTS.PlayGame_ACTION, onPlayGame);
    }

    private void onNotMixMode(object[] obj)
    {
        _mixedColor.sprite = Resources.Load<Sprite>("05 Game Assets/image/button/gray");
    }

    private void onSetMixColor(object[] datas)
    {
        string firstColorTag = datas[0] == null ? "null" : (string)datas[0];
        string secondColorTag = datas[1] == null ? "null" : (string)datas[1];

        _firstColor.sprite = GetSpriteByTag(firstColorTag);
        _secondColor.sprite = GetSpriteByTag(secondColorTag);
    }

    private Sprite GetSpriteByTag(string colorTag)
    {
        string spritePath = colorTag switch
        {
            CONSTANTS.RED_TAG => "05 Game Assets/image/button/red",
            CONSTANTS.YELLOW_TAG => "05 Game Assets/image/button/yellow",
            CONSTANTS.BLUE_TAG => "05 Game Assets/image/button/blue",
            CONSTANTS.ORANGE_TAG => "05 Game Assets/image/button/orange",
            CONSTANTS.GREEN_TAG => "05 Game Assets/image/button/green",
            CONSTANTS.PURPLE_TAG => "05 Game Assets/image/button/purple",
            _ => "05 Game Assets/image/button/gray"
        };
        Sprite sprite = Resources.Load<Sprite>(spritePath);
        return sprite;
    }

    private void onSetMixMode(object[] datas)
    {
        _mixModeUI.gameObject.SetActive((bool)datas[0]);
    }

    private void onChooseColor(object[] datas)
    {
        string weaponColor = (string)datas[0];
        _red.transform.localScale = Vector3.one;
        _blue.transform.localScale = Vector3.one;
        _yellow.transform.localScale = Vector3.one;

        switch (weaponColor)
        {
            case CONSTANTS.RED_TAG:
                _red.transform.localScale = Vector3.one * 1.2f;
                break;
            case CONSTANTS.YELLOW_TAG:
                _yellow.transform.localScale = Vector3.one * 1.2f;
                break;
            case CONSTANTS.BLUE_TAG:
                _blue.transform.localScale = Vector3.one * 1.2f;
                break;
        }
    }

}