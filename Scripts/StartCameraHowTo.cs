using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCameraHowTo : MonoBehaviour
{
    public GameObject[] blocks = new GameObject[4];
    private float r, g, b;
    private bool stop;
    private static Color aColor;
    public Text Right_arrow, Left_arrow, text_1, text_2;
    private Color white = new Color(1, 1, 1);

    public void Home()
    {
        SceneManager.LoadScene("main");
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            text_1.text = "Выберите цвет, соответствующий главному кубу";
        }

        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(0.1960784f, 0.1960784f, 0.1960784f);
            text_1.color = white;
            text_2.color = white;
            Right_arrow.color = new Color(1, 1, 1, 0);
            Left_arrow.color = new Color(1, 1, 1, 0);
        }

        aColor = new Vector4(Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), 1);
        GameObject.Find("Main Cube").GetComponent<Renderer>().material.color = aColor;

        for (int i = 0; i < 4; i++)
        {
            if (i == 2)
                blocks[i].GetComponent<Renderer>().material.color = aColor;
            else
            {
                if (PlayerPrefs.GetInt("Toggle") == 0)
                {
                    r = Mathf.Clamp01(aColor.r + Random.Range(0.1f, 0.7f));
                    g = Mathf.Clamp01(aColor.g + Random.Range(0.1f, 0.7f));
                    b = Mathf.Clamp01(aColor.b + Random.Range(0.1f, 0.7f));
                }
                else if (PlayerPrefs.GetInt("Toggle") == 1)
                {
                    r = Mathf.Clamp01(aColor.r + Random.Range(-0.1f, 0.7f));
                    g = Mathf.Clamp01(aColor.g + Random.Range(-0.1f, 0.7f));
                    b = Mathf.Clamp01(aColor.b + Random.Range(-0.1f, 0.7f));
                }
                else
                {
                    r = Mathf.Clamp01(aColor.r + Random.Range(-0.1f, -0.7f));
                    g = Mathf.Clamp01(aColor.g + Random.Range(-0.1f, -0.7f));
                    b = Mathf.Clamp01(aColor.b + Random.Range(-0.1f, -0.7f));
                }
                blocks[i].GetComponent<Renderer>().material.color = new Vector4(r, g, b, 1);
            }
        }

        StartCoroutine(Co_WaitForSeconds());
    }

    private IEnumerator Co_WaitForSeconds()
    {
        yield return new WaitForSeconds(0.25f);
        stop = true;
    }

    void FixedUpdate()
    {
        if (!stop)
        {
            Right_arrow.transform.position += new Vector3(0.05f, 0, 0);
            Left_arrow.transform.position -= new Vector3(0.05f, 0, 0);
        }
    }
}