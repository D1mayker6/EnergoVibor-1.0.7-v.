using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class InfoScript : MonoBehaviour
{
    [SerializeField] private VideoClip[] videos;
    [SerializeField] private GameObject VideoPlayerObject;
    int PageNumber=1;
    [SerializeField] private Text PageText;
    [SerializeField] private Text InfoText;
    [SerializeField] private RawImage Video;
    [SerializeField] private Text Title;
    private VideoPlayer VideoPlayer;
    [SerializeField] private Button UP;
    [SerializeField] private Button DOWN;
    private AudioSource audioSource;
    [SerializeField] private GameObject Icon;
    [SerializeField] private GameObject DeveloperText;
    [SerializeField] private GameObject PGEK;


    private void Start()
    {
        PGEK.SetActive(false);
        DeveloperText.SetActive(false);
        Icon.SetActive(false);
        audioSource=GetComponent<AudioSource>();
        audioSource.volume = GameData.SFXVolume;
        VideoPlayer=VideoPlayerObject.GetComponent<VideoPlayer>();
        Title.text = "Правила";
    }
    private void Update()
    {
        PageText.text = Convert.ToString(PageNumber) + "/10";
        switch (PageNumber)
        {
            case 1:
                Video.enabled = true;
                InfoText.text = "В игре участвует от 2 до 6 игроков. Первым ходит игрок, чей номер выпал на кубике. Вначале игры фишки находятся на поле «Вперед к цели»." +
                    " Каждому игроку выдается 10 энергиков. ";
                VideoPlayer.clip=videos[0];
                Title.text = "Правила";
                DOWN.enabled = false;
                DOWN.image.enabled = false;
                break;
            case 2:
                Video.enabled = true;
                InfoText.text = "Игроки по очереди бросают кубик и продвигают свою фишку вперед по игровому полю на столько кружков, сколько очков выпало на кубике." +
                    " При попадании фишки на кружок белого цвета игрок не осуществляет действий в данный ход.";
                VideoPlayer.clip = videos[1];
                Title.text = "Правила";
                DOWN.enabled = true;
                DOWN.image.enabled = true;
                break;
            case 3:
                Video.enabled = true;
                InfoText.text = "Розовый кружок – необходимо сделать ход по стрелке, красный кружок – необходимо пропустить ход," +
                    " голубой кружок – сделать дополнительный ход. ";
                VideoPlayer.clip = videos[2];
                Title.text = "Правила";
                break;
            case 4:
                Video.enabled = true;
                InfoText.text = "Красно-зелёный кружок дает возможность вытянуть карточку действия с красно-зеленой лампочкой, где могут быть ситуации, которые изображены красным или зеленым цветом, что оповещает игрока" +
                    " о воздействии на энергосбережение и приводит его на несколько шагов назад или вперед.";
                VideoPlayer.clip = videos[3];
                Title.text = "Правила";
                break;
            case 5:
                Video.enabled = true;
                InfoText.text = "Синий кружок – игроку предоставляется возможность сделать энерговыбор, для чего он берет верхнюю карточку из колоды с изображением синей лампочки." +
                    " В случае верного ответа – игрок получает 1 энергик, не верного – теряет 1 энергик.";
                VideoPlayer.clip = videos[4];
                Title.text = "Правила";
                break;
            case 6:
                Video.enabled = true;
                InfoText.text = "В случае остановки на серебряном кружке игроку необходимо ответить на вопрос с выбором варианта ответа " +
                    "из колоды с изображением серебряной лампочки. Если выбор ответа правильный игрок получает 3 энергика." +
                    " В случае неправильного ответа игрок теряет 3 энергика.";
                VideoPlayer.clip = videos[5];
                Title.text = "Правила";
                break;
            case 7:
                Video.enabled = true;
                InfoText.text = "При попадании на золотистый кружок игроку предоставляется возможность ответить на супер-вопрос. До вопроса участнику предлагается сделать ставку имеющимися у него энергиками." +
                    "  в случае верного ответа – он их удваивает, не верного – теряет. ";
                VideoPlayer.clip = videos[6];
                Title.text = "Правила";
                break;
            case 8:
                Video.enabled = true;
                InfoText.text = "Если игрок теряет все энергики он досрочно выходит из игры. ";
                VideoPlayer.clip = videos[7];
                Title.text = "Правила";
                UP.enabled = true;
                UP.image.enabled = true;
                break;
            case 9:
                Title.text = "Правила";
                DeveloperText.SetActive(false);
                PGEK.SetActive(false);
                InfoText.enabled = true;
                Video.enabled = true;
                InfoText.text = "Игра заканчивается, когда один из игроков достигает поля, символизирующего седьмую цель «Недорогостоящая" +
                    " и чистая энергия». За это он дополнительно получает 10 энергиков. Производится подсчёт количества энергиков каждого игрока. Победителем является игрок," +
                    " набравший наибольшее количество энергиков.";
                VideoPlayer.clip = videos[8];
                Title.text = "Правила";
                UP.enabled = true;
                UP.image.enabled = true;
                Icon.SetActive(false);
                
                break;
            case 10:
                Title.text = "Об авторе";
                DeveloperText.SetActive(true);
                PGEK.SetActive(true);
                Icon.SetActive(true);
                Video.enabled = false;
                InfoText.enabled = false;
                UP.enabled = false;
                UP.image.enabled = false;
                break;
            default:
                break;
        }
    }
    public void PagePlus()
    {

        audioSource.Play();
    if (PageNumber < 10)
        {
    PageNumber++;
        }
    }
    public void PageMinus()
    {

        audioSource.Play();
        if (PageNumber > 1)
        {
            PageNumber--;
        }
    }
    public void GoToMenu()
    {

        audioSource.Play();
        StartCoroutine(Menu());
    }

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Menu");
    }
    private void OnApplicationQuit()
    {
        PageNumber = 1;
    }
}
