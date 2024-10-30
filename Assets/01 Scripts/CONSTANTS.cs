using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CONSTANTS
{
    public static string PLAYER_TAG = "Player";
    public static string ENEMY_TAG = "Enemy";
    public static string ENEMY_LAYER = "Enemy";

    public const string RED_TAG = "Red";
    public const string BLUE_TAG = "Blue";
    public const string GREEN_TAG = "Green";
    public const string YELLOW_TAG = "Yellow";
    public const string PURPLE_TAG = "Purple";
    public const string ORANGE_TAG = "Orange";

    public static Color RED_COLOR = Color.red;
    public static Color BLUE_COLOR = Color.blue;
    public static Color GREEN_COLOR = Color.green;
    public static Color YELLOW_COLOR = Color.yellow;
    public static Color PURPLE_COLOR = new Color(128f / 255f, 0 / 255f, 128f / 255f);
    public static Color ORANGE_COLOR = new Color(255f / 255f, 165f / 255f, 0 / 255f);
    public static Color NULL_COLOR = new Color(255, 255, 255, 70);

    public static string ChooseColor_ACTION = "ChooseColor";
    public static string SetMixMode_ACTION = "SetMixMode";
    public static string SetMixColor_ACTION = "SetMixColor";
}
