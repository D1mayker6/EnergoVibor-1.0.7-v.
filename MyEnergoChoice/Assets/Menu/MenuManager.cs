using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Canvas ExitCanvas;
    [SerializeField] private Canvas PlayerCountCanvas;
    [SerializeField] private Text CountText;
    [SerializeField] private Button[] Buttons;
    private void Update()
    {
        CountText.text = Convert.ToString(GameData.playerCount);
    }

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        ExitCanvas.enabled = false;
        PlayerCountCanvas.enabled = false;
    }
    public void ExitGame()
    {
        Buttons[3].GetComponent<AudioSource>().Play();
        Buttons[3].GetComponent<AudioSource>().volume = GameData.SFXVolume;
        ExitCanvas.enabled = true;
        for (int i = 0; i < 4; i++)
        {
            Buttons[i].enabled = false;
        }
    }
    public void Play()
    {
        Buttons[0].GetComponent<AudioSource>().Play();
        Buttons[0].GetComponent<AudioSource>().volume = GameData.SFXVolume;
        for (int i = 0; i < 4; i++)
        {
            Buttons[i].enabled=false;
        }
        PlayerCountCanvas.enabled = true;
    }
    public void NoExit()
    {
        Buttons[9].GetComponent<AudioSource>().Play();
        Buttons[9].GetComponent<AudioSource>().volume = GameData.SFXVolume;
        ExitCanvas.enabled = false;
        for (int i = 0; i < 4; i++)
        {
            Buttons[i].enabled = true;
        }
    }
    public void TrueExit()
    {
        Buttons[8].GetComponent<AudioSource>().Play();
        Buttons[8].GetComponent<AudioSource>().volume = GameData.SFXVolume;
        Application.Quit();
    }
    public void PlusCount()
    {
        if (GameData.playerCount < 6)
        {
            Buttons[7].GetComponent<AudioSource>().Play();
            Buttons[7].GetComponent<AudioSource>().volume = GameData.SFXVolume;
            GameData.playerCount++;
        }
    }
    public void MinusCount()
    {
        if (GameData.playerCount > 2)
        {
            Buttons[6].GetComponent<AudioSource>().Play();
            Buttons[6].GetComponent<AudioSource>().volume = GameData.SFXVolume;
            GameData.playerCount--;
        }
    }
    public void Skins()
    {
        Buttons[5].GetComponent<AudioSource>().Play();
        Buttons[5].GetComponent<AudioSource>().volume = GameData.SFXVolume;
        StartCoroutine(GoToSkins());
    }
    IEnumerator GoToSkins()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("SkinsOption");
    }
    public void ExitPlayMenu()
    {
        Buttons[4].GetComponent<AudioSource>().Play();
        Buttons[4].GetComponent<AudioSource>().volume = GameData.SFXVolume;
        PlayerCountCanvas.enabled = false;
        for (int i = 0; i < 4; i++)
        {
            Buttons[i].enabled = true;
        }
    }
    public void Info()
    {
        Buttons[2].GetComponent<AudioSource>().Play();
        Buttons[2].GetComponent<AudioSource>().volume = GameData.SFXVolume;
        StartCoroutine(GoToInfo());
    }
    public void Settings()
    {
        Buttons[1].GetComponent<AudioSource>().Play();
        Buttons[1].GetComponent<AudioSource>().volume = GameData.SFXVolume;
        StartCoroutine(GoToSettings());
    }
    IEnumerator GoToSettings()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Settings");
    }
    IEnumerator GoToInfo()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("GameInfo");
    }
}
