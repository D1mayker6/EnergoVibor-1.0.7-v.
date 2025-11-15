using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GrayCardOpen : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Button OptionButtonA;
    [SerializeField] private Button OptionButtonB;
    [SerializeField] private Button OptionButtonC;
    [SerializeField] private Animator AnimButtonA;
    [SerializeField] private Animator AnimButtonB;
    [SerializeField] private Animator AnimButtonC;
    [SerializeField] private Text Question;
    [SerializeField] private Text OptionATextBox, OptionBTextBox, OptionCTextBox;
    [SerializeField] private GameObject QuestionCard;
    private int QuestionNum;
    string OptionA, OptionB, OptionC;
    string QuestionText;
    Button CorrectlyOptionButton;
    SpriteRenderer BackSideGrayCard;
    private Animator AnimText;
    private int PressedButtons;
    [SerializeField] private map map;
    private AudioSource audiosource;
    [SerializeField] private AudioClip flipCard, correct, wrong;
    bool NewCard;
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume=GameData.SFXVolume;
        anim = GetComponent<Animator>();
        BackSideGrayCard = GetComponent<SpriteRenderer>();
        AnimText = Question.gameObject.GetComponent<Animator>();

    }
    
    void Update()
    {
        if(GameData.GrayCards.Count >= 21)
        {
            GameData.GrayCards.Clear(); 
        }
        if (Input.GetMouseButtonDown(0) && GameData.GrayCardAnimCount[GameData.currentPlayer] ==0)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    while(!NewCard) {
                    QuestionNum = Random.Range(1, 22);
                        if (GameData.GrayCards.Contains(QuestionNum))
                        {

                        }
                        else
                        {
                            NewCard = true;
                            GameData.GrayCards.Add(QuestionNum);
                        }
                    }
                    audiosource.clip = flipCard;
                    audiosource.Play();
            GameData.GrayCardAnimCount[GameData.currentPlayer]++;
                    anim.SetTrigger("ClickCard");
                        StartCoroutine(CreateGrayCard());


                }
            }
        }
    }
    private IEnumerator CreateGrayCard()
    {
        yield return new WaitForSeconds(0.5f);
        BackSideGrayCard.enabled = false;
        Instantiate( 
            QuestionCard,new Vector2(-29,1), Quaternion.Euler(0,0,0)
            );
        AnimText.enabled = true;
        AnimText.SetTrigger("ClickText");
        AnimButtonA.SetTrigger("ButtonA");
        AnimButtonB.SetTrigger("ButtonA");
        AnimButtonC.SetTrigger("ButtonC");
        
        switch (QuestionNum){
            case 1:
                QuestionText = "№1 Объем во сколько тысяч тераватт солнечной энергии ежегодно попадает на нашу планету?";
                OptionA = "A. 150 тыс.";
                OptionB = "B. 173 тыс.";
                OptionC = "C. 200 тыс.";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonB;
                Question.text= QuestionText;
                break;
            case 2:
                QuestionText = "№2 В какой стране есть тюрьмы, в которых заключенным позволяют крутить педали велотренажеров," +
                    " вырабатывая энергию для окрестных деревень? За это им предлагают сокращение срока тюремного заключения.";
                OptionA = "A. Бразилия";
                OptionB = "B. Норвегия";
                OptionC = "C. Америка";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 3:
                QuestionText =
"№3 В какой стране развита утилизация, что приводит к частому импорту из Норвегии мусора для своих энерговырабатывающих мусороперерабатывающих заводов?";
                OptionA = "A. Финляндия";
                OptionB = "B. Швеция";
                OptionC = "C. Китай";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 4:
                QuestionText =
"№4 Какими электростанциями в Швейцарии вырабатывается половина энергии?";
                OptionA = "A. Теплоэлектростанциями";
                OptionB = "B. Гидроэлектростанциями";
                OptionC = "C. Атомными электростанциями";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 5:
                QuestionText =
"№5 Подросток из Малави, который прочитал в библиотечной книге, как построить ветряную мельницу, сделал ветряк и обеспечил свою деревню электроэнергией.";
                OptionA = "A. Никола Тесла";
                OptionB = "B. Уильям Камквамба";
                OptionC = "C. Джеймс Клерк Максвелл";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 6:
                QuestionText =
"№6 Если взять все аккумуляторы на Земле, то они вместе смогут удовлетворить мировую потребность в энергии в течение всего скольких минут?";
                OptionA = "A. 10 минут";
                OptionB = "B. 35 минут";
                OptionC = "C. 5 минут";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 7:
                QuestionText =
"№7 С 70-х годов благодаря какой энергетике было предотвращено почти 2 миллиона смертей в результате снижения загрязнения воздуха?";
                OptionA = "А. Благодаря гидроэнергетике";
                OptionB = "B. Благодаря ядерной энергетике";
                OptionC = "C. Благодаря тепловой энергетике";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 8:
                QuestionText =
"№8 За сколько часов пустыни Земли поглощают больше энергии Солнца, чем все человечество использует на протяжении года? ";
                OptionA = "A. Всего за 3 часа";
                OptionB = "B. Всего за 5 часов";
                OptionC = "С. Всего за 6 часов";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 9:
                QuestionText =
"№9 Как вы думаете, что является одним из основных признаков плохой теплоизоляции дома?";
                OptionA = "A. Отсутствие сосулек на крыше";
                OptionB = "B. Наличие большого количества сосулек на крыше";
                OptionC = "C. Наличие пароизоляции";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 10:
                QuestionText =
"№10 В каком городе России строят дом, лифты в котором будут сами себя обеспечивать электроэнергией:" +
" их оборудуют специальной системой," +
"вырабатывающей электроэнергию при торможении?";
                OptionA = "A. Санкт-Петербург";
                OptionB = "B. Москва";
                OptionC = "C. Краснодар";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 11:
                QuestionText =
"№11 Самым результативным из мероприятий по повышению энергоэффективности многоквартирного дома," +
" что позволяет снизить расход потребления тепловой энергии на отопление и горячее водоснабжение" +
" всего лишь до 15% по сравнению с обычным домом является …?";
                OptionA = "A. Автоматизация систем газоснабжения";
                OptionB = "B. Автоматизация систем вентиляции";
                OptionC = "C. Автоматизация систем регулирования" +
                          " отопления и горячего водоснабжения";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 12:
                QuestionText =
"№12 Что создал Фарадей в 1831 году? Это появилось на 3 года раньше, чем работающий электродвигатель.";
                OptionA = "A. Первые электрические фонарики для елки";
                OptionB = "B. Первый генератор электроэнергии";
                OptionC = "C. Первый детектор лжи";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 13:
                QuestionText =
"№13 Кто запустил электростанцию в 1882 году, которая смогла обеспечить электричеством 85 домов на Перл-Стрит?";
                OptionA = "A. Томас Эдисон";
                OptionB = "B. Иван Павлов";
                OptionC = "C. Александр Столетов";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 14:
                QuestionText =
"№14 Из чего и кем была сделана первая батарея?";
                OptionA = "A. Из чугуна Александром Вольтом";
                OptionB = "B. Из стали с алюминием Александром Вольтом";
                OptionC = "C. Из серебряных монет и цинкового диска Александром Вольтом";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 15:
                QuestionText =
"№15 Какой отец-основатель США изобрел громоотвод. Он создал первую теорию электричества и доказал электрическую природу молнии.";
                OptionA = "A. Бенджамин Франклин";
                OptionB = "B. Никола Тесла";
                OptionC = "C. Энрико Ферми";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 16:
                QuestionText =
"№16 Какая страна является самой энергозатратной на планете";
                OptionA = "A. Китай";
                OptionB = "B. Германия";
                OptionC = "C. Россия";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 17:
                QuestionText =
"№17 В каком году начали отмечать Международный день энергосбережения?";
                OptionA = "A. в 2011";
                OptionB = "B. в 2001";
                OptionC = "C. в 2008";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 18:
                QuestionText =
"№18 Когда празднуется Международный день энергосбережения?";
                OptionA = "A. 11 ноября";
                OptionB = "B. 5 июля";
                OptionC = "C. 9 марта";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 19:
                QuestionText =
"№19 В каком году Джеймс Блайт построил первую ветроэнергетическую установку, которая использовалась для зарядки " +
"аккумуляторов, от которых его коттедж питался электроэнергией?";
                OptionA = "A. 1887 году";
                OptionB = "B. 1883 году";
                OptionC = "C. 1881 году";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 20:
                QuestionText =
"№20 Какой ученый-американец создал первую теорию электричества? Он рассматривает электричество как «нематериальную жидкость», флюид.";
                OptionA = "A. Бенджамин Франклин";
                OptionB = "B. Томас Эдисон";
                OptionC = "C. Бенджамин Томпсон Румфорд";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 21:
                QuestionText =
"№21 21 октября 1879 года американский изобретатель испытал одно из важнейших изобретений 19 века" +
" – электрическую лампочку накаливания. Кто этот за изобретатель?";
                OptionA = "A. Элмер Фридрих";
                OptionB = "B. Питер Купер Хьюитт";
                OptionC = "C. Томас Алва Эдисон";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            default:
                break;
        }
    }

    public void CorrectAnswer(Button pressedButton)
    {
        if (PressedButtons < 1)
        {
            PressedButtons++;
            if (pressedButton == CorrectlyOptionButton)
            {
                audiosource.clip = correct;
                audiosource.Play();
                pressedButton.image.color = Color.green;
                GameData.Energiks[GameData.currentPlayer] += 3;
                StartCoroutine(LoadMap());
            }
            else
            {
                audiosource.clip = wrong;
                audiosource.Play();
                pressedButton.image.color = Color.red;
                CorrectlyOptionButton.image.color= Color.green;
                GameData.Energiks[GameData.currentPlayer] -= 3;

                StartCoroutine(LoadMap());
            }
        }
    }

    IEnumerator LoadMap()
    {
        yield return new WaitForSeconds(1);
        PressedButtons = 0;
        do
        {
            GameData.currentPlayer = (GameData.currentPlayer + 1) % GameData.playerCount;
        } while (GameData.LosePlayers.Contains(GameData.currentPlayer));
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
