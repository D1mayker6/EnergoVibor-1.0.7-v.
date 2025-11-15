using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BlueCardOpen : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Button OptionButtonA;
    [SerializeField] private Button OptionButtonB;
    [SerializeField] private Button ContinueButton;
    [SerializeField] private Animator AnimButtonA;
    [SerializeField] private Animator AnimButtonB;
    [SerializeField] private Text Question;
    [SerializeField] private Text OptionATextBox, OptionBTextBox;
    [SerializeField] private Text Remark;
    [SerializeField] private Text ContinueText;
    [SerializeField] private GameObject QuestionCard;
    private int QuestionNum;
    string OptionA, OptionB;
    string QuestionText;
    string RemarkText;
    Button CorrectlyOptionButton;
    SpriteRenderer BackSideBlueCard;
    private Animator AnimText;
    private int PressedButtons;
    [SerializeField] private map map;
    private AudioSource audiosource;
    [SerializeField] private AudioClip flipCard, correct, wrong;
    bool NewCard;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = GameData.SFXVolume;
        ContinueButton.enabled = false;
        ContinueButton.image.enabled = false;
        ContinueText.enabled = false;
        anim = GetComponent<Animator>();
        BackSideBlueCard = GetComponent<SpriteRenderer>();
        AnimText = Question.gameObject.GetComponent<Animator>();
        Remark.enabled = false;
    }


    void Update()
    {
        if (GameData.BlueCards.Count >= 35)
        {
            GameData.BlueCards.Clear();
        }
        if (Input.GetMouseButtonDown(0) && GameData.BlueCardAnimCount[GameData.currentPlayer] == 0)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    while (!NewCard)
                    {
                        QuestionNum = Random.Range(1, 36);
                        if (GameData.BlueCards.Contains(QuestionNum))
                        {

                        }
                        else
                        {
                            NewCard = true;
                            GameData.BlueCards.Add(QuestionNum);
                        }
                    }
                    audiosource.clip = flipCard;
                    audiosource.Play();
                    GameData.BlueCardAnimCount[GameData.currentPlayer]++;
                    anim.SetTrigger("ClickCard");
                    StartCoroutine(CreateBlueCard());

                }
            }
        }
    }
    private IEnumerator CreateBlueCard()
        {
            yield return new WaitForSeconds(0.5f);
            BackSideBlueCard.enabled = false;
            Instantiate(
                QuestionCard, new Vector2(-29, 1), Quaternion.Euler(0, 0, 0)
                );
            AnimText.enabled = true;
            AnimText.SetTrigger("ClickText");
            AnimButtonA.SetTrigger("ButtonA");
            AnimButtonB.SetTrigger("ButtonA");
        switch (QuestionNum)
        {
            case 1:
                QuestionText = "№1 Использовать: телевизор или проектор?";
                OptionA = "A. Проектор";
                OptionB = "B. Телевизор";
                RemarkText = "проектор потребляет в среднем 250 ватт, это меньше, чем потребляет" +
                " плазменный телевизор, который при сопоставимой яркости изображения расходует более 400 ватт";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 2:
                QuestionText = "№2 Использовать дома кондиционер или обогреватель?";
                OptionA = "A. Кондиционер";
                OptionB = "B. Обогреватель";
                RemarkText = "в среднем расход кондиционеров в режиме нагрева " +
"составляет 30-60 вт на 1 квадратный метр, а у обогревателей этот показатель составляет 86 вт";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 3:
                QuestionText = "№3 Использовать мультиварки или микроволновую печь (СВЧ)? ";
                OptionA = "A. Мультиварка";
                OptionB = "B. СВЧ";
                RemarkText = "мультиварка прибор многослойный и абсолютно герметичный, поэтому " +
                    "отлично хранит тепло. Значит, непрерывный нагрев ей нужен в начале приготовления " +
                    "блюда, при выходе на рабочую температуру – а потом температура только " +
                    "поддерживается.";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 4:
                QuestionText = "№4 Использовать обычный пылесос или робот-пылесос";
                OptionA = "A. Обычный";
                OptionB = "B. Робот";
                RemarkText = "энергопотребление у роботов-пылесосов достаточно " +
                    "небольшое – примерно 0,6/1 квт/час. Можно смело считать прибор экономичным, так " +
                    "как потребление энергии у обычных пылесосов начинается от 1200 квт/час";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 5:
                QuestionText = "№5 Поставить газовую плиту рядом с посудомоечной машиной или рядом с холодильником?";
                OptionA = "A. Рядом с холодильником";
                OptionB = "B. Рядом с посудомоечной машиной";
                RemarkText = "т.к. тепло от плиты заставляет " +
                    "компрессор работать в интенсивном режиме, в результате в разы повышается расход " +
                    "электроэнергии, прибор быстрее изнашивается и раньше выходит из строя";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 6:
                QuestionText = "№6 Установить теплый пол или радиатор";
                OptionA = "A. Теплый пол";
                OptionB = "B. Радиатор";
                RemarkText = "основным преимуществом теплого пола является его " +
                    "экономичность. При отапливании одного и того же помещения на теплый пол " +
                    "потребуется затратить на 10-20% меньше энергии, чем на радиаторы отопления";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 7:
                QuestionText = "№7 Использовать электрический чайник или обычный?";
                OptionA = "A. Обычный";
                OptionB = "B. Электрический";
                RemarkText = "на кипячение одного литра в электрочайнике уходит 0,11 кВт/ч. Это очень большая цифра";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 8:
                QuestionText = "№8 Устанавливать или не устанавливать защитные шторы на батареях?";
                OptionA = "A. Устанавливать";
                OptionB = "B. Не устанавливать";
                RemarkText = "тепло теряется, даже если радиаторы загораживают не шторы, а тюль";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 9:
                QuestionText = "№9 Готовить пищу при закрытой крышке или готовить пищу без крышки?";
                OptionA = "A. С закрытой";
                OptionB = "B. С открытой";
                RemarkText = "при приготовлении пищи в кастрюле очень важно, " +
                    "чтобы крышка была закрыта(экономится до 40 процентов энергии)";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 10:
                QuestionText = "№10 Ставить посуду на конфорку большую или равную по величине?";
                OptionA = "A. Равную по величине";
                OptionB = "B. Большую по величине";
                RemarkText = "величины конфорки и кухонной посуды должны совпадать, предварительный нагрев снижает" +
                    " время готовки и позволяет использовать остаточное тепло. ";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 11:
                QuestionText = "№11 Подогревать пищу в микроволновой печи или газовой (электрической) плите?";
                OptionA = "A. Электрическая плита";
                OptionB = "B. Микроволновая печь";
                RemarkText = "в микроволновой печи вы можете сэкономить много энергии, используя " +
                    "более разумный подход для нагрева пищи и напитков.";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 12:
                QuestionText = "№12 Брать для нагрева точное необходимое количество воды или количество воды с запасом?";
                OptionA = "A. С запасом";
                OptionB = "B. Необходимое количество";
                RemarkText = "используйте ровно столько воды, " +
                    "сколько вам нужно — любое дополнительное количество потребует больше времени и энергии";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 13:
                QuestionText = "№13 Использовать лампу накаливания или люминесцентную лампу?";
                OptionA = "A. Лампа накаливания";
                OptionB = "B. Люминсцентая лампа";
                RemarkText = "обычная лампа накаливания 92-94% электроэнергии преобразует в тепло и лишь 6-8% — в свет, тогда как компактная " +
                    "люминесцентная лампа, давая такой же световой поток, расходует электроэнергии на 80% меньше";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 14:
                QuestionText = "№14 Использовать алюминиевые кастрюли или кастрюли из нержавейки с медным напылением?";
                OptionA = "A. Алюминиевые кастрюли";
                OptionB = "B. Нержавейки";
                RemarkText = "алюминиевые кастрюли потребляют больше энергии, чем такие же аналоги из нержавейки с медным напылением";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 15:
                QuestionText = "№15 Охлаждать пищу в морозильной камере холодильника с ледяной шубой или без нее?";
                OptionA = "A. С ледяной шубой";
                OptionB = "B. Без ледяной шубы";
                RemarkText = "желательно регулярно производить размораживание морозильной камеры, ведь толстый ледяной слой" +
                    " на стенках заставляет холодильник затрачивать больше энергии";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 16:
                QuestionText = "№16 Гладить сыроватое белье или сухое? ";
                OptionA = "A. Сыроватое";
                OptionB = "B. Сухое";
                RemarkText = "белье при глажке должно быть слегка сыровато, так как оно быстрей и легче гладится, а значит, экономится электроэнергия";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 17:
                QuestionText = "№17 Клеить на стены светлые обои или темные? ";
                OptionA = "A. Светлые";
                OptionB = "B. Темные";
                RemarkText = "лучше оклеивать стены в светлые обои, они отражают свет, что позволит пользоваться естественным освещением большее время";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 18:
                QuestionText = "№18 Пользоваться бытовой техникой класса А или В?";
                OptionA = "A. класс А";
                OptionB = "B. класс B";
                RemarkText = "буква А означает высокий показатель энергоэффективности техники. Маркировку В наносят на приборы с более низким показателем энергоэффективности";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 19:
                QuestionText = "№19 Пользоваться классом техники  В или D?";
                OptionA = "A. класс B";
                OptionB = "B. класс D";
                RemarkText = "класс «В» - расход электроэнергии средний, а класс «D» - потребляемая мощность расходуется не эффективно";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 20:
                QuestionText = "№20 Использовать для просмотра фильмов компьютер или телевизор?";
                OptionA = "A. Компьютер";
                OptionB = "B. Телевизор";
                RemarkText = "телевизор потребляет 45-55 ватт в час во время работы. А компьютер в час потребляет 200 ватт. Поэтому использование телевизора энергоэффективнее";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 21:
                QuestionText = "№21 Устанавливать однотарифный или двухтарифный счетчик?";
                OptionA = "A. Однотарифный";
                OptionB = "B. Двухтарифный";
                RemarkText = "при покупке электронного счетчика можно выбрать двухтарифный прибор. В этом случае регистратор будет считать электроэнергию в зависимости от времени: по дневному или ночному тарифу. Это удобно, потому что стоимость электроэнергии днем и ночью различается";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 22:
                QuestionText = "№22 Нагревать воду в электрочайнике с накипью или без нее?";
                OptionA = "A. С накипью";
                OptionB = "B. Без накипи";
                RemarkText = "накипь обладает малой теплопроводностью, поэтому вода в посуде с накипью нагревается медленно, что в итоге происходит потере энергии";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 23:
                QuestionText = "№23 Использовать светодиодную лампу или лампу накаливания?";
                OptionA = "A. Светодиодная лампа";
                OptionB = "B. Лампа накаливания";
                RemarkText = "преимущества светодиодных ламп перед другими типами: длительный срок службы, экономичное использование электроэнергии, безопасность использования, незначительное тепловыделение";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 24:
                QuestionText = "№24 Использовать светодиодную или ртутную лампу?";
                OptionA = "A. Ртутная лампа";
                OptionB = "B. Светодиодная лампа";
                RemarkText = "у светодиодных ламп энергопотребление 50 раз выше, чем у ламп накаливания.";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 25:
                QuestionText = "№25 Ставить еду в холодильник в горячей кастрюле или полностью охлажденной " +
                    "и накрытой крышкой?";
                OptionA = "A. Горячая кастрюля";
                OptionB = "B. Холодная накрытая кастрюля";
                RemarkText = "теплая или горячая еда «напрягает» холодильник и заставляет его потреблять больше электроэнергии. Помимо этого," +
                    " из-за теплых продуктов в холодильнике может собираться влажность и образовывать «ледяную шубу».";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 26:
                QuestionText = "№26 Выключить на ночь холодильник или компьютер?";
                OptionA = "A. Холодильник";
                OptionB = "B. Компьютер";
                RemarkText = "когда мы отключаем электроприборы на ночь, мы экономим много электроэнергии. И только холодильник не нужно выключать на ночь.";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 27:
                QuestionText = "№27 Купить телевизор с диагональю экрана 55 дюйм или 45 дюймов?";
                OptionA = "A. 55 дюймов";
                OptionB = "B. 45 дюймов";
                RemarkText = "чем больше телевизор, тем больше электроэнергии он потребляет. Особенно плазменные телевизоры потребляют большое количество энергии из-за своего размера";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 28:
                QuestionText = "№28 Оставить телевизор в дежурном режиме или отключить от источника питания?";
                OptionA = "A. Дежурный режим";
                OptionB = "B. Отключить от питания";
                RemarkText = "очень удобно выключать все с помощью пульта. Но тогда электроприборы потребляют электроэнергию. Поэтому лучше всего выключать все из розетки";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 29:
                QuestionText = "№29 Использовать аппаратуру класса энергоэффективности А или «эконом»?";
                OptionA = "A. Эконом";
                OptionB = "B. Энергоэффективность A";
                RemarkText = "приобретая бытовую технику, обращайте внимание на класс ее энергоэффективности. Наиболее энергоэффективным является класс «а», далее поубыванию: b, c, d...Класса Эконом не существует";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 30:
                QuestionText = "№30 Поставить холодильник вблизи или вдали от плиты?";
                OptionA = "A. Вблизи";
                OptionB = "B. Вдали";
                RemarkText = "холодильник использует электроэнергию, чтобы охлаждать содержимое. Чем теплее, тем больше электроэнергии потребляет холодильник. Его охладительные элементы должны оставаться открытыми и возле них не должны находиться электроприборы, выделяющие тепло";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 31:
                QuestionText = "№31 Размораживать продукты в комнате или в холодильнике?";
                OptionA = "A. В холодильнике";
                OptionB = "B. В комнате";
                RemarkText = "в комнате продукты размораживаются, не потребляя электроэнергии. Но размораживание продуктов в холодильнике – хороший совет по энергосбережению. Холодильник использует холод продуктов и поэтому сам может производить меньше холода. Но размораживание длится, конечно же, немного дольше";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 32:
                QuestionText = "№32 Какой необычный способ сохранения тепла в доме поможет предотвратить " +
                    "потери энергии, защитить от сквозняков или частично изолировать комнату?";
                OptionA = "A. Частично изолировать комнату";
                OptionB = "B. Защитить от сквозняков";
                RemarkText = "окна с двойным остеклением также не всегда способны удержать тепло в доме. Даже небольшое падение температуры, до 14 °с, приведет к потерям энергии примерно в 50-100 вт на квадратный метр. Лучший способ предотвратить такую резкую потерю накопленного тепла – закрыть шторы сразу после заката.";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
                Question.text = QuestionText;
                break;
            case 33:
                QuestionText = "№33 Устанавливать ли датчики движения на свет?";
                OptionA = "A. Нет";
                OptionB = "B. Да";
                RemarkText = "установка датчиков движения может снизить расход электроэнергии на освещение на 30-80%.";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 34:
                QuestionText = "№34 Если батареи греют слишком сильно необходимо открыть форточку или " +
                    "закрыть батареи одеялами?";
                OptionA = "A. Открыть форточку";
                OptionB = "B. Закрыть батареии одеялами";
                RemarkText = "плоскости конструкции можно укутать старым одеялом или несколькими толстыми пледами. Чем меньше тепла станет излучать радиатор, тем быстрее снизится градус";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonB;
                Question.text = QuestionText;
                break;
            case 35:
                QuestionText = "№35 Пройти одну остановку пешком или проехать на автобусе?";
                OptionA = "A. Пройти пешком";
                OptionB = "B. Проехать на автобусе";
                RemarkText = "если пройти пешком ни каких затрат электрической энергии не будет";
                Remark.text = "Примечание: " + RemarkText;
                OptionATextBox.text = OptionA;
                OptionBTextBox.text = OptionB;
                CorrectlyOptionButton = OptionButtonA;
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
                StartCoroutine(ContinueCoroutine());
                GameData.Energiks[GameData.currentPlayer] += 1;
                pressedButton.image.color = Color.green;
                Remark.enabled = true;
                StartCoroutine(LoadMap());
            }
            else
            {
                audiosource.clip = wrong;
                audiosource.Play();
                StartCoroutine(ContinueCoroutine());
                GameData.Energiks[GameData.currentPlayer] -= 1;
                CorrectlyOptionButton.image.color = Color.green;
                pressedButton.image.color = Color.red;
                Remark.enabled = true;
                StartCoroutine(LoadMap());
            }
        }
    }
    IEnumerator LoadMap()
    {
        
        yield return new WaitForSeconds(10);
        do
        {
            GameData.currentPlayer = (GameData.currentPlayer + 1) % GameData.playerCount;
        } while (GameData.LosePlayers.Contains(GameData.currentPlayer));
        PressedButtons = 0;
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
        do
        {
            GameData.currentPlayer = (GameData.currentPlayer + 1) % GameData.playerCount;
        } while (GameData.LosePlayers.Contains(GameData.currentPlayer));

        PressedButtons = 0;
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

