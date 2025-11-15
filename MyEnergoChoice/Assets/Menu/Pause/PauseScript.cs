using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private Canvas PauseCanvas;
    private bool isPaused;
    [SerializeField] private map map;
    [SerializeField] private camera_moving cam;
    [SerializeField] private BluePoleScript bluePole;
    [SerializeField] private GrayPoleScript grayPole;
    [SerializeField] private GoldPoleScript goldPole;
    [SerializeField] private RGPoleScript rgpole;
    [SerializeField] private PinkPoleScript pinkpole;
    [SerializeField] private PlayerHUDManager playerHUDManager;
    [SerializeField] private Animator AnimBlueCard;
    [SerializeField] private Animator AnimGrayCard;
    [SerializeField] private Animator AnimGoldCard;
    [SerializeField] private Animator AnimRGCard;
    private void Start()
    {
        AnimBlueCard.enabled = false;
        AnimGrayCard.enabled = false;
        AnimGoldCard.enabled = false;
        AnimRGCard.enabled = false;
        isPaused = false;
        PauseCanvas.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            isPaused = !isPaused;
        }


        if (isPaused)
        {
            PauseCanvas.enabled = true;
            map.enabled = false;
            cam.enabled = false;
            bluePole.enabled = false;
            grayPole.enabled = false;
            goldPole.enabled = false;
            rgpole.enabled = false;
            pinkpole.enabled = false;
            playerHUDManager.enabled = false;
        }
        if (!isPaused)
        {

            PauseCanvas.enabled = false;
            map.enabled = true;
            cam.enabled = true;
            bluePole.enabled = true;
            grayPole.enabled = true;
            goldPole.enabled = true;
            rgpole.enabled = true;
            pinkpole.enabled = true;
            playerHUDManager.enabled = true;
        }
    }
    public void GoToMenu()
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
        SceneManager.LoadScene("Menu");

    }
    public void GoContinue()
    {
        isPaused = false;
    }
    private void OnApplicationQuit()
    {
            PauseCanvas.enabled = false;
            map.enabled = true;
            cam.enabled = true;
            bluePole.enabled = true;
            grayPole.enabled = true;
            goldPole.enabled = true;
            rgpole.enabled = true;
            pinkpole.enabled = true;
            playerHUDManager.enabled = true;
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

