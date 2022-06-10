using UnityEngine.UI;
using UnityEngine;

public class PrefabError : MonoBehaviour
{
    public GameObject prefab;
    public Canvas canvas;
    public Image panel;
    public Text text;

    void Start()
    {
        canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        canvas.planeDistance = 1;
        if (PlayerPrefs.GetInt("Panel Error") == 2)
            text.GetComponent<RectTransform>().sizeDelta = new Vector2(194.5f, 40);
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            if (PlayerPrefs.GetInt("Panel Error") == 1)
                text.text = "Нет подключения к Интернету";
            else if (PlayerPrefs.GetInt("Panel Error") == 2)
                text.text = "Превышено максимально допустимое количество просмотров";
        }
        else if (PlayerPrefs.GetInt("Panel Error") == 2)
                text.text = "Maximum allowed number of views exceeded";
        PlayerPrefs.SetInt("Panel Error", 0);
        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            text.color = new Color(1, 1, 1);
            panel.color = new Color(0, 0, 0);
        }
    }

    void OnMouseDown()
    {
        Destroy(prefab);
    }
}