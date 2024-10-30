using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image _red, _yellow, _blue,_firstColor,_secondColor;
    [SerializeField] RectTransform _mixModeUI;

    private void Awake()
    {
        _mixModeUI.gameObject.SetActive(false);
    }
    private void Start()
    {
        Observer.AddListeners(CONSTANTS.ChooseColor_ACTION, onChooseColor);
        Observer.AddListeners(CONSTANTS.SetMixMode_ACTION, onSetMixMode);
        Observer.AddListeners(CONSTANTS.SetMixColor_ACTION, onSetMixColor);
    }

    

    private void OnDestroy()
    {
        Observer.RemoveListeners(CONSTANTS.ChooseColor_ACTION, onChooseColor);
        Observer.RemoveListeners(CONSTANTS.SetMixMode_ACTION, onSetMixMode);
        Observer.RemoveListeners(CONSTANTS.SetMixColor_ACTION, onSetMixColor);
    }

    private void onSetMixColor(object[] datas)
    {
        
        string firstColorTag = datas[0] == null ? "null": (string)datas[0];
        string secondColorTag = datas[1] == null ? "null" : (string)datas[1];
        Debug.Log(firstColorTag + " " + secondColorTag);

        _firstColor.color = GetColorByTag(firstColorTag);
        _secondColor.color = GetColorByTag(secondColorTag);
    }

    private Color GetColorByTag(string colorTag)
    {
        return colorTag switch
        {
            CONSTANTS.RED_TAG => CONSTANTS.RED_COLOR,
            CONSTANTS.YELLOW_TAG => CONSTANTS.YELLOW_COLOR,
            CONSTANTS.BLUE_TAG => CONSTANTS.BLUE_COLOR,
            _ => CONSTANTS.NULL_COLOR
        };
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