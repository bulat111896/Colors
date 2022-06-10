using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Toggle_ : MonoBehaviour
{
    public Toggle Toggle_1, Toggle_2, Toggle_3, Toggle_1_2, Toggle_2_2;

    void Update()
    {
        if (PlayerPrefs.GetInt("Toggle") == 0)
        {
            Toggle_1.isOn = true;
            Toggle_1.interactable = false;
        }
        else if (PlayerPrefs.GetInt("Toggle") == 1)
        {
            Toggle_2.isOn = true;
            Toggle_2.interactable = false;
        }
        else
        {
            Toggle_3.isOn = true;
            Toggle_3.interactable = false;
        }
        if (PlayerPrefs.GetInt("Toggle_2") == 0)
        {
            Toggle_1_2.isOn = true;
            Toggle_1_2.interactable = false;
        }
        else
        {
            Toggle_2_2.isOn = true;
            Toggle_2_2.interactable = false;
        }

        if (Toggle_1.isOn && PlayerPrefs.GetInt("Toggle") != 0)
        {
            if (PlayerPrefs.GetInt("Sounds") == 0)
                GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
            Toggle_1.interactable = false;
            Toggle_2.interactable = true;
            Toggle_3.interactable = true;
            Toggle_2.isOn = false;
            Toggle_3.isOn = false;
            PlayerPrefs.SetInt("Toggle", 0);
        }
        else if (Toggle_2.isOn && PlayerPrefs.GetInt("Toggle") != 1)
        {
            if (PlayerPrefs.GetInt("Sounds") == 0)
                GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
            Toggle_2.interactable = false;
            Toggle_1.interactable = true;
            Toggle_3.interactable = true;
            Toggle_1.isOn = false;
            Toggle_3.isOn = false;
            PlayerPrefs.SetInt("Toggle", 1);
        }
        else if (Toggle_3.isOn && PlayerPrefs.GetInt("Toggle") != 2)
        {
            if (PlayerPrefs.GetInt("Sounds") == 0)
                GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
            Toggle_3.interactable = false;
            Toggle_1.interactable = true;
            Toggle_2.interactable = true;
            Toggle_1.isOn = false;
            Toggle_2.isOn = false;
            PlayerPrefs.SetInt("Toggle", 2);
        }
        if (Toggle_1_2.isOn && PlayerPrefs.GetInt("Toggle_2") != 0)
        {
            if (PlayerPrefs.GetInt("Sounds") == 0)
                GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
            Toggle_1_2.interactable = false;
            Toggle_2_2.interactable = true;
            Toggle_2_2.isOn = false;
            PlayerPrefs.SetInt("Toggle_2", 0);
            SceneManager.LoadScene("main");
        }
        else if (Toggle_2_2.isOn && PlayerPrefs.GetInt("Toggle_2") != 1)
        {
            if (PlayerPrefs.GetInt("Sounds") == 0)
                GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
            Toggle_2_2.interactable = false;
            Toggle_1_2.interactable = true;
            Toggle_1_2.isOn = false;
            PlayerPrefs.SetInt("Toggle_2", 1);
            SceneManager.LoadScene("main");
        }
    }
}