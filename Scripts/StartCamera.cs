using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class StartCamera : MonoBehaviour
{
    int[] mass = new int[10];
    int[] mass_2 = new int[9] { 20, 50, 70, 100, 5, 10, 20, 40, 1 };
    private int i, a, Score_Recover, money, step;
    public Text Score, Money, Language, Rating_text, _Rating, Continue, Cubes, Toggle_1, Toggle_2, Toggle_3, Toggle_1_2, Toggle_2_2, textNumber, Exit;
    public GameObject _Panel_Rating, NewScore, Number, Exclamation, GameObject_textNumber, textExclamation, Colors, Panel_Language, Panel_Cubes, Panel_Rating, Panel_Exit, MainCube, Pyramid, Tetrahedron, Octahedron, Icosahedron, Dodecahedron, Cone, Sphere, Thor, Heart;
    private Color white = new Color(1, 1, 1), gray = new Color(0.85f, 0.85f, 0.85f);

    private IEnumerator Wait()
    {
        i = 0;
        money = PlayerPrefs.GetInt("Money");
        PlayerPrefs.SetInt("Money", money + PlayerPrefs.GetInt("MoneyPlay"));
        PlayerPrefs.SetInt("MoneyPlay", 0);
        yield return new WaitForSeconds(0.3f);
        if (PlayerPrefs.GetInt("Sounds") == 0)
            GameObject.Find("MoneySound").GetComponent<AudioSource>().Play();
        while (i == 0)
        {
            yield return new WaitForSeconds(0.01f);
            if (PlayerPrefs.GetInt("Money") - money > 139)
                step = 5;
            else if (PlayerPrefs.GetInt("Money") - money > 89)
                step = 4;
            else if (PlayerPrefs.GetInt("Money") - money > 49)
                step = 3;
            else if (PlayerPrefs.GetInt("Money") - money > 29)
                step = 2;
            else
                step = 1;
            for (a = 0; a < step; a++)
                Money.text = money++.ToString();
            if (PlayerPrefs.GetInt("Money") < money)
                i = 1;
        }
    }

    public void Achievements()
    {
        for (i = 0; i < 9; i++)
        {
            a++;
            if (i == 4)
                Score_Recover = PlayerPrefs.GetInt("Recover");
            else if (i == 8)
                Score_Recover = PlayerPrefs.GetInt("Rating") - PlayerPrefs.GetInt("Panel_9");
            if (Score_Recover < mass_2[i])
                mass[i] = Score_Recover;
            if (Score_Recover >= mass_2[i])
            {
                mass[9]++;
                mass[i] = mass_2[i];
                if (PlayerPrefs.GetInt("Panel_" + a) == 0)
                    PlayerPrefs.SetInt("NumberAchievements", PlayerPrefs.GetInt("NumberAchievements") + 1);
            }
        }
        if (mass[9] == 9 && PlayerPrefs.GetInt("Panel_10") == 0)
            PlayerPrefs.SetInt("NumberAchievements", PlayerPrefs.GetInt("NumberAchievements") + 1);

        if (PlayerPrefs.GetInt("NumberAchievements") > 0)
        {
            Number.SetActive(true);
            textNumber.text = PlayerPrefs.GetInt("NumberAchievements").ToString();
            GameObject_textNumber.SetActive(true);
        }
    }

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("Language") && Application.systemLanguage == SystemLanguage.Russian)
            PlayerPrefs.SetInt("Language", 1);
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
            GameObject.Find("MainMusic").GetComponent<AudioSource>().Stop();

        if (PlayerPrefs.GetInt("Select") == 0)
            MainCube.SetActive(true);
        else if (PlayerPrefs.GetInt("Select") == 1)
            Pyramid.SetActive(true);
        else if (PlayerPrefs.GetInt("Select") == 2)
            Tetrahedron.SetActive(true);
        else if (PlayerPrefs.GetInt("Select") == 3)
            Octahedron.SetActive(true);
        else if (PlayerPrefs.GetInt("Select") == 4)
            Icosahedron.SetActive(true);
        else if (PlayerPrefs.GetInt("Select") == 5)
            Dodecahedron.SetActive(true);
        else if (PlayerPrefs.GetInt("Select") == 6)
            Cone.SetActive(true);
        else if (PlayerPrefs.GetInt("Select") == 7)
            Sphere.SetActive(true);
        else if (PlayerPrefs.GetInt("Select") == 8)
            Thor.SetActive(true);
        else
            Heart.SetActive(true);

        if (PlayerPrefs.GetInt("Colors") == 1)
            Colors.SetActive(true);

        Score_Recover = PlayerPrefs.GetInt("Score");

        if (PlayerPrefs.GetInt("Language") == 1)
        {
            Score.text = "Рекорд: " + PlayerPrefs.GetInt("Score").ToString();
            Language.text = "Язык";
            Cubes.text = "Кубики";
            Toggle_1.text = "Тёмные цвета";
            Toggle_2.text = "Все цвета";
            Toggle_3.text = "Светлые цвета";
            Rating_text.text = "Пожалуйста, оцените игру";
            Continue.text = "Продолжить >>>";
            NewScore.GetComponent<Text>().text = "Новый рекорд";
            Exit.text = "Вы действительно хотите выйти из игры?";
        }
        else
            Score.text = "Score: " + Score_Recover.ToString();

        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(0.1960784f, 0.1960784f, 0.1960784f);
            GameObject.Find("Colors").GetComponent<Text>().color = white;
            Money.color = white;
            Score.color = white;
            Language.color = white;
            Rating_text.color = white;
            _Rating.color = white;
            Continue.color = white;
            Cubes.color = white;
            Exit.color = white;
            Toggle_1.color = white;
            Toggle_2.color = white;
            Toggle_3.color = white;
            Toggle_1_2.color = white;
            Toggle_2_2.color = white;
            Panel_Language.GetComponent<SpriteRenderer>().color = gray;
            Panel_Cubes.GetComponent<SpriteRenderer>().color = gray;
            Panel_Rating.GetComponent<SpriteRenderer>().color = gray;
            Panel_Exit.GetComponent<SpriteRenderer>().color = gray;
        }

        Achievements();

        if (PlayerPrefs.GetInt("NewScore") == 1)
        {
            PlayerPrefs.SetInt("NewScore", 0);
            NewScore.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Money") >= 700)
            for (i = 0; i < 10; i++)
                if (PlayerPrefs.GetInt("BoxCollider " + i) != 1)
                {
                    textExclamation.SetActive(true);
                    Exclamation.SetActive(true);
                }
        if (PlayerPrefs.GetInt("Colors") == 0 && PlayerPrefs.GetInt("Money") >= 2000)
        {
            textExclamation.SetActive(true);
            Exclamation.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Remove_Timer") == 0 && PlayerPrefs.GetInt("Money") >= 5000)
        {
            textExclamation.SetActive(true);
            Exclamation.SetActive(true);
        }

        Money.text = PlayerPrefs.GetInt("Money").ToString();

        if (PlayerPrefs.GetInt("MoneyPlay") > 0)
        {
            StartCoroutine(Wait());
            if (PlayerPrefs.GetInt("Rating") == 0 && Random.Range(0, 40) == 0)
                _Panel_Rating.SetActive(true);
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        PlayerPrefs.SetInt("Settings", 1);
        PlayerPrefs.SetInt("T_or_F", 1);
    }
}