using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Monetization;

public class Buttons : MonoBehaviour
{
    public int i, a;
    public bool Panel_Error_wait = true, Pause = true, TF = true;
    public Text Colors, Score, Money, Language_headline, Cubes_text, Toggle_1, Toggle_2, Toggle_3, Toggle_1_2, Toggle_2_2, Exit, Number;
    public Camera MainCamera;
    public GameObject Panel_Language, Panel_Cubes, Panel_Rating, Music, Sounds, Cubes, Language, Quit, Mode, on, off, Tim, plost, MainCube, Blocker, Panel_Error, Error_Text, Error, Check_mark, _500, Diamond, Check, Select;
    public SpriteRenderer Shadow;

    public IEnumerator Load()
    {
        while (i == 0)
        {
            if (Monetization.isSupported)
                Monetization.Initialize("3618991", false);
            if (Monetization.IsReady("video"))
            {
                i = 1;
                ShowAdCallbacks options = new ShowAdCallbacks();
                options.finishCallback = HandleShowResult;
                (Monetization.GetPlacementContent("video") as ShowAdPlacementContent).Show(options);
                plost.GetComponent<Text>().text = (3 - PlayerPrefs.GetInt("Views")).ToString();
                //GameObject.Find("Ads").GetComponent<Ads>().StartWait();
            }
            else if (i == 0)
            {
                a++;
                Tim.transform.Rotate(new Vector3(0, 0, transform.rotation.z + 45));
                if (a == 150)
                {
                    i = 1;
                    PlayerPrefs.SetInt("Panel Error", 1);
                    Instantiate(Panel_Error, new Vector3(0, 0, 0), Quaternion.identity);
                    plost.GetComponent<Text>().text = (3 - PlayerPrefs.GetInt("Views")).ToString();
                }
                yield return new WaitForSeconds(0.05f);
            }
        }
        Tim.SetActive(false);
        transform.position = new Vector3(transform.position.x, -0.75f, 0);
        PlayerPrefs.SetInt("VideoPosition", 0);
    }
    public IEnumerator Load2()
    {
        on.SetActive(true);
        if (PlayerPrefs.GetInt("Mode") == 1)
            off.GetComponent<Text>().color = new Color(1, 1, 1);
        while (i == 0)
        {
            if (PlayerPrefs.GetInt("VideoNowTime") == 0)
            {
                on.GetComponent<NowTime>().StartNewCoroutine();
                a++;
                Tim.transform.Rotate(new Vector3(0, 0, transform.rotation.z + 45));
                if (a == 100)
                {
                    i = 1;
                    PlayerPrefs.SetInt("Panel Error", 1);
                    Instantiate(Panel_Error, new Vector3(0, 0, -300), Quaternion.identity);
                    transform.position = new Vector3(transform.position.x, -0.75f, 0);
                    PlayerPrefs.SetInt("VideoPosition", 0);
                    plost.GetComponent<Text>().text = (3 - PlayerPrefs.GetInt("Views")).ToString();
                }
                yield return new WaitForSeconds(0.05f);
            }
            else
                i = 1;
        }
        Tim.SetActive(false);
        PlayerPrefs.SetInt("VideoNowTime", 0);
    }
    private IEnumerator Panel_Error_WaitForSeconds()
    {
        yield return new WaitForSeconds(4);
        Panel_Error.SetActive(false);
        Panel_Error_wait = true;
    }
    private IEnumerator Wait()
    {
        on.GetComponent<SettingsButtonsAnimation>().a = 1;
        yield return new WaitForSeconds(0.03f);
        on.GetComponent<SettingsButtonsAnimation>().a = 2;
        yield return new WaitForSeconds(0.1f);
        Music.SetActive(false);
        Sounds.SetActive(false);
        Cubes.SetActive(false);
        Language.SetActive(false);
        Quit.SetActive(false);
        Mode.SetActive(false);
        Quit.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        Mode.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        Cubes.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        Language.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        Music.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        Sounds.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        Diamond.SetActive(false);
        on.GetComponent<SettingsButtonsAnimation>().a = 0;
        PlayerPrefs.SetInt("Settings", 1);
    }
    private IEnumerator Co_WaitForSeconds()
    {
        Sounds.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        Music.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        Language.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        Cubes.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        Mode.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        Quit.SetActive(true);
        PlayerPrefs.SetInt("T_or_F", 1);
        PlayerPrefs.SetInt("Settings", 0);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
    public void Purcahase()
    {
        _Panel_Error(true, false, 0);
    }
    public void Ads()
    {
        if (PlayerPrefs.GetInt("Ads") == 1)
        {
            if (Panel_Error_wait)
                _Panel_Error(true, false, 0);
        }
        else if (Panel_Error_wait)
            _Panel_Error(true, false, 1);
    }
    private void Movie()
    {
        PlayerPrefs.SetInt("Recover", PlayerPrefs.GetInt("Recover") + 1);
        Destroy(GameObject.Find("Movie"));
        Destroy(GameObject.Find("Continue"));
        MainCube.GetComponent<GameCntrl>().lose = false;
        MainCube.GetComponent<GameCntrl>().a = true;
        MainCube.GetComponent<GameCntrl>().rand = 0;
        plost.GetComponent<CircleCollider2D>().enabled = true;
        on.GetComponent<BoxCollider2D>().enabled = true;
        off.GetComponent<CircleCollider2D>().enabled = true;
        Blocker.SetActive(false);
        Tim.transform.position = new Vector3(-1.5f, 5.35f, 0);
        Tim.GetComponent<Renderer>().material.color = Tim.GetComponent<Timer>().defCol;
        if (PlayerPrefs.GetInt("Sounds") == 0)
            GameObject.Find("Continue_sound").GetComponent<AudioSource>().Play();
        MainCube.GetComponent<GameCntrl>().m = false;
    }
    private void _Pause(bool a, bool b)
    {
        Pause = a;
        Tim.GetComponent<Timer>().enabled = a;
        Error.GetComponent<CircleCollider2D>().enabled = a;
        on_off(a, b);
        plost.SetActive(b);
        Blocker.SetActive(b);
    }
    private void on_off(bool a, bool b)
    {
        on.SetActive(a);
        off.SetActive(b);
    }
    private void button_end()
    {
        if (gameObject.tag != "Purchase")
        {
            if (gameObject.tag == "Button")
            {
                GetComponent<SpriteRenderer>().color = new Color(0, 0.7f, 1);
                GetComponent<SpriteRenderer>().flipY = false;
                Shadow.color = new Color(1, 1, 1, 0.7f);
            }
            gameObject.transform.position += new Vector3(0, 0.02f, 0);
            gameObject.transform.localScale += new Vector3(0.002f, 0.002f, 0);
        }
    }
    private void _Panel_Error(bool a, bool b, int c)
    {
        if (c == 0)
        {
            if (PlayerPrefs.GetInt("Language") == 1)
                Error_Text.GetComponent<Text>().text = "Вы приобрели данную покупку";
            else
                Error_Text.GetComponent<Text>().text = "You have purchased this purchase";
        }
        else if (c == 1)
        {
            if (PlayerPrefs.GetInt("Language") == 1)
                Error_Text.GetComponent<Text>().text = "У вас уже имеется данная покупка";
            else
                Error_Text.GetComponent<Text>().text = "You already have this purchase";
        }
        else
        {
            if (PlayerPrefs.GetInt("Language") == 1)
                Error_Text.GetComponent<Text>().text = "У вас нет достаточно денег для данной покупки";
            else
                Error_Text.GetComponent<Text>().text = "You do not have enough money for this purchase";
        }
        Panel_Error_wait = false;
        Check_mark.SetActive(a);
        Error.SetActive(b);
        Panel_Error.SetActive(true);
        StartCoroutine(Panel_Error_WaitForSeconds());
    }
    private void _Mode(float a, float c, float d, int e, bool f, bool g, int h)
    {
        PlayerPrefs.SetInt("Mode", e);
        PlayerPrefs.SetInt("Toggle", h);
        if (h == 0)
            Diamond.GetComponent<Toggle>().isOn = false;
        else
            Error.GetComponent<Toggle>().isOn = false;
        Check_mark.GetComponent<Toggle>().interactable = true;
        Check_mark.GetComponent<Toggle>().isOn = false;
        Diamond.GetComponent<Toggle>().interactable = f;
        Error.GetComponent<Toggle>().interactable = g;
        MainCamera.backgroundColor = new Color(a, a, a);
        Score.color = new Color(c, c, c);
        Money.color = new Color(c, c, c);
        Cubes_text.color = new Color(c, c, c);
        Exit.color = new Color(c, c, c);
        Toggle_1.color = new Color(c, c, c);
        Toggle_2.color = new Color(c, c, c);
        Toggle_3.color = new Color(c, c, c);
        Toggle_1_2.color = new Color(c, c, c);
        Toggle_2_2.color = new Color(c, c, c);
        Language_headline.color = new Color(c, c, c);
        Panel_Language.GetComponent<SpriteRenderer>().color = new Color(d, d, d);
        Panel_Cubes.GetComponent<SpriteRenderer>().color = new Color(d, d, d);
        Panel_Rating.GetComponent<SpriteRenderer>().color = new Color(d, d, d);
        plost.GetComponent<SpriteRenderer>().color = new Color(d, d, d);
        on_off(f, g);
    }
    private void Close_buttons()
    {
        Music.SetActive(false);
        Cubes.SetActive(false);
        Sounds.SetActive(false);
        Language.SetActive(false);
        Quit.SetActive(false);
        Mode.SetActive(false);
    }
    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            PlayerPrefs.SetInt("MoneyPlay", PlayerPrefs.GetInt("MoneyPlay") + 150);
            PlayerPrefs.SetInt("Views", PlayerPrefs.GetInt("Views") + 1);
            plost.GetComponent<Text>().text = (3 - PlayerPrefs.GetInt("Views")).ToString();
            if (PlayerPrefs.GetInt("Views") == 3)
            {
                i = 0;
                a = 0;
                transform.position = new Vector3(transform.position.x, 6, 0);
                PlayerPrefs.SetInt("VideoPosition", 1);
                plost.GetComponent<Text>().text = "";
                off.GetComponent<Text>().text = "";
                PlayerPrefs.SetInt("VideoNowTime", 0);
                Tim.SetActive(true);
                StartCoroutine(Load2());
            }
        }
        else
        {

        }
    }
    void HandleShowResult2(ShowResult result)
    {
        if (result == ShowResult.Finished)
            Movie();
        else
        {
            SceneManager.LoadScene("main");
        }
    }

    void Start()
    {
        if (gameObject.name == "Music")
            if (PlayerPrefs.GetInt("Music") == 1)
                off.SetActive(true);
            else
                on.SetActive(true);

        if (gameObject.name == "Sounds")
            if (PlayerPrefs.GetInt("Sounds") == 0)
                off.SetActive(true);
            else
                on.SetActive(true);

        if (gameObject.name == "Mode")
            if (PlayerPrefs.GetInt("Mode") == 0)
                on.SetActive(true);
            else
                off.SetActive(true);

        if (gameObject.name == "Russia")
            if (PlayerPrefs.GetInt("Language") == 1)
            {
                on.SetActive(true);
                off.SetActive(false);
            }
        if (gameObject.name == "Pause")
            Monetization.Initialize("3618991", false);
    }

    void OnMouseUp()
    {
        button_end();
        if (gameObject.name == "Remove Timer")
            GameObject.Find("Delete timer").transform.position += new Vector3(0, 0.02f, 0);
        else if (gameObject.name == "NewColorPlay")
            GameObject.Find("Number").transform.position += new Vector3(0, 0.02f, 0);
        else if (gameObject.name == "Shop")
        {
            if (GameObject.Find("Exclamation_txt") != null)
                GameObject.Find("Exclamation_txt").transform.position += new Vector3(0, 0.02f, 0);
        }
        else if (gameObject.name == "Achievements" || gameObject.name == "Video")
        {
            if (GameObject.Find("Number_txt") != null)
                GameObject.Find("Number_txt").transform.position += new Vector3(0, 0.03f, 0);
        }
        else if (gameObject.name == "BuyModel")
        {
            Select.transform.position += new Vector3(0, 0.02f, 0);
        }
    }

    void OnMouseDown()
    {
        if (gameObject.tag != "Purchase")
        {
            if (gameObject.tag == "Button")
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 0.4f, 1);
                GetComponent<SpriteRenderer>().flipY = true;
                Shadow.color = new Color(1, 1, 1, 1);
            }
            transform.position -= new Vector3(0, 0.02f, 0);
            transform.localScale -= new Vector3(0.002f, 0.002f, 0);
        }
        if (gameObject.name == "Remove Timer")
            GameObject.Find("Delete timer").transform.position -= new Vector3(0, 0.02f, 0);
        else if (gameObject.name == "NewColorPlay")
            GameObject.Find("Number").transform.position -= new Vector3(0, 0.02f, 0);
        else if (gameObject.name == "Shop")
        {
            if (GameObject.Find("Exclamation_txt") != null)
                GameObject.Find("Exclamation_txt").transform.position -= new Vector3(0, 0.02f, 0);
        }
        else if (gameObject.name == "Achievements" || gameObject.name == "Video")
        {
            if (GameObject.Find("Number_txt") != null)
                GameObject.Find("Number_txt").transform.position -= new Vector3(0, 0.03f, 0);
        }
        else if (gameObject.name == "BuyModel")
        {
            Select.transform.position -= new Vector3(0, 0.02f, 0);
        }
    }

    void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetInt("Sounds") == 0)
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Play":
                SceneManager.LoadScene("play");
                break;

            case "Achievements":
                SceneManager.LoadScene("achievements");
                break;

            case "Home":
                SceneManager.LoadScene("main");
                break;

            case "How to":
                SceneManager.LoadScene("how to");
                break;

            case "Shop":
                SceneManager.LoadScene("shop");
                break;

            case "Rating":
                PlayerPrefs.SetInt("Settings", 1);
                PlayerPrefs.SetInt("T_or_F", 0);
                PlayerPrefs.SetInt("Rating", 1);
                Panel_Cubes.SetActive(false);
                Panel_Language.SetActive(false);
                Panel_Rating.SetActive(false);
                Close_buttons();
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.funnycloudgames.colors");
                MainCamera.GetComponent<StartCamera>().Achievements();
                break;

            case "Yellow_star_1":
                GameObject.Find("Yellow_star_2").GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
                GameObject.Find("Yellow_star_3").GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
                GameObject.Find("Yellow_star_4").GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
                GameObject.Find("Yellow_star_5").GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
                GameObject.Find("Yellow_star_1").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                if (PlayerPrefs.GetInt("Language") == 1)
                    Colors.text = "Ужасно";
                else
                    Colors.text = "Terribly";
                break;

            case "Yellow_star_2":
                GameObject.Find("Yellow_star_3").GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
                GameObject.Find("Yellow_star_4").GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
                GameObject.Find("Yellow_star_5").GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
                GameObject.Find("Yellow_star_1").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GameObject.Find("Yellow_star_2").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                if (PlayerPrefs.GetInt("Language") == 1)
                    Colors.text = "Плохо";
                else
                    Colors.text = "Poorly";
                break;

            case "Yellow_star_3":
                GameObject.Find("Yellow_star_4").GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
                GameObject.Find("Yellow_star_5").GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
                GameObject.Find("Yellow_star_1").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GameObject.Find("Yellow_star_2").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GameObject.Find("Yellow_star_3").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                if (PlayerPrefs.GetInt("Language") == 1)
                    Colors.text = "Нормально";
                else
                    Colors.text = "Fine";
                break;

            case "Yellow_star_4":
                GameObject.Find("Yellow_star_5").GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
                GameObject.Find("Yellow_star_1").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GameObject.Find("Yellow_star_2").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GameObject.Find("Yellow_star_3").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GameObject.Find("Yellow_star_4").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                if (PlayerPrefs.GetInt("Language") == 1)
                    Colors.text = "Хорошо";
                else
                    Colors.text = "Good";
                break;

            case "Yellow_star_5":
                GameObject.Find("Yellow_star_1").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GameObject.Find("Yellow_star_2").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GameObject.Find("Yellow_star_3").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GameObject.Find("Yellow_star_4").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GameObject.Find("Yellow_star_5").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                if (PlayerPrefs.GetInt("Language") == 1)
                    Colors.text = "Отлично";
                else
                    Colors.text = "Excellent";
                break;

            case "RatingContinue":
                if (Shadow.color == new Color(1, 1, 1))
                {
                    PlayerPrefs.SetInt("Rating", 1);
                    Application.OpenURL("https://play.google.com/store/apps/details?id=com.funnycloudgames.colors");
                }
                on.SetActive(false);
                break;

            case "Settings":
                Panel_Language.SetActive(false);
                Panel_Cubes.SetActive(false);
                Panel_Rating.SetActive(false);
                MainCube.SetActive(false);
                if (PlayerPrefs.GetInt("Settings") == 1)
                {
                    GetComponent<CircleCollider2D>().enabled = false;
                    StartCoroutine(Co_WaitForSeconds());
                    Diamond.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("T_or_F") == 1)
                {
                    PlayerPrefs.SetInt("T_or_F", 0);
                    on.GetComponent<SettingsButtonsAnimation>().a = 1;
                    StartCoroutine(Wait());
                }
                off.SetActive(true);
                Tim.SetActive(false);
                Blocker.SetActive(false);
                break;

            case "Krestick":
                Panel_Language.SetActive(false);
                Blocker.SetActive(false);
                break;

            case "Quit":
                if (PlayerPrefs.GetInt("Settings") == 0)
                {
                    PlayerPrefs.SetInt("Settings", 1);
                    PlayerPrefs.SetInt("T_or_F", 0);
                    Close_buttons();
                    Panel_Language.SetActive(true);
                    Blocker.SetActive(true);
                    button_end();
                }
                break;

            case "Yes":
                Application.Quit();
                break;

            case "No":
                Panel_Language.SetActive(false);
                Blocker.SetActive(false);
                button_end();
                break;

            case "Cubes":
                if (PlayerPrefs.GetInt("Settings") == 0)
                {
                    PlayerPrefs.SetInt("Settings", 1);
                    PlayerPrefs.SetInt("T_or_F", 0);
                    Close_buttons();
                    if (PlayerPrefs.GetInt("Language") == 1)
                        Cubes_text.text = "Кубики";
                    else
                        Cubes_text.text = "Cubes";
                    on.GetComponent<Text>().text = ">>>";
                    on.GetComponent<Buttons>().TF = true;
                    TF = true;
                    Panel_Cubes.SetActive(true);
                    Blocker.SetActive(true);
                    button_end();
                }
                break;

            case "Language":
                if (PlayerPrefs.GetInt("Settings") == 0)
                {
                    PlayerPrefs.SetInt("Settings", 1);
                    PlayerPrefs.SetInt("T_or_F", 0);
                    Close_buttons();
                    Panel_Language.SetActive(true);
                    Blocker.SetActive(true);
                    button_end();
                }
                break;

            case "Russia":
                if (PlayerPrefs.GetInt("Language") == 0)
                {
                    PlayerPrefs.SetInt("Language", 1);
                    on_off(true, false);
                    SceneManager.LoadScene("main");
                }
                break;

            case "Great britain":
                if (PlayerPrefs.GetInt("Language") == 1)
                {
                    PlayerPrefs.SetInt("Language", 0);
                    on_off(false, true);
                    SceneManager.LoadScene("main");
                }
                break;

            case "Remove Timer":
                if (PlayerPrefs.GetInt("Remove_Timer") == 0)
                {
                    if (PlayerPrefs.GetInt("Money") >= 4000)
                    {
                        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 4000);
                        PlayerPrefs.SetInt("Remove_Timer", 1);
                        if (Panel_Error_wait)
                            _Panel_Error(true, false, 0);
                    }
                    else if (Panel_Error_wait)
                        _Panel_Error(false, true, 2);
                }
                else if (Panel_Error_wait)
                    _Panel_Error(true, false, 1);
                break;

            case "Continue":
                if (PlayerPrefs.GetInt("Money") >= 100)
                    PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 100);
                else
                    PlayerPrefs.SetInt("MoneyPlay", PlayerPrefs.GetInt("MoneyPlay") - 100);
                Movie();
                Tim.GetComponent<Timer>().enabled = false;
                break;

            case "Movie":
                if (Monetization.IsReady("video"))
                {
                    MainCube.GetComponent<GameCntrl>().lose = false;
                    MainCube.GetComponent<GameCntrl>().a = true;
                    MainCube.GetComponent<GameCntrl>().rand = 0;
                    Tim.GetComponent<Timer>().enabled = false;
                    ShowAdCallbacks options = new ShowAdCallbacks();
                    options.finishCallback = HandleShowResult2;
                    (Monetization.GetPlacementContent("video") as ShowAdPlacementContent).Show(options);
                    GameObject.Find("Ads").GetComponent<Ads>().StopAllCoroutines();
                    GameObject.Find("Ads").GetComponent<Ads>().StartCoroutine(Wait());
                }
                else
                {
                    PlayerPrefs.SetInt("Panel Error", 1);
                    SceneManager.LoadScene("main");
                }
                break;

            case "Video":
                i = 0;
                a = 0;
                transform.position = new Vector3(transform.position.x, 6, 0);
                PlayerPrefs.SetInt("VideoPosition", 1);
                plost.GetComponent<Text>().text = "";
                PlayerPrefs.SetInt("VideoNowTime", 0);
                Tim.SetActive(true);
                if (PlayerPrefs.GetInt("Views") < 3)
                    StartCoroutine(Load());
                else
                    StartCoroutine(Load2());
                break;

            case "Music":
                if (PlayerPrefs.GetInt("Music") == 0)
                {
                    PlayerPrefs.SetInt("Music", 1);
                    GameObject.Find("MainMusic").GetComponent<AudioSource>().Pause();
                    on_off(false, true);
                }
                else
                {
                    PlayerPrefs.SetInt("Music", 0);
                    GameObject.Find("MainMusic").GetComponent<AudioSource>().Play();
                    on_off(true, false);
                }
                break;

            case "Sounds":
                if (PlayerPrefs.GetInt("Sounds") == 1)
                {
                    PlayerPrefs.SetInt("Sounds", 0);
                    on_off(false, true);
                }
                else
                {
                    PlayerPrefs.SetInt("Sounds", 1);
                    on_off(true, false);
                }
                break;

            case "Mode":
                if (PlayerPrefs.GetInt("Mode") == 0)
                    _Mode(0.1960784f, 1, 0.85f, 1, false, true, 2);
                else
                    _Mode(0.95f, 0.1960784f, 1, 0, true, false, 0);
                break;

            case "Pause":
                if (Pause)
                    _Pause(false, true);
                else
                    _Pause(true, false);
                break;

            case ">>>":
                if (TF)
                {
                    GetComponent<Text>().text = "<<<";
                    TF = false;
                    on_off(false, true);
                    if (PlayerPrefs.GetInt("Language") == 1)
                    {
                        Colors.text = "Звёздочки";
                        Score.text = "Включить звёздочки";
                        Money.text = "Отключить звёздочки";
                    }
                    else
                        Colors.text = "Stars";
                }
                else
                {
                    GetComponent<Text>().text = ">>>";
                    TF = true;
                    on_off(true, false);
                    if (PlayerPrefs.GetInt("Language") == 1)
                        Colors.text = "Кубики";
                    else
                        Colors.text = "Cubes";
                }
                break;

            case "BuyModel":
                if (PlayerPrefs.GetInt("Money") >= 700 && PlayerPrefs.GetInt(GameObject.Find("SelectModels").GetComponent<SelectModels>().nowModel) != 1)
                {
                    PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 700);
                    PlayerPrefs.SetInt(GameObject.Find("SelectModels").GetComponent<SelectModels>().nowModel, 1);
                    if (Panel_Error_wait)
                        _Panel_Error(true, false, 0);
                    _500.SetActive(false);
                    Diamond.SetActive(false);
                    Check.SetActive(true);
                    for (i = 0; i < 10; i++)
                        if (GameObject.Find("SelectModels").GetComponent<SelectModels>().nowModel == "BoxCollider " + i)
                            PlayerPrefs.SetInt("Select", i);
                }
                else
                {
                    if (PlayerPrefs.GetInt(GameObject.Find("SelectModels").GetComponent<SelectModels>().nowModel) == 1)
                    {
                        for (i = 0; i < 10; i++)
                            if (GameObject.Find("SelectModels").GetComponent<SelectModels>().nowModel == "BoxCollider " + i)
                                PlayerPrefs.SetInt("Select", i);
                        Select.SetActive(false);
                        _500.SetActive(false);
                        Diamond.SetActive(false);
                        Check.SetActive(true);
                    }
                    else if (Panel_Error_wait)
                        _Panel_Error(false, true, 2);
                }
                break;

            case "Slider":
                if (PlayerPrefs.GetInt("Slider") == 0)
                {
                    PlayerPrefs.SetInt("Slider", 1);
                    GetComponent<Slider>().value = 1;
                    Tim.SetActive(true);
                    Tim.transform.position = new Vector3(-1.5f, 5.35f, 0);
                    Tim.GetComponent<Renderer>().material.color = GameObject.Find("Timer").GetComponent<Timer>().defCol;
                    if (PlayerPrefs.GetInt("Language") == 1)
                        Colors.text = "Выкл.";
                    else
                        Colors.text = "Off";
                }
                else
                {
                    PlayerPrefs.SetInt("Slider", 0);
                    GetComponent<Slider>().value = 0;
                    Tim.SetActive(false);
                    if (PlayerPrefs.GetInt("Language") == 1)
                        Colors.text = "Вкл.";
                    else
                        Colors.text = "On";
                }
                break;

            case "NewColor":
                if (PlayerPrefs.GetInt("Money") >= 30)
                {
                    PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 30);
                    PlayerPrefs.SetInt("NewColor", PlayerPrefs.GetInt("NewColor") + 1);
                    if (Panel_Error_wait)
                        _Panel_Error(true, false, 0);
                }
                else if (Panel_Error_wait)
                    _Panel_Error(false, true, 2);
                break;

            case "NewColorPlay":
                if (PlayerPrefs.GetInt("NewColor") >= 1)
                {
                    PlayerPrefs.SetInt("NewColor", PlayerPrefs.GetInt("NewColor") - 1);
                    if (PlayerPrefs.GetInt("NewColor") > 99)
                        Number.text = "99+";
                    else
                        Number.text = PlayerPrefs.GetInt("NewColor").ToString();
                    MainCube.GetComponent<GameCntrl>().count = MainCube.GetComponent<GameCntrl>().count - 1;
                    MainCube.GetComponent<GameCntrl>().nextColors();
                    MainCube.GetComponent<GameCntrl>().nextCol = true;
                    Tim.transform.position = new Vector3(-1.5f, 5.35f, 0);
                    Tim.GetComponent<Renderer>().material.color = Tim.GetComponent<Timer>().defCol;
                }
                break;

            case ">":
                MainCube.transform.position -= new Vector3(2, 0, 0);
                break;

            case "<":
                MainCube.transform.position += new Vector3(2, 0, 0);
                break;

            case "Colors":
                if (PlayerPrefs.GetInt("Colors") == 0)
                {
                    if (PlayerPrefs.GetInt("Money") >= 2000)
                    {
                        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 2000);
                        PlayerPrefs.SetInt("Colors", 1);
                        if (Panel_Error_wait)
                            _Panel_Error(true, false, 0);
                    }
                    else if (Panel_Error_wait)
                        _Panel_Error(false, true, 2);
                }
                else if (Panel_Error_wait)
                    _Panel_Error(true, false, 1);
                break;

            case "Ads":
                if (PlayerPrefs.GetInt("Ads") == 0)
                {
                    on.GetComponent<PurchaseManager>().BuyNonConsumable(0);
                }
                else if (Panel_Error_wait)
                    _Panel_Error(true, false, 1);
                break;

            case "One_diamonds":
                on.GetComponent<PurchaseManager>().BuyConsumable(0);
                break;

            case "Two_diamonds":
                on.GetComponent<PurchaseManager>().BuyConsumable(1);
                break;

            case "Three_diamonds":
                on.GetComponent<PurchaseManager>().BuyConsumable(2);
                break;

            case "Four_diamonds":
                on.GetComponent<PurchaseManager>().BuyConsumable(3);
                break;

            case "Five_diamonds":
                on.GetComponent<PurchaseManager>().BuyConsumable(4);
                break;

            case "Six_diamonds":
                on.GetComponent<PurchaseManager>().BuyConsumable(5);
                break;
        }
    }
}