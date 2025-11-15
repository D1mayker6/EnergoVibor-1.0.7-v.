using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
public class map : MonoBehaviour
{
    public GameObject[] players = new GameObject[6];
    public GameObject[] polesMap = new GameObject[5];
    [SerializeField] public GameObject DicesLight;

    public int[] PlayerPositions = new int[6];
    private int[] RedPoles = new int[6]{3,32,54,69,80,95 };
    public int step = 0;
    private int tempPosition;

    private Vector2[] targetPositions = new Vector2[6];

    private float velocity = 10;

    [SerializeField] private Text MessageText;

    public bool isMoving = false;

    AudioSource audioSource;

    [SerializeField] private Light2D[] PlayerLights;

    private PolygonCollider2D DicesLightCollider;

    [SerializeField] FinalGameScript final;

    [SerializeField] private GrayPoleScript GrayPoleScript;

    public Animator DicesLightAnim;

    private void Awake()
    {
        for (int i=0; i<players.Length; i++)
        {
            PlayerLights[i].enabled = false;
        }
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<Renderer>().enabled = false;
        }
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<SpriteRenderer>().sprite = GameData.PlayerSkins[i];
        }

        if (GameData.currentPlayer > 0)
        {
            if (GameData.Energiks[(GameData.currentPlayer - 1) % GameData.currentPlayer] <= 0)
            {
                GameData.LosePlayers.Add((GameData.currentPlayer - 1) % GameData.currentPlayer);
                players[(GameData.currentPlayer - 1) % GameData.currentPlayer].SetActive(false);
            }
        }
        else
        {
            if (GameData.Energiks[5] <= 0)
            {
                GameData.LosePlayers.Add(5);
                players[5].SetActive(false);
            }

        }
        CheckPlayersEnergy();
    }

    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        for (int i = 0; i < GameData.playerCount; i++)
        {
            if (!GameData.LosePlayers.Contains(i))
            {
            players[i].GetComponent<Renderer>().enabled = true;
            }
        }
        PlayerPrefs.SetFloat("PlayerBeginPosX", polesMap[0].transform.position.x);
        PlayerPrefs.SetFloat("PlayerBeginPosY", polesMap[0].transform.position.y);
        PlayerPrefs.SetFloat("PlayerBeginPosZ", polesMap[0].transform.position.z);
        PlayerPrefs.Save();
        Vector3 BeginPlayerPole = new Vector3(polesMap[0].transform.position.x, polesMap[0].transform.position.y, polesMap[0].transform.position.z);
        for (int i = 0; i < GameData.playerCount; i++)
        {
            PlayerPositions[i] = PlayerPrefs.GetInt("PlayerPositionMap" + i);
            players[i].transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX" + i, polesMap[0].transform.position.x),
                PlayerPrefs.GetFloat("PlayerPosY" + i, polesMap[0].transform.position.y), PlayerPrefs.GetFloat("PlayerPosZ" + i, polesMap[0].transform.position.z));
        }
        MessageText.text = "";

        DicesLightAnim=DicesLight.GetComponent<Animator>();
        DicesLightAnim.enabled = false;
        DicesLightCollider=DicesLight.GetComponent<PolygonCollider2D>();
        DicesLight.SetActive(true);
    }
    public int RandomCubeNumber()
    {
        return Random.Range(1,7);
    }

    void Update()   
    {
        Vector2 mousePositionLight = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitLight = Physics2D.Raycast(mousePositionLight, Vector2.zero);
        if (hitLight.collider != null)
        {
            if (hitLight.collider.gameObject == this.gameObject)
            {

                    DicesLightAnim.enabled = true;
            }
        }
            else
            {
                int hashName = DicesLightAnim.GetCurrentAnimatorStateInfo(0).shortNameHash;
                DicesLightAnim.Play(hashName, 0 ,0);
                StartCoroutine(DicesAnimDisabled());
            }


        CheckGameOver();
        for (int i = 0; i < GameData.playerCount; i++)
        {
            if (GameData.currentPlayer == i)
            {
                PlayerLights[i].enabled = true;
            }
            else
            {
                PlayerLights[i].enabled = false;
            }
        }
        if (GameData.LosePlayers.Contains(GameData.currentPlayer))
        {
            EndMove(); 
            return; 
        }

            if (!isMoving)
        {

            if (GameData.PlayersMissMove[GameData.currentPlayer] > 0)
            {
                GameData.PlayersMissMove[GameData.currentPlayer] --;
                EndMove();
                return;
            }

        }
        if ((Input.GetMouseButtonDown(0))&& (!isMoving))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    audioSource.volume = GameData.SFXVolume;
                    audioSource.Play();
                    step = RandomCubeNumber();
                    tempPosition = PlayerPositions[GameData.currentPlayer];
                    PlayerPositions[GameData.currentPlayer] += step;
                    targetPositions[GameData.currentPlayer] = polesMap[PlayerPositions[GameData.currentPlayer]].transform.position;
                    GameData.GrayCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GrayCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.RGCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.RGCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardAnimCount[GameData.currentPlayer] = 0;
                    isMoving = true;
                    players[GameData.currentPlayer].GetComponent<Animator>().SetTrigger("MoveBegin");
                }
            }
        }

        if (isMoving)
        {

            if (!(tempPosition==(PlayerPositions[GameData.currentPlayer])))
            {
                Vector2 nextTarget = polesMap[tempPosition + 1].transform.position;
                players[GameData.currentPlayer].transform.position = Vector3.MoveTowards(players[GameData.currentPlayer].transform.position, nextTarget, Time.deltaTime * velocity);

                if (Vector2.Distance(players[GameData.currentPlayer].transform.position, nextTarget) < 0.01f)
                {
                    tempPosition++;
                }
            }
            else 
            {
                players[GameData.currentPlayer].GetComponent<Animator>().SetTrigger("MoveEnd");
                isMoving = false;
                if (polesMap[PlayerPositions[GameData.currentPlayer]].CompareTag("CyanPole"))
                {
                    MessageText.text = "Дополнительный ход!";
                }
                if (polesMap[PlayerPositions[GameData.currentPlayer]].CompareTag("PinkPole"))
                {
                    isMoving = false;
                }
                if (RedPoles.Contains(PlayerPositions[GameData.currentPlayer]) && GameData.PlayersMissMove[GameData.currentPlayer] == 0)
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

                    EndMove();
                }
                else if (polesMap[PlayerPositions[GameData.currentPlayer]].CompareTag("CyanPole"))
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
                else if ((!polesMap[PlayerPositions[GameData.currentPlayer]].CompareTag("GrayPole"))
                   &&
                   (!polesMap[PlayerPositions[GameData.currentPlayer]].CompareTag("PinkPole"))
                   &&
                   (!polesMap[PlayerPositions[GameData.currentPlayer]].CompareTag("BluePole"))
                   &&
                   (!polesMap[PlayerPositions[GameData.currentPlayer]].CompareTag("GoldPole"))
                    )

                {

                    GameData.GrayCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GrayCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.BlueCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.RGCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.RGCardAnimCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardOpenedCount[GameData.currentPlayer] = 0;
                    GameData.GoldCardAnimCount[GameData.currentPlayer] = 0;
                    EndMove();


                }
                

            }
        }
    }
    private void OnApplicationQuit()
    {
        GameData.LosePlayers.Clear();
        for (int i = 0; i < GameData.playerCount; i++)
        {
            PlayerPrefs.SetInt("PlayerPositionMap" + i, 0);
            PlayerPrefs.SetFloat("PlayerPosX" + i, polesMap[0].transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY" + i, polesMap[0].transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ" + i, polesMap[0].transform.position.z);
            PlayerPrefs.SetInt("PlayerPosChange", 0);
            PlayerPrefs.Save();
        }
    }
    public void EndMove()
    {
        MessageText.text = "";
        do
        {
            GameData.currentPlayer = (GameData.currentPlayer + 1) % GameData.playerCount;
        } while (GameData.LosePlayers.Contains(GameData.currentPlayer));

        
            isMoving = false;
    }

    private void CheckPlayersEnergy()
    {
        for (int i = 0; i < GameData.playerCount; i++)
        {
            if (GameData.Energiks[i] <= 0 && !GameData.LosePlayers.Contains(i))
            {
                GameData.LosePlayers.Add(i);
                players[i].SetActive(false);
            }
        }
    }
    private void CheckGameOver()
    {
        int activePlayers = 0;
        for (int i = 0; i < GameData.playerCount; i++)
        {
            if (!GameData.LosePlayers.Contains(i))
            {
                activePlayers++;
            }
        }

        if (activePlayers <= 1)
        {
            MessageText.text ="Игра окончена!";
            GameData.PlayerWinner = GameData.currentPlayer;
            GameData.PlayerWinnerSprite = players[GameData.currentPlayer].GetComponent<SpriteRenderer>().sprite;
            StartCoroutine(final.LoadFinalGame());
            this.enabled = false;
        }
    }
    IEnumerator DicesAnimDisabled()
    {
        yield return null;
        DicesLightAnim.enabled = false;
    }
}
