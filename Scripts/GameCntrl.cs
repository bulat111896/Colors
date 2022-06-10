using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameCntrl : MonoBehaviour
{
    public Text score, money;
    public GameObject movie, pause, timer, prefab, newColor, slider, _continue, Diamond, Blocker, panel_pause, stop, play;
    public GameObject[] blocks = new GameObject[4];
    private Vector3 diamondPosition;
    public int count, mony, rand, i, diamond;
    private float RGB, r, g, b;
    private static Color aColor;
    public bool lose, a, nextCol, m;

    public void OnApplicationFocus()
    {
        if (!m)
        {
            pause.GetComponent<Buttons>().Pause = false;
            timer.GetComponent<Timer>().enabled = false;
            newColor.GetComponent<CircleCollider2D>().enabled = false;
            stop.SetActive(false);
            play.SetActive(true);
            panel_pause.SetActive(true);
            Blocker.SetActive(true);
        }
    }

    private IEnumerator Wait()
    {
        if (count > 99)
            mony += 4;
        else if (count > 69)
            mony += 3;
        else if (count > 49)
            mony += 2;
        else
            mony++;
        if (PlayerPrefs.GetInt("Toggle") == 1)
            mony++;
        PlayerPrefs.SetInt("MoneyPlay", mony);
        Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.63f);
        if (PlayerPrefs.GetInt("Sounds") == 0)
            Diamond.GetComponent<AudioSource>().Play();
        diamond = 1;
        yield return new WaitForSeconds(0.07f);
        diamond = 2;
        yield return new WaitForSeconds(0.07f);
        diamond = 0;
        Diamond.transform.localScale = new Vector3(0.24f, 0.24f, 1);
        Diamond.transform.position = diamondPosition;
        money.text = mony.ToString();
    }

    void Start()
    {
        nextColors();
        diamondPosition = Diamond.transform.position;
    }

    void FixedUpdate()
    {
        if (lose)
            playerLose();

        if (diamond == 1)
        {
            Diamond.transform.localScale += new Vector3(0.01f, 0.01f, 0);
            Diamond.transform.position -= new Vector3(0.0075f, -0.0075f, 0);
        }
        else if (diamond == 2)
        {
            Diamond.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
            Diamond.transform.position += new Vector3(0.0075f, -0.0075f, 0);
        }
    }

    public void nextColors()
    {
        count++;
        score.text = count.ToString();
        aColor = new Color(Random.Range(0.2f, 1), Random.Range(0.2f, 1), Random.Range(0.2f, 1));
        GetComponent<Renderer>().material.color = aColor;

        if (count > 99)
            RGB = 0.07f;
        else if (count > 69)
            RGB = 0.1f;
        else if (count > 49)
            RGB = 0.2f;
        else if (count > 29)
            RGB = 0.3f;
        else if (count > 14)
            RGB = 0.4f;
        else if (count > 7)
            RGB = 0.5f;
        else if (count > 2)
            RGB = 0.6f;
        else
            RGB = 0.7f;

        rand = Random.Range(0, 4);

        for (i = 0; i < 4; i++)
        {
            if (i == rand)
                blocks[i].GetComponent<Renderer>().material.color = aColor;
            else
            {
                if (PlayerPrefs.GetInt("Toggle") == 0)
                {
                    r = Mathf.Clamp01(aColor.r + Random.Range(0.1f, RGB));
                    g = Mathf.Clamp01(aColor.g + Random.Range(0.1f, RGB));
                    b = Mathf.Clamp01(aColor.b + Random.Range(0.1f, RGB));
                }
                else if (PlayerPrefs.GetInt("Toggle") == 1)
                {
                    r = Mathf.Clamp01(aColor.r + Random.Range(-RGB, RGB));
                    g = Mathf.Clamp01(aColor.g + Random.Range(-RGB, RGB));
                    b = Mathf.Clamp01(aColor.b + Random.Range(-RGB, RGB));
                }
                else
                {
                    r = Mathf.Clamp01(aColor.r + Random.Range(-0.1f, -RGB));
                    g = Mathf.Clamp01(aColor.g + Random.Range(-0.1f, -RGB));
                    b = Mathf.Clamp01(aColor.b + Random.Range(-0.1f, -RGB));
                }
                blocks[i].GetComponent<Renderer>().material.color = new Color(r, g, b, 1);
            }
        }

        if (count > 0)
        {
            if (!nextCol)
                StartCoroutine(Wait());
            else
                nextCol = false;
            if (PlayerPrefs.GetInt("Score") < count)
            {
                PlayerPrefs.SetInt("Score", count);
                PlayerPrefs.SetInt("NewScore", 1);
            }
            timer.GetComponent<Timer>().TimerUpdate();
            if (PlayerPrefs.GetInt("Sounds") == 0)
                gameObject.GetComponent<AudioSource>().Play();
        }

        rand = 0;
    }

    private IEnumerator Co_WaitForSeconds()
    {
        yield return new WaitForSeconds(3.2f);
        if (!a)
            SceneManager.LoadScene("main");
    }

    void playerLose()
    {
        if (rand == 0)
        {
            rand = 1;
            if (count < 10 || a)
                SceneManager.LoadScene("main");
            else
            {
                pause.GetComponent<CircleCollider2D>().enabled = false;
                newColor.GetComponent<CircleCollider2D>().enabled = false;
                slider.GetComponent<BoxCollider2D>().enabled = false;
                m = true;
                movie.SetActive(true);
                if (PlayerPrefs.GetInt("Money") + PlayerPrefs.GetInt("MoneyPlay") >= 100)
                {
                    _continue.SetActive(true);
                    movie.transform.position += new Vector3(0, 10, 0);
                }
                Blocker.SetActive(true);
                if (PlayerPrefs.GetInt("Sounds") == 1)
                    movie.GetComponent<AudioSource>().mute = true;
            }
            StartCoroutine(Co_WaitForSeconds());
        }
    }
}