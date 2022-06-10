using UnityEngine;

public class RandCol : MonoBehaviour
{
    public GameObject MainCube;

    void OnMouseUpAsButton()
    {
        if (gameObject != MainCube)
        {
            if (GetComponent<Renderer>().material.color == MainCube.GetComponent<Renderer>().material.color)
                MainCube.GetComponent<GameCntrl>().nextColors();
            else
                MainCube.GetComponent<GameCntrl>().lose = true;
            if (MainCube.GetComponent<GameCntrl>().a)
                GameObject.Find("Timer").GetComponent<Timer>().enabled = true;
        }
    }
}