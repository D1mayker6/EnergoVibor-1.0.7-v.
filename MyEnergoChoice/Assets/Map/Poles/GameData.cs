using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static class GameData
{

    public static List<int> GrayCards= new List<int>();
    public static List<int> GoldCards= new List<int>();
    public static List<int> BlueCards= new List<int>();
    public static List<int> RGCards= new List<int>();
    public static int PlayerWinner;
    public static Sprite PlayerWinnerSprite;
    public static Sprite[] PlayerSkins = new Sprite[6];
    public static int playerCount = 6;
    public static int currentPlayer = 0;
    public static Vector3 BeginPlayerPole = new Vector3(PlayerPrefs.GetFloat("PlayerBeginPosX", 0),
        PlayerPrefs.GetFloat("PlayerBeginPosY", 0), PlayerPrefs.GetFloat("PlayerBeginPosZ", 0));
    public static int[] GrayCardOpenedCount=new int[6];
    public static int[] GrayCardAnimCount=new int[6];

    public static int[] RGCardOpenedCount = new int[6];
    public static int[] RGCardAnimCount = new int[6];

    public static int[] BlueCardOpenedCount = new int[6];
    public static int[] BlueCardAnimCount = new int[6];

    public static int[] GoldCardOpenedCount = new int[6];
    public static int[] GoldCardAnimCount = new int[6];

    public static int[] PlayersMissMove = new int[6];

    public static int[] Energiks=new int[6] {10,10,10,10,10,10};

    public static int EnergiksBet=5;
    public static List<int> LosePlayers=new List<int>();
    public static float MusicVolume=0.3f;
    public static float SFXVolume = 0.8f;
    public static string SizeLabel="1920x1080";
    public static int DropDownValue = 0;
    public static bool ToggleisOn=true;
}
