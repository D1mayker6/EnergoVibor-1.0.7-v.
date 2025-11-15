using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RGPoleScript : MonoBehaviour
{
    [SerializeField] private GameObject[] players = new GameObject[6];
    [SerializeField] private map map;
    [SerializeField] private Light2D RedGreenLight;
    [SerializeField] private BoxCollider2D ColliderRGCard;
    private Animator AnimCard;
    [SerializeField] private GameObject CubesButton;
    private map mapp;
    private bool isMoving = false;
    private float velocity = 10;
    private int tempPosition;
    private Vector2 nextTarget;
    private int targetPosition;
    [SerializeField] private Text MessageText;
    [SerializeField] private Camera Camera;
    private camera_moving cam;
    [SerializeField] private GameObject PauseManager;
    private PauseScript pause;
    private AudioSource audioSource;
    [SerializeField] private GameObject PinkPoleObject;
    private PinkPoleScript pinkPole;
    private void Start()
    {
        pinkPole = PinkPoleObject.GetComponent<PinkPoleScript>();
        audioSource = ColliderRGCard.gameObject.GetComponent<AudioSource>();
        audioSource.volume = GameData.SFXVolume;
        pause = PauseManager.GetComponent<PauseScript>();
        cam = Camera.GetComponent<camera_moving>();
        mapp = CubesButton.GetComponent<map>();
        AnimCard = ColliderRGCard.gameObject.GetComponent<Animator>();
        AnimCard.enabled = false;

    }
    void Update()
    {
        

        if (Vector2.Distance(players[GameData.currentPlayer].transform.position, this.transform.position) < 0.01f
            && map.PlayerPositions[GameData.currentPlayer] == Convert.ToInt32(this.gameObject.name))
        {
            
            players[GameData.currentPlayer].GetComponent<Animator>().SetTrigger("MoveEnd");
            mapp.enabled = false;
            if ((GameData.RGCardOpenedCount[GameData.currentPlayer] > 0) && (!isMoving))
            {
                tempPosition = map.PlayerPositions[GameData.currentPlayer];
                targetPosition = map.PlayerPositions[GameData.currentPlayer];
                map.PlayerPositions[GameData.currentPlayer] += PlayerPrefs.GetInt("PlayerPosChange", 0);
                
                isMoving = true;
            }
            if (GameData.RGCardOpenedCount[GameData.currentPlayer] < 1)
            {
                map.DicesLight.SetActive(false);
                RedGreenLight.enabled = true;
            }



            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == ColliderRGCard.gameObject)
                    {
                        if (GameData.RGCardOpenedCount[GameData.currentPlayer] < 1)
                        {
                            audioSource.Play();
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

                            AnimCard.enabled = true;
                            RedGreenLight.enabled = false;
                            AnimCard.SetTrigger("Click");
                            GameData.RGCardOpenedCount[GameData.currentPlayer]++;
                            PlayerPrefs.Save();
                            StartCoroutine(RGCardDrop());
                        }
                        else
                        {
                            MessageText.text = "Вы уже тянули эту карту на поле!";
                        }
                    }
                }
            }
        }
        if (isMoving)
        {

            if (!(tempPosition == (map.PlayerPositions[GameData.currentPlayer])))
            {
                map.enabled = false;
                if (targetPosition < map.PlayerPositions[GameData.currentPlayer])
                {
                    nextTarget = map.polesMap[tempPosition + 1].transform.position;
                    players[GameData.currentPlayer].transform.position = Vector3.MoveTowards(players[GameData.currentPlayer].transform.position, nextTarget, Time.deltaTime * velocity);

                    if (Vector2.Distance(players[GameData.currentPlayer].transform.position, nextTarget) < 0.01f)
                    {
                        tempPosition++;
                    }
                }
                else if (targetPosition > map.PlayerPositions[GameData.currentPlayer])
                {
                    map.enabled = false;
                    nextTarget = map.polesMap[tempPosition - 1].transform.position;
                    players[GameData.currentPlayer].transform.position = Vector3.MoveTowards(players[GameData.currentPlayer].transform.position, nextTarget, Time.deltaTime * velocity);

                    if (Vector2.Distance(players[GameData.currentPlayer].transform.position, nextTarget) < 0.01f)
                    {
                        tempPosition--;
                    }
                }

            }
            else
            {
                isMoving = false;
                PlayerPrefs.SetInt("PlayerPosChange", 0);

                if (map.polesMap[map.PlayerPositions[GameData.currentPlayer]].CompareTag("WhitePole"))
                {
                    GameData.GrayCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GrayCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.RGCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.RGCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardAnimCount[GameData.currentPlayer] = 0;
                    map.enabled = true;
                    map.EndMove();
                }
                else if (map.polesMap[map.PlayerPositions[GameData.currentPlayer]].CompareTag("RedPole"))
                {
                    GameData.GrayCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GrayCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.RGCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.RGCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.PlayersMissMove[GameData.currentPlayer] = 1;
                    map.enabled = true;
                    map.EndMove();
                }
                else if (map.polesMap[map.PlayerPositions[GameData.currentPlayer]].CompareTag("CyanPole"))
                {
                    GameData.GrayCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GrayCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.RGCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.RGCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardAnimCount[GameData.currentPlayer] = 0;
                    map.enabled = true;
                }
                else if (map.polesMap[map.PlayerPositions[GameData.currentPlayer]].CompareTag("PinkPole"))
                {
                    GameData.GrayCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GrayCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.RGCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.RGCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardAnimCount[GameData.currentPlayer] = 0;
                }


            }
        }
    }
    void RGCard()
    {
        pause.enabled = true;
        mapp.enabled = true;
        cam.enabled = true;
        SceneManager.LoadScene("RG_Card");
    }
    private IEnumerator RGCardDrop()
    {
        yield return new WaitForSeconds(1f);
        RGCard();
    }

}