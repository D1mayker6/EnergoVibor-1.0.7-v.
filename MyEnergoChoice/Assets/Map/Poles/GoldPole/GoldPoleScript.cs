using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GoldPoleScript : MonoBehaviour
{
    [SerializeField] private GameObject[] players = new GameObject[6];
    [SerializeField] private map map;
    [SerializeField] private Light2D GoldLight;
    [SerializeField] private BoxCollider2D ColliderGoldCard;
    private Animator AnimCard;
    [SerializeField] private Text MessageText;
    [SerializeField] private GameObject CubesButton;
    private map mapp;
    bool IsClicked;
    [SerializeField] private Camera Camera;
    private camera_moving cam;
    [SerializeField] private GameObject PauseManager;
    private PauseScript pause;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = ColliderGoldCard.gameObject.GetComponent<AudioSource>();
        audioSource.volume = GameData.SFXVolume;
        pause = PauseManager.GetComponent<PauseScript>();
        cam = Camera.GetComponent<camera_moving>();
        IsClicked = false;
        mapp = CubesButton.GetComponent<map>();
        AnimCard = ColliderGoldCard.gameObject.GetComponent<Animator>();
        AnimCard.enabled = false;

    }
    void Update()
    {
        if (Vector2.Distance(players[GameData.currentPlayer].transform.position, this.transform.position) < 0.01f
            && map.PlayerPositions[GameData.currentPlayer] == Convert.ToInt32(this.gameObject.name))
        {
            
            players[GameData.currentPlayer].GetComponent<Animator>().SetTrigger("MoveEnd");
            if (GameData.GoldCardOpenedCount[GameData.currentPlayer] < 1)
            {
                map.DicesLight.SetActive(false);
                GoldLight.enabled = true;
            }
            if (GameData.GoldCardOpenedCount[GameData.currentPlayer] < 1) mapp.enabled = false;
            else mapp.enabled = true;
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == ColliderGoldCard.gameObject)
                    {
                        if (GameData.GoldCardOpenedCount[GameData.currentPlayer] < 1)
                        {
                            
                            audioSource.Play();
                            map.enabled = false;
                            Camera.transform.position = cam.CenterPos;
                            cam.enabled = false;
                            pause.enabled = false;
                            for (int i = 0; i < GameData.playerCount; i++)
                            {
                                PlayerPrefs.SetInt("PlayerPositionMap" + i, map.PlayerPositions[i]);
                                PlayerPrefs.SetFloat("PlayerPosX" + i, map.players[i].transform.position.x);
                                PlayerPrefs.SetFloat("PlayerPosY" + i, map.players[i].transform.position.y);
                                PlayerPrefs.SetFloat("PlayerPosZ" + i, map.players[i].transform.position.z);
                                PlayerPrefs.Save();
                            }
                            GoldLight.enabled = false;
                            AnimCard.enabled = true;
                            if (!IsClicked)
                            {
                            AnimCard.SetTrigger("Click");
                                IsClicked = true;
                            }
                            StartCoroutine(GoldCardDrop());
                            
                        }
                        else
                        {
                            MessageText.text = "Вы уже тянули эту карту на поле!";

                        }
                    }
                }
            }
        }
    }
    
    void GoldCard()
    {
        pause.enabled = true;
        cam.enabled = true;
        mapp.enabled = true;
        SceneManager.LoadScene("GoldCard");
    }
    private IEnumerator GoldCardDrop()
    {
        yield return new WaitForSeconds(1f);
        GameData.GoldCardOpenedCount[GameData.currentPlayer]++;

        GoldCard();
    }
}

