using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RG_CardOpen : MonoBehaviour
{
    [SerializeField] private Button ContinueButton;
    private Animator anim;
    [SerializeField] private Text Question;
    [SerializeField] private GameObject QuestionCard;
    private int QuestionNum;
    string QuestionText;
    SpriteRenderer BackSideRGCard;
    [SerializeField] private Text ContinueText;
    private Animator AnimText;
    [SerializeField] private map map;
    private AudioSource audiosource;
    [SerializeField] private AudioClip flipCard;
    bool NewCard;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = GameData.SFXVolume;
        ContinueButton.enabled = false;
        ContinueButton.image.enabled = false;
        ContinueText.enabled = false;
        anim = GetComponent<Animator>();
        BackSideRGCard = GetComponent<SpriteRenderer>();
        AnimText = Question.gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        if (GameData.RGCards.Count >= 20)
        {
            GameData.RGCards.Clear();
        }
        if (Input.GetMouseButtonDown(0) && GameData.RGCardAnimCount[GameData.currentPlayer] == 0)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    while (!NewCard)
                    {
                        QuestionNum = Random.Range(1, 21);
                        if (GameData.RGCards.Contains(QuestionNum))
                        {

                        }
                        else
                        {
                            NewCard = true;
                            GameData.RGCards.Add(QuestionNum);
                        }
                    }
                    audiosource.clip = flipCard;
                    audiosource.Play();
                    GameData.RGCardAnimCount[GameData.currentPlayer]++;
                    anim.SetTrigger("Click");
                    StartCoroutine(CreateRGCard());

                }
            }
        }
    }
    private IEnumerator CreateRGCard()
    {
        yield return new WaitForSeconds(0.5f);
        BackSideRGCard.enabled = false;
        Instantiate(
            QuestionCard, new Vector2(-29, -5), Quaternion.Euler(0, 0, 0)
            );
        AnimText.enabled = true;
        AnimText.SetTrigger("ClickText");
        switch (QuestionNum)
        {
            case 1:
                QuestionText = "№1. Вы утеплили крыши, стены и установили энергосберегающие окна, что повышает комфорт и достаточно быстро себя окупает. \r\n Сделайте 6 шагов вперед.";
                Question.text = QuestionText;
                Question.color = new Color32(60, 153, 48, 255);
                PlayerPrefs.SetInt("PlayerPosChange", 6);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 2:
                QuestionText = "№2. Применение оборудования и бытовой техники высоких классов энергоэффективности позволяет знатно уменьшить затраты на оплату электроэнергии.\r\nСделайте 3 шага вперед.";
                Question.text = QuestionText;
                Question.color = new Color32(60, 153, 48, 255);
                PlayerPrefs.SetInt("PlayerPosChange", 3);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 3:
                QuestionText = "№3. В коридоре и на кухне, где свет подчас горит круглосуточно, Вы используете компактные люминесцентные лампы.\r\nСделайте 3 шага вперед.";
                Question.text = QuestionText;
                Question.color = new Color32(60, 153, 48, 255);
                PlayerPrefs.SetInt("PlayerPosChange", 3);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 4:
                QuestionText = "№4. В квартире с длинными коридорами вы заменили лампы накаливания на энергосберегающие лампы.\r\nСделайте 5 шагов вперед.";
                Question.text = QuestionText;
                Question.color = new Color32(60, 153, 48, 255);
                PlayerPrefs.SetInt("PlayerPosChange", 5);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 5:
                QuestionText = "№5. Используя передовую осветительную технику (энергосберегающие лампы, осветительные системы) вы экономите до 60% электроэнергии.\r\n Сделайте 4 шага вперед.";
                Question.text = QuestionText;
                Question.color = new Color32(60, 153, 48, 255);
                PlayerPrefs.SetInt("PlayerPosChange", 4);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 6:
                QuestionText = "№6. Вы установили датчики движения и энергосберегающие лампы на лестничных площадках и в подвалах. \r\nСделайте 5 шагов вперед.";
                Question.text = QuestionText;
                Question.color = new Color32(60, 153, 48, 255);
                PlayerPrefs.SetInt("PlayerPosChange", 5);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 7:
                QuestionText = "№7. Вы установили холодильник в самом затененном и прохладном месте квартиры. \r\nСделайте 3 шага вперед.";
                Question.text = QuestionText;
                Question.color = new Color32(60, 153, 48, 255);
                PlayerPrefs.SetInt("PlayerPosChange", 3);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 8:
                QuestionText = "№8. Вы используете алюминиевую фольгу, которая укладывается под ткань, закрывающую гладильную доску. \r\nСделайте 3 шага вперед.";
                Question.text = QuestionText;
                Question.color = new Color32(60, 153, 48, 255);
                PlayerPrefs.SetInt("PlayerPosChange", 3);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 9:
                QuestionText = "№9.  При использовании пылесоса вы часто выбрасываете мусор из контейнера для его сбора," +
                    " промываете или меняете фильтры для входящего и выходящего воздуха, что способствует снижению потребления электроэнергии.\r\nСделайте 4 шага вперед.";
                Question.text = QuestionText;
                Question.color = new Color32(60, 153, 48, 255);
                PlayerPrefs.SetInt("PlayerPosChange", 4);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 10:
                QuestionText = "№10. При нагреве пищи Вы предпочитаете мультиварку другим электрическим приборам. \r\nСделайте 5 шагов вперед";
                Question.text = QuestionText;
                Question.color = new Color32(60, 153, 48, 255);
                PlayerPrefs.SetInt("PlayerPosChange", 5);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 11:
                QuestionText = "№1. Вы попали на старые трубопроводы, протяженность которых в отдельных случаях достигает десятков километров, что приводит к потере до 60 % тепла.\r\nВернитесь на 6 шагов назад.";
                Question.text = QuestionText;
                Question.color = new Color32(184, 26, 26, 255);
                PlayerPrefs.SetInt("PlayerPosChange", -6);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 12:
                QuestionText = "№2. Старые деревянные окна и двери в здании приводят к охлаждению подъездов, что негативно сказывается на энергосбережении домов в целом.\r\nВернитесь на 3 шага назад.";
                Question.text = QuestionText;
                Question.color = new Color32(184, 26, 26, 255);
                PlayerPrefs.SetInt("PlayerPosChange", -3);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 13:
                QuestionText = "№3.  Применяя старое электрооборудование и приборы освещения, вы теряете энергии в несколько раз больше, чем при использовании современных приборов.\r\nСделайте 5 шагов назад.";
                Question.text = QuestionText;
                Question.color = new Color32(184, 26, 26, 255);
                PlayerPrefs.SetInt("PlayerPosChange", -5);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 14:
                QuestionText = "№4. Вы приобрели мощную стиральную машину на 7 килограммов белья для небольшой семьи.\r\nСделайте 4 шага назад.";
                Question.text = QuestionText;
                Question.color = new Color32(184, 26, 26, 255);
                PlayerPrefs.SetInt("PlayerPosChange", -4);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 15:
                QuestionText = "№5. При приготовлении пищи Вы используете посуду, которая не соответствует размерам комфорки, что способствует потере 5-10 процентов энергии.\r\nСделайте 5 шагов назад";
                Question.text = QuestionText;
                Question.color = new Color32(184, 26, 26, 255);
                PlayerPrefs.SetInt("PlayerPosChange", -5);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 16:
                QuestionText = "№6. При приготовлении пищи Вы используете посуду с искривленным дном, которая «ворует» до 40-60 процентов. \r\nСделайте 4 шага назад.";
                Question.text = QuestionText;
                Question.color = new Color32(184, 26, 26, 255);
                PlayerPrefs.SetInt("PlayerPosChange", -4);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 17:
                QuestionText = "№7.  Вы решили постирать только спортивный костюм, неполностью загрузив машину, что перерасходует до 15 процентов энергии. \r\nСделайте 4 шага назад.";
                Question.text = QuestionText;
                PlayerPrefs.SetInt("PlayerPosChange", -4);
                Question.color = new Color32(184, 26, 26, 255);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 18:
                QuestionText = "№8. Вы установили неверную программу стирки, что перерасходует до 30 процентов энергии.\r\nСделайте 3 шага назад.";
                Question.text = QuestionText;
                Question.color = new Color32(184, 26, 26, 255);
                PlayerPrefs.SetInt("PlayerPosChange", -3);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 19:
                QuestionText = "№9. Вы пренебрегаете естественным освещением. Не используете светлые обои и потолки, прозрачные светлые шторы, умеренное количество мебели и цвета в комнате. \r\nСделайте 5 шагов назад.";
                Question.text = QuestionText;
                Question.color = new Color32(184, 26, 26, 255);
                PlayerPrefs.SetInt("PlayerPosChange", -5);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;
            case 20:
                QuestionText = "№10. Вы допустили заполнение контейнера для сбора пыли на 30%, что способствует росту энергопотребления на 40 50%.\r\nСделайте 5 шагов назад.";
                Question.text = QuestionText;
                Question.color = new Color32(184, 26, 26, 255);
                PlayerPrefs.SetInt("PlayerPosChange", -5);
                StartCoroutine(ContinueCoroutine());
                StartCoroutine(CardEnergy());
                break;

            default:
                break;
        }


    }

    public IEnumerator CardEnergy()
    {
        yield return new WaitForSeconds(10);

            SceneManager.LoadScene("Map");

    }
    IEnumerator ContinueCoroutine()
    {
        yield return new WaitForSeconds(3);
        ContinueButton.enabled = true;
        ContinueButton.image.enabled = true;
        ContinueText.enabled = true;
    }
    public void LoadMapFast()
    {
        SceneManager.LoadScene("Map");
    }
    private void OnApplicationQuit()
    {
        for (int i = 0; i < GameData.playerCount; i++)
        {
            PlayerPrefs.SetInt("PlayerPositionMap" + i, 0);
            PlayerPrefs.SetFloat("PlayerPosX" + i, GameData.BeginPlayerPole.x);
            PlayerPrefs.SetFloat("PlayerPosY" + i, GameData.BeginPlayerPole.y);
            PlayerPrefs.SetFloat("PlayerPosZ" + i, GameData.BeginPlayerPole.z);
            PlayerPrefs.Save();
        }
    }
}
