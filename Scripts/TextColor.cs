using UnityEngine.UI;
using UnityEngine;

public class TextColor : MonoBehaviour
{
    private int speedR, speedG, speedB;

    void Start()
    {
        speedR = Random.Range(100, 400);
        speedG = Random.Range(100, 400);
        speedB = Random.Range(100, 400);
    }

    void Update()
    {
        transform.GetComponent<Text>().color = new Color(Mathf.PingPong(Time.time * speedR, 80) / 100, Mathf.PingPong(Time.time * speedG, 80) / 100, Mathf.PingPong(Time.time * speedB, 80) / 100);
    }
}