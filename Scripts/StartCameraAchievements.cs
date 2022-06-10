using UnityEngine;
using UnityEngine.UI;

public class StartCameraAchievements : MonoBehaviour
{
    public Text[] Tasks, Numbers, Moneys;
    int[] mass = new int[10];
    int[] mass_2 = new int[9] { 20, 50, 70, 100, 5, 10, 20, 40, 1 };
    int[] mass_3 = new int[10] { 50, 120, 180, 250, 150, 350, 800, 1500, 100, 2500 };
    private int i, a, Score_Recover, m;
    public Text Achievements;
    private Color white = new Color(1, 1, 1), gray = new Color(0.1960784f, 0.1960784f, 0.1960784f);

    void Start()
    {
        if (GameObject.Find("LoadScenes") == null)
        {
            PlayerPrefs.SetInt("NumberAchievements", 0);
            Score_Recover = PlayerPrefs.GetInt("Score");

            if (PlayerPrefs.GetInt("Language") == 1)
            {
                Achievements.text = "Достижения";
                Tasks[0].text = "Набрать 20 очков";
                Tasks[1].text = "Набрать 50 очков";
                Tasks[2].text = "Набрать 70 очков";
                Tasks[3].text = "Набрать 100 очков";
                Tasks[4].text = "Возродиться 5 раз";
                Tasks[5].text = "Возродиться 10 раз";
                Tasks[6].text = "Возродиться 20 раз";
                Tasks[7].text = "Возродиться 40 раз";
                Tasks[8].text = "Оценить игру";
                Tasks[9].text = "Завершить все задания";
                GameObject.Find("Task_10").transform.localPosition = new Vector2(4, 10);
            }

            if (PlayerPrefs.GetInt("Mode") == 1)
            {
                GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = gray;
                GameObject.Find("Scroll").GetComponent<Image>().color = gray;
                GameObject.Find("Content").GetComponent<Image>().color = gray;
                Achievements.color = white;
                for (i = 0; i < 10; i++)
                {
                    Tasks[i].color = white;
                    Numbers[i].color = white;
                    Moneys[i].color = white;
                }
            }

            for (i = 0; i < 9; i++)
            {
                a++;
                if (i == 4)
                    Score_Recover = PlayerPrefs.GetInt("Recover");
                else if (i == 8)
                    Score_Recover = PlayerPrefs.GetInt("Rating");
                if (Score_Recover < mass_2[i])
                    mass[i] = Score_Recover;
                if (Score_Recover >= mass_2[i])
                {
                    mass[9]++;
                    mass[i] = mass_2[i];
                    if (PlayerPrefs.GetInt("Panel_" + a) == 0)
                    {
                        m += mass_3[i];
                        PlayerPrefs.SetInt("Panel_" + a, 1);
                    }
                    GameObject.Find("Lock_" + a).SetActive(false);
                }
                else
                    GameObject.Find("Yellow_star_" + a).SetActive(false);
                GameObject.Find("ProgressBar_" + a).GetComponent<Slider>().value = mass[i];
                GameObject.Find("Number_" + a).GetComponent<Text>().text = mass[i] + "/" + mass_2[i];
            }

            if (mass[9] == 9)
            {
                if (PlayerPrefs.GetInt("Panel_10") == 0)
                {
                    m += mass_3[i];
                    PlayerPrefs.SetInt("Panel_" + a, 1);
                }
                GameObject.Find("Lock_10").SetActive(false);
            }
            else
                GameObject.Find("Yellow_star_10").SetActive(false);
            GameObject.Find("ProgressBar_10").GetComponent<Slider>().value = mass[9];
            GameObject.Find("Number_10").GetComponent<Text>().text = mass[9] + "/" + 9;
            PlayerPrefs.SetInt("MoneyPlay", m);
        }
    }
}