using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;


public class SkinsManager : MonoBehaviour
{
    [SerializeField] private Image[] SkinVarPlayer;
    [SerializeField] private Sprite[] skins; 
    [SerializeField] private Button CubesButton;
    [SerializeField] private Button GoToMapButton;
    [SerializeField] private Text ConfirmButtonText;
    [SerializeField] private Text P1, P2, P3, P4, P5, P6;
    [SerializeField] private Text GoToMapText;
    private int[] playersCubes = new int[6];
    private int playerCount;
    [SerializeField] private Button[] ButtonsPlus;
    [SerializeField] private Button[] ButtonsMinus;
    [SerializeField] private Text MessageText;
    private int[] SkinOptions= new int[6];
    private AudioSource audioSource;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip dice;
    [SerializeField] private GameObject Begin;
    private bool SkinsConfirm=true;
    public void GoToMap()
    {
        for (int i = 0; i < GameData.playerCount; i++)
        {
            PlayerPrefs.SetInt("PlayerPositionMap" + i, 0);
            PlayerPrefs.SetFloat("PlayerPosX" + i, -64.89f);
            PlayerPrefs.SetFloat("PlayerPosY" + i, -7f);
            PlayerPrefs.SetFloat("PlayerPosZ" + i, 0f);
            PlayerPrefs.SetInt("PlayerPosChange", 0);
            PlayerPrefs.Save();
            GameData.Energiks[i] = 10;
        }
        GameData.LosePlayers.Clear();
        audioSource.clip = click;
        audioSource.Play();
        StartCoroutine(Map());

    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume=GameData.SFXVolume;
        GoToMapText.enabled = false;
        GoToMapButton.enabled = false;
        GoToMapButton.image.enabled = false;
        for (int i = 0; i < GameData.playerCount; i++)
        {
            ButtonsPlus[i].enabled = true;
            ButtonsMinus[i].enabled = true;
        }
        SkinVarPlayer[0].enabled = false;
        SkinVarPlayer[1].enabled = false;
        SkinVarPlayer[2].enabled = false;
        SkinVarPlayer[3].enabled = false;
        SkinVarPlayer[4].enabled = false;
        SkinVarPlayer[5].enabled = false;
        P3.enabled = false;
        P4.enabled = false;
        P5.enabled = false;
        P6.enabled = false;
        CubesButton.enabled = false;
        CubesButton.image.enabled = false;

    }

    private void Update()
    {

        SkinVarPlayer[0].enabled = true;
        SkinVarPlayer[1].enabled = true;
        if ((SkinOptions[0] >= 0) && (SkinOptions[0] < skins.Length))
        {
            SkinVarPlayer[0].sprite = skins[SkinOptions[0]];
        }

        if ((SkinOptions[1] >= 0) && (SkinOptions[1] < skins.Length))
        {
            SkinVarPlayer[1].sprite = skins[SkinOptions[1]];
        }

        if (GameData.playerCount > 2)
        {
            SkinVarPlayer[2].enabled = true;
            P3.enabled = true;
            if ((SkinOptions[2] >= 0) && (SkinOptions[2] < skins.Length))
            {
                SkinVarPlayer[2].sprite = skins[SkinOptions[2]];
            }
        }

        if (GameData.playerCount > 3)
        {
            SkinVarPlayer[3].enabled = true;
            P4.enabled = true;
            if ((SkinOptions[3] >= 0) && (SkinOptions[3] < skins.Length))
            {
                SkinVarPlayer[3].sprite = skins[SkinOptions[3]];
            }
        }

        if (GameData.playerCount > 4)
        {
            SkinVarPlayer[4].enabled = true;
            P5.enabled = true;
            if ((SkinOptions[4] >= 0) && (SkinOptions[4] < skins.Length))
            {
                SkinVarPlayer[4].sprite = skins[SkinOptions[4]];
            }
        }

        if (GameData.playerCount > 5)
        {
            SkinVarPlayer[5].enabled = true;
            P6.enabled = true;
            if ((SkinOptions[5] >= 0) && (SkinOptions[5] < skins.Length))
            {
                SkinVarPlayer[5].sprite = skins[SkinOptions[5]];
            }
        }
    }

    public void SkinOptionPlus(int playerIndex)
    {
        
        if (playerIndex < SkinOptions.Length && SkinOptions[playerIndex] < skins.Length - 1)
        {
            SkinOptions[playerIndex]++;
            audioSource.clip=click;
            audioSource.Play();
        }
    }

    public void SkinOptionMinus(int playerIndex)
    {
        if (playerIndex < SkinOptions.Length && SkinOptions[playerIndex] > 0)
        {
            SkinOptions[playerIndex]--;
            audioSource.clip = click;
            audioSource.Play();
        }
    }

    public void ConfirmSkins(Button PressedButton)
    {
        audioSource.clip = click;
        audioSource.Play();
        SkinsConfirm = true;
        HashSet<Sprite> usedSkins = new HashSet<Sprite>();
        for (int i = 0; i < GameData.playerCount; i++)
        {
            if (SkinVarPlayer[i].sprite != null)
            {
                if (usedSkins.Contains(SkinVarPlayer[i].sprite))
                {
                    SkinsConfirm = false;
                    MessageText.text = "Скины должны быть уникальными!";
                    return;
                }
                usedSkins.Add(SkinVarPlayer[i].sprite);
            }
        }
        if (SkinsConfirm)
        {
            MessageText.text = "Кто будет ходить первым?";
            PressedButton.image.enabled = false;
            PressedButton.enabled = false;
            CubesButton.enabled = true;
            ConfirmButtonText.enabled = false;
            CubesButton.image.enabled = true;
            for (int i = 0;i < 6; i++)
            {
                ButtonsPlus[i].enabled = false;
                ButtonsMinus[i].enabled = false;
            }
            for (int i = 0; i < GameData.playerCount; i++)
            {
                GameData.PlayerSkins[i] = SkinVarPlayer[i].sprite;
            }
        }
    }
    public int RandomCubeNumber()
    {
        return UnityEngine.Random.Range(1, GameData.playerCount+1);
    }
    public void CubesWinner()
    {
        audioSource.clip = dice;
        audioSource.Play();
    GameData.currentPlayer=RandomCubeNumber();
        MessageText.text= "Первым ходит игрок "+Convert.ToString(GameData.currentPlayer);
        GameData.currentPlayer--;
        CubesButton.enabled = false;
        CubesButton.image.enabled=false;
        GoToMapButton.enabled = true;
        GoToMapButton.image.enabled = true;
        GoToMapText.enabled = true;
    }
    public void GoToMenu()
    {
        audioSource.clip = click;
        audioSource.Play();
        StartCoroutine(Menu());
    }
    IEnumerator Menu()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Menu");
    }
    IEnumerator Map()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Map");
    }
}



