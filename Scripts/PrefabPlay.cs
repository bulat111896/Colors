using UnityEngine.UI;
using UnityEngine;

public class PrefabPlay : MonoBehaviour
{
    public GameObject prefab;
    public Canvas canvas;
    private int a = 1, b;

    void Start()
    {
        Destroy(prefab, 0.85f);
        canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        b = GameObject.Find("Main Cube").GetComponent<GameCntrl>().count;
        if (b > 99)
            a = 4;
        else if (b > 69)
            a = 3;
        else if (b > 49)
            a = 2;
        if (PlayerPrefs.GetInt("Toggle") == 1)
            a++;
        GetComponent<Text>().text = "+" + a;
        if (PlayerPrefs.GetInt("Mode") == 1)
            GetComponent<Text>().color = new Color(1, 1, 1);
    }
}