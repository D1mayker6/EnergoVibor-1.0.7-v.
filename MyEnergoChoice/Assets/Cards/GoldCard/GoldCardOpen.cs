using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GoldCardOpen : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Button OptionButtonA;
    [SerializeField] private Button OptionButtonB;
    [SerializeField] private Button OptionButtonC;
    [SerializeField] private Button OptionButtonD;
    [SerializeField] private Animator AnimButtonA;
    [SerializeField] private Animator AnimButtonB;
    [SerializeField] private Animator AnimButtonC;
    [SerializeField] private Animator AnimButtonD;
    [SerializeField] private Text Question;
    [SerializeField] private Text OptionATextBox, OptionBTextBox, OptionCTextBox, OptionDTextBox;
    [SerializeField] private GameObject QuestionCard;
    private int QuestionNum;
    string OptionA, OptionB, OptionC, OptionD;
    string QuestionText;
    Button CorrectlyOptionButton;
    SpriteRenderer BackSideGoldCard;
    private Animator AnimText;
    private int PressedButtons;
    [SerializeField] private Canvas BetCanvas;
    private AudioSource audiosource;
    [SerializeField] private AudioClip flipCard, correct, wrong;
    bool NewCard;
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = GameData.SFXVolume;
        anim = GetComponent<Animator>();
        BackSideGoldCard = GetComponent<SpriteRenderer>();
        AnimText = Question.gameObject.GetComponent<Animator>();
        anim.enabled = false;

    }

    void Update()
    {
        if (GameData.GoldCards.Count >= 26)
        {
            GameData.GoldCards.Clear();
        }
        if (BetCanvas.enabled == false)
        {
            anim.enabled = true;
            if (Input.GetMouseButtonDown(0) && GameData.GoldCardAnimCount[GameData.currentPlayer] == 0)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        while (!NewCard)
                        {
                            QuestionNum = Random.Range(1, 27);
                            if (GameData.GoldCards.Contains(QuestionNum))
                            {

                            }
                            else
                            {
                                NewCard = true;
                                GameData.GoldCards.Add(QuestionNum);
                            }
                        }
                        audiosource.clip = flipCard;
                        audiosource.Play();
                        GameData.GoldCardAnimCount[GameData.currentPlayer]++;
                        anim.SetTrigger("ClickCard");
                        StartCoroutine(CreateGoldCard());

                    }
                }
            }
        }
    }

    private IEnumerator CreateGoldCard()
    {
        yield return new WaitForSeconds(0.5f);
        BackSideGoldCard.enabled = false;
        Instantiate(
            QuestionCard, new Vector2(0, 4), Quaternion.Euler(0, 0, 0)
            );
        AnimText.enabled = true;
        AnimText.SetTrigger("ClickText");
        AnimButtonA.SetTrigger("ButtonA");
        AnimButtonB.SetTrigger("ButtonA");
        AnimButtonC.SetTrigger("ButtonC");
        AnimButtonD.SetTrigger("ButtonC");
        switch (QuestionNum) {
            case 1:
                QuestionText = "№1 На что нужно обращать внимание при использовании энергосберегающей лампы?";
                OptionA = "A. На ее яркость";
                OptionB = "B. На ее температуру";
                OptionC = "C. На необходимость специальной утилизации";
                OptionD = "D. На ее срок службы";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 2:
                QuestionText = "№2 Как вы думаете, на сколько накипь в электрочайнике увеличивает расход электроэнергии?";
                OptionA = "A. 5%";
                OptionB = "B. 10%";
                OptionC = "C. 20%";
                OptionD = "D. 30%";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 3:
                QuestionText = "№3 Заполненный мешок для сбора пыли в пылесосе увеличивает расход электроэнергии? Если да, то на сколько %?";
                OptionA = "A. Нет";
                OptionB = "B. 20%";
                OptionC = "C. 30%";
                OptionD = "D. 40%";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonD;
                Question.text = QuestionText;
                break;
            case 4:
                QuestionText = "№4 Что относится к мероприятиям, которые способствуют энергосбережению?";
                OptionA = "A. Использование только ламп накаливания";
                OptionB = "B. Регулярная чистка электроприборов";
                OptionC = "C. Установка датчиков движения";
                OptionD = "D. Круглосуточное освещение помещений";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 5:
                QuestionText = "№5 На ваш взгляд, какой упаковочный материал при производстве потребляет больше всего энергии?";
                OptionA = "A. Бумага";
                OptionB = "B. Пластик";
                OptionC = "C. Стекло";
                OptionD = "D. Алюминиевая фольга";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonD;
                Question.text = QuestionText;
                break;
            case 6:
                QuestionText = "№6 У какого бытового прибора среднестатистический расход электроэнергии за месяц больше, чем у других?";
                OptionA = "A. Телевизор";
                OptionB = "B. Стиральная машина";
                OptionC = "C. Холодильник";
                OptionD = "D. Микроволновая печь";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 7:
                QuestionText = "№7 В большом городе ночью светофоры мигают желтым светом. Мощность одного устройства невелика," +
                    " но в мегаполисе светофоров много. Общая мощность получается немаленькая. С другой стороны, выключать светофор нельзя – он предупреждает редких водителей о том, что впереди перекресток. Как быть?";
                OptionA = "A. Уменьшить яркость мигающего света";
                OptionB = "B. Выключать светофоры по очереди";
                OptionC = "C. Использовать датчики движения для включения светофора";
                OptionD = "D. Ничего не менять";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 8:
                QuestionText = "№8 Как взаимосвязаны уровень жизни общества и количество потребляемой энергии?";
                OptionA = "A. Никак не связаны";
                OptionB = "B. Чем меньше энергии потребляется, тем выше уровень жизни";
                OptionC = "C. Чем больше энергии потребляется, тем выше уровень жизни";
                OptionD = "D. Уровень жизни зависит только от экономических факторов";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 9:
                QuestionText = "№9 Огромные потери тепла происходят на предприятиях, в отапливаемых складах, ангарах через дверные проемы при въезде и выезде автомобилей. Что делать?";
                OptionA = "A. Установить более мощную систему отопления";
                OptionB = "B. Нанять сотрудника для контроля закрытия дверей";
                OptionC = "C. Ограничить въезд и выезд автомобилей";
                OptionD = "D. Использовать автоматические ворота из гибких материалов";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonD;
                Question.text = QuestionText;
                break;
            case 10:
                QuestionText = "№10 Какой стоимости равна средняя стоимость производства кубометра воды?";
                OptionA = "A. Стоимости добычи 1 литра молока";
                OptionB = "B. Стоимости добычи 1 литра бензина";
                OptionC = "C. Стоимости добычи 1 кг угля";
                OptionD = "D. Стоимости добычи 1 м3 газа";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 11:
                QuestionText = "№11 Какая аббревиатура используется для обозначения термина «светодиод»?";
                OptionA = "A. ABC";
                OptionB = "B. LED";
                OptionC = "C. SVD";
                OptionD = "D. LCD";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 12:
                QuestionText = "№12 У какого бытового прибора среднестатистический расход электроэнергии за месяц больше, чем у других?";
                OptionA = "A. Компьютер";
                OptionB = "B. Холодильник";
                OptionC = "C. Телевизор";
                OptionD = "D. Стиральная машина";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 13:
                QuestionText = "№13 Сколько процентов электроэнергии используется впустую, если зарядное устройство для сотового" +
                    " телефона оставлять включенным в сеть?";
                OptionA = "A. 15%";
                OptionB = "B. 35%";
                OptionC = "C. 65%";
                OptionD = "D. 95%";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonD;
                Question.text = QuestionText;
                break;
            case 14:
                QuestionText = "№14 Назовите единицу измерения счётчиков энергии:";
                OptionA = "A. Килоджоуль";
                OptionB = "B. Киловатт-час";
                OptionC = "C. Ватт";
                OptionD = "D. Джоуль";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 15:
                QuestionText = "№15 Среди возобновляемых источников энергии – биогаз. Наиболее эффективно производство биогаза из этого продукта животноводства." +
                    " Из одной тонны его можно получить 10-12 куб. м метана. Что это за продукт, если в древности его называли «батюшкой»?";
                OptionA = "A. Молоко";
                OptionB = "B. Шерсть";
                OptionC = "C. Навоз";
                OptionD = "D. Мясо";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 16:
                QuestionText = "№16 Сколько процентов солнечного света поглощают грязные окна?";
                OptionA = "A. 10%";
                OptionB = "B. 20%";
                OptionC = "C. 30%";
                OptionD = "D. 40%";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 17:
                QuestionText = "№17 Период времени суток, когда населению предоставляется наибольшая скидка за потребление воды:";
                OptionA = "A. Утро";
                OptionB = "B. День";
                OptionC = "C. Вечер";
                OptionD = "D. Такой скидки не существует";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonD;
                Question.text = QuestionText;
                break;
            case 18:
                QuestionText = "№18 Наиболее скрытый источник потерь энергии при использовании электроприборов называется:";
                OptionA = "A. Короткое замыкание";
                OptionB = "B. Неисправность прибора";
                OptionC = "C. Режим ожидания (Stand-by)";
                OptionD = "D. Перегрузка сети";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 19:
                QuestionText = "№19 Каждый год в последнюю субботу марта миллионы людей во всем мире на час выключают свет." +
                    " Как называется эта энергосберегающая акция?";
                OptionA = "A. День Земли";
                OptionB = "B. Час Земли";
                OptionC = "C. Неделя энергосбережения";
                OptionD = "D. Международный день света";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 20:
                QuestionText = "№20 Почему люминесцентные лампы необходимо утилизировать?";
                OptionA = "A. Они быстро перегорают";
                OptionB = "B. Они содержат вредные вещества";
                OptionC = "C. Они потребляют много энергии";
                OptionD = "D. Они занимают много места";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 21:
                QuestionText = "№21 Кого публично Томас Эдисон убивал с помощью тока, чтобы популяризировать постоянный ток?";
                OptionA = "A. Людей";
                OptionB = "B. Животных";
                OptionC = "C. Насекомых";
                OptionD = "D. Растения";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 22:
                QuestionText = "№22 Что (какой фактор) позволяет электрическому сигналу достигать световой скорости?";
                OptionA = "A. Высокое напряжение";
                OptionB = "B. Отсутствие массы у электрического тока";
                OptionC = "C. Специальные материалы проводников";
                OptionD = "D. Магнитное поле";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 23:
                QuestionText = "№23 Какой самый простой способ получить электроэнергию?";
                OptionA = "A. Использовать солнечные батареи";
                OptionB = "B. Построить ветряную электростанцию";
                OptionC = "C. Сжигать уголь";
                OptionD = "D. Использовать гидроэлектростанцию";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonC;
                Question.text = QuestionText;
                break;
            case 24:
                QuestionText = "№24 Мозг человека постоянно производит электроэнергию. Достаточно ли будет нервных импульсов, чтобы запитать лампочку на 10 Вт?";
                OptionA = "A. Нет, не достаточно";
                OptionB = "B. Да, достаточно";
                OptionC = "C. Только на короткое время";
                OptionD = "D. Только при определенных условиях";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 25:
                QuestionText = "№25 Сколько процентов электроэнергии используется впустую, если зарядное устройство для сотового" +
                    " телефона оставлять включенным в сеть?";
                OptionA = "A. 5%";
                OptionB = "B. 15%";
                OptionC = "C. 50%";
                OptionD = "D. 95%";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
                CorrectlyOptionButton = OptionButtonD;
                Question.text = QuestionText;
                break;
            case 26:
                QuestionText = "№26 Какой русский ученый создал первую лампу накаливания?";
                OptionA = "A. Ломоносов";
                OptionB = "B. Менделеев";
                OptionC = "C. Яблочков";
                OptionD = "D. Попов";
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                OptionCTextBox.text = OptionC;
                OptionDTextBox.text = OptionD;
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
                GameData.Energiks[GameData.currentPlayer] += GameData.EnergiksBet;
                StartCoroutine(LoadMap());
            }
            else
            {
                audiosource.clip = wrong;
                audiosource.Play();
                pressedButton.image.color = Color.red;
                CorrectlyOptionButton.image.color = Color.green;
                GameData.Energiks[GameData.currentPlayer] -=GameData.EnergiksBet;

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
