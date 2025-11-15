using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class FinalSceneScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject SkyPlayer;
    [SerializeField] private GameObject SpacePlayer;
    [SerializeField] private GameObject StFirstPlace;
    [SerializeField] private GameObject StFirstPlaceSky;
    private Animator  animPlayer;
    private Animator animPlayerSky;
    private Animator animPlayerSpace;
    private Animator FirstPlayerAnim;
    private Animator FirstPlayerSkyAnim;
    [SerializeField] private GameObject SkyBackGround;
    [SerializeField] private GameObject SpaceBackGround;
    [SerializeField] private GameObject[] Clouds;
    [SerializeField] private GameObject Moon;
    [SerializeField] private Canvas GameOverCanvas;
    [SerializeField] private Text GameOver;
    [SerializeField] private Text PlayerWin;
    [SerializeField] private Button BackToMenu;
    void Start()
    {
        for (int i = 0; i < GameData.playerCount; i++)
        {

            GameData.Energiks[i] = 10;
            
        }
        GameData.EnergiksBet = 5;
        Player.GetComponent<SpriteRenderer>().sprite = GameData.PlayerWinnerSprite;
        SkyPlayer.GetComponent<SpriteRenderer>().sprite = GameData.PlayerWinnerSprite;
        SpacePlayer.GetComponent<SpriteRenderer>().sprite = GameData.PlayerWinnerSprite;
        GameOverCanvas.enabled = false;
        Moon.SetActive(false);
        SkyBackGround.SetActive(false);
        SpaceBackGround.SetActive(false);
        Clouds[0].SetActive(false);
        Clouds[1].SetActive(false);
        animPlayer = Player.GetComponent<Animator>();
        animPlayerSky=SkyPlayer.GetComponent<Animator>();
        animPlayerSpace = SpacePlayer.GetComponent<Animator>();
        FirstPlayerAnim = StFirstPlace.GetComponent<Animator>();
        FirstPlayerSkyAnim = StFirstPlaceSky.GetComponent<Animator>();
        StFirstPlaceSky.SetActive(false);
        SkyPlayer.SetActive(false);
        SpacePlayer.SetActive(false);
        StartCoroutine(AnimBeginManager());

    }

    IEnumerator AnimBeginManager()
    {
        yield return new WaitForSeconds(5);
        animPlayer.SetTrigger("GoSky");
        FirstPlayerAnim.SetTrigger("Ended");
        StartCoroutine(AnimSkyManager());
    }
    IEnumerator AnimSkyManager()
    {
        yield return new WaitForSeconds (0.5f);
        SkyBackGround.SetActive (true);
        Clouds[0].SetActive (true);
        Clouds[1].SetActive(true);
        StartCoroutine(AnimSkyManager2());
    }
    IEnumerator AnimSkyManager2()
    {
        yield return new WaitForSeconds(0.5f);
        SkyPlayer.SetActive (true);
        StFirstPlaceSky.SetActive (true);
        StartCoroutine(AnimSpaceManager());
    }

    IEnumerator AnimSpaceManager() 
    {
        yield return new WaitForSeconds(0.5f);
        Clouds[0].SetActive(false);
        Clouds[1].SetActive (false);
        SpaceBackGround.SetActive(true);
        Moon.SetActive(true);
        SpacePlayer.SetActive(true);
        StartCoroutine (AnimSpaceManager2());
    }
    IEnumerator AnimSpaceManager2() 
    {
        yield return new WaitForSeconds(4);
        animPlayerSpace.SetTrigger("inSpace");
        StartCoroutine(AnimSpaceManager3());
    }
    IEnumerator AnimSpaceManager3()
    {
        yield return new WaitForSeconds(3);
        GameOverCanvas.enabled = true;
        GameOver.GetComponent<Animator>().SetTrigger("GameOver");
        PlayerWin.text = "Игрок " + Convert.ToString(GameData.PlayerWinner+1) + " Победил!";
        PlayerWin.GetComponent<Animator>().SetTrigger("playerwin");
        BackToMenu.GetComponent<Animator>().SetTrigger("button");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
