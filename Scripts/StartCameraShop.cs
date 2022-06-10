using UnityEngine.UI;
using UnityEngine;

public class StartCameraShop : MonoBehaviour
{
    public Image Panel_Error;
    public Text Shop, tim, Error_Text, Ads, Movie, NewColor, Delete_Timer_price, Colors, One_diamond, Two_diamonds, Three_diamonds, Four_diamonds, Five_diamonds, Six_diamonds, One_diamond_price, Two_diamonds_price, Three_diamonds_price, Four_diamonds_price, Five_diamonds_price, Six_diamonds_price, Select;
    public GameObject Number_txt, Number;
    private Color white = new Color(1, 1, 1);

    void Start()
    {
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            Shop.text = "Магазин";
            Select.text = "Выбрать";
        }

        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(0.1960784f, 0.1960784f, 0.1960784f);
            GameObject.Find("Purchases").GetComponent<Image>().color = new Color(0.1f, 0.1f, 0.1f);
            Panel_Error.color = new Color(0.1f, 0.1f, 0.1f, 0.9f);
            Shop.color = white;
            Ads.color = white;
            Movie.color = white;
            NewColor.color = white;
            Delete_Timer_price.color = white;
            Error_Text.color = white;
            One_diamond.color = white;
            Two_diamonds.color = white;
            Three_diamonds.color = white;
            Four_diamonds.color = white;
            Five_diamonds.color = white;
            Six_diamonds.color = white;
            One_diamond_price.color = white;
            Two_diamonds_price.color = white;
            Three_diamonds_price.color = white;
            Four_diamonds_price.color = white;
            Five_diamonds_price.color = white;
            Six_diamonds_price.color = white;
            tim.color = white;
            Colors.color = white;
        }

        Number.SetActive(true);
        Number_txt.SetActive(true);
        Number_txt.GetComponent<Text>().text = (3 - PlayerPrefs.GetInt("Views")).ToString();

        PlayerPrefs.SetInt("BoxCollider 0", 1);
    }
}