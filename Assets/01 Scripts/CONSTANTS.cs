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

    public static Color RED_COLOR = new Color(180f / 255f, 45f / 255f, 63f / 255f, 1f);
    public static Color BLUE_COLOR = new Color(0f / 255f, 112f / 255f, 224f / 255f, 1f);
    public static Color GREEN_COLOR = new Color(121f / 255f, 180f / 255f, 45f / 255f, 1f);
    public static Color YELLOW_COLOR = new Color(241f / 255f, 194f / 255f, 65f / 255f, 1f);
    public static Color PURPLE_COLOR = new Color(104f / 255f, 45f / 255f, 180f / 255f, 1f);
    public static Color ORANGE_COLOR = new Color(241f / 255f, 130f / 255f, 65f / 255f, 1f);
    public static Color NULL_COLOR = new Color(255, 255, 255, 70);

    public static string ChooseColor_ACTION = "ChooseColor";    
    public static string SetMixMode_ACTION = "SetMixMode";
    public static string SetMixColor_ACTION = "SetMixColor";
    public static string Attack_ACTION = "Attack";
    public static string ConfirmColor_ACTION = "ConfirmColor";
    public static string NotMixMode_ACTION = "NotMixMode";
    public static string DestroyEnemy_ACTION = "DestroyEnemy";
    public static string PlayGame_ACTION = "PlayGame";

    public static string MainMenuScene = "MainMenu";
    public static string GameScene = "GamePlay";
}
