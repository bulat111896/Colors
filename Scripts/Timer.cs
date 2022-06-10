using UnityEngine;

public class Timer : MonoBehaviour
{
    public Color Col, defCol;
    public GameObject MainCube;
    private float speed = 0.035f;

    void Start()
    {
        GetComponent<Renderer>().material.color = defCol;
        TimerUpdate();
    }

    void FixedUpdate()
    {
        if (!MainCube.GetComponent<GameCntrl>().lose)
        {
            if (transform.position.x < -7.5f)
                MainCube.GetComponent<GameCntrl>().lose = true;
            else if (transform.position.x < -5)
                GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, Col, Time.deltaTime * 5);
            transform.position -= new Vector3(speed, 0, 0);
        }
    }

    public void TimerUpdate()
    {
        if (MainCube.GetComponent<GameCntrl>().count < 12)
            speed = speed + 0.001f;
        transform.position = new Vector3(-1.5f, 5.35f, 0);
        GetComponent<Renderer>().material.color = defCol;
    }
}