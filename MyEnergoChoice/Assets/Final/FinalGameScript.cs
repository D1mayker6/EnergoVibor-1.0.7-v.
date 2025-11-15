using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGameScript : MonoBehaviour
{
    public GameObject[] players = new GameObject[6];
    [SerializeField] private map map;
    [SerializeField] private GameObject CubesButton;
    private map mapp;
    private int WinnerPlayerId=0;
    bool buffed;
    private void Start()
    {
        buffed = false;
        mapp = CubesButton.GetComponent<map>();

        
    }
    void Update()
    {
        if (Vector2.Distance(players[GameData.currentPlayer].transform.position, this.transform.position) < 0.01f)
        {
            if (!buffed)
            {
                GameData.Energiks[GameData.currentPlayer] += 10;
                buffed = true;
            }
            mapp.enabled = false;
            StartCoroutine(LoadFinalGame());
        }
    }
   public IEnumerator LoadFinalGame()
    {
        yield return new WaitForSeconds(2);
        if (!(GameData.playerCount - GameData.LosePlayers.Count <= 1))
        {
            for (int i = 0; i < GameData.playerCount; i++)
            {
                if ((GameData.Energiks[WinnerPlayerId] < GameData.Energiks[i])&& (!GameData.LosePlayers.Contains(i)))
                {
                    WinnerPlayerId = i;
                }
            }

            GameData.PlayerWinner = WinnerPlayerId;
            GameData.PlayerWinnerSprite = players[WinnerPlayerId].GetComponent<SpriteRenderer>().sprite;
        }
        for (int i = 0; i < GameData.playerCount; i++)
        {
            map.PlayerPositions[i] = 0;
            map.players[i].transform.position = GameData.BeginPlayerPole;
            PlayerPrefs.SetInt("PlayerPositionMap" + i, 0);
            PlayerPrefs.SetFloat("PlayerPosX" + i, map.polesMap[0].transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY" + i, map.polesMap[0].transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ" + i, map.polesMap[0].transform.position.z);
            PlayerPrefs.SetInt("PlayerPosChange", 0);
            PlayerPrefs.Save();

        }
            SceneManager.LoadScene("FinalGame");
            GameData.LosePlayers.Clear();
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
    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");
    }
}
