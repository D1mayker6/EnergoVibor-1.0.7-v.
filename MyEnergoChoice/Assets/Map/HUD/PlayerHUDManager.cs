using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHUDManager : MonoBehaviour
{
    [SerializeField] private Text Energiks;
    [SerializeField] private Text Player;
    [SerializeField] private Text Step;
    [SerializeField] private map map;
    [SerializeField] private Image ImagePlayer;
    void Update()
    {
        ImagePlayer.sprite = GameData.PlayerSkins[GameData.currentPlayer];
        Energiks.text = Convert.ToString(GameData.Energiks[GameData.currentPlayer]);
        Player.text ="Игрок "+ Convert.ToString(GameData.currentPlayer+1)+":";
        Step.text= Convert.ToString(map.step);
    }
    private void OnApplicationQuit()
    {
        for (int i = 0; i < GameData.playerCount; i++)
        {
            PlayerPrefs.SetInt("PlayerPositionMap" + i, 0);
            PlayerPrefs.SetFloat("PlayerPosX" + i, map.polesMap[0].transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY" + i, map.polesMap[0].transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ" + i, map.polesMap[0].transform.position.z);
            PlayerPrefs.SetInt("PlayerPosChange", 0);
            PlayerPrefs.Save();
        }
    }
}
