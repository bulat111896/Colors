using UnityEngine.UI;
using UnityEngine;

public class StartCameraPlay : MonoBehaviour
{
    public GameObject Timer, Panel_Pause, Slider;
    public Text Pause, Text_pause, Text, On_Off, Number, Money;
    private Color white = new Color(1, 1, 1);

    void Start()
    {
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            Pause.text = "Пауза";
            Pause.transform.localPosition = new Vector2(0, 35);
            Text_pause.text = "Для продолжения нажмите ''Play''";
            Text.text = "Выкл.";
        }

        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(0.1960784f, 0.1960784f, 0.1960784f);
            GameObject.Find("Score").GetComponent<Text>().color = white;
            Pause.color = white;
            Text_pause.color = white;
            Text.color = white;
            Money.color = white;
            Panel_Pause.GetComponent<SpriteRenderer>().color = new Color(0.85f, 0.85f, 0.85f);
        }

        if (PlayerPrefs.GetInt("Remove_Timer") == 1)
        {
            Slider.SetActive(true);
            if (PlayerPrefs.GetInt("Slider") == 1)
            {
                Slider.GetComponent<Slider>().value = 1;
                Timer.SetActive(true);
                Timer.transform.position = new Vector3(-1.5f, 5.35f, 0);
                Timer.GetComponent<Renderer>().material.color = GameObject.Find("Timer").GetComponent<Timer>().defCol;
                if (PlayerPrefs.GetInt("Language") == 1)
                    On_Off.text = "Выкл.";
                else
                    On_Off.text = "Off";
            }
            else
            {
                Slider.GetComponent<Slider>().value = 0;
                Timer.SetActive(false);
                if (PlayerPrefs.GetInt("Language") == 1)
                    On_Off.text = "Вкл.";
                else
                    On_Off.text = "On";
            }
        }

        if (PlayerPrefs.GetInt("NewColor") > 99)
            Number.text = "99+";
        else
            Number.text = PlayerPrefs.GetInt("NewColor").ToString();
    }
}