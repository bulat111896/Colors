using UnityEngine;

public class Colors : MonoBehaviour
{
    private Renderer Model;
    private int speedR, speedG, speedB;

    void Start()
    {
        Model = GameObject.Find("default").GetComponent<Renderer>();
        speedR = Random.Range(30, 50);
        speedG = Random.Range(30, 90);
        speedB = Random.Range(30, 50);
    }

    void FixedUpdate()
    {
        Model.material.color = new Color(Mathf.PingPong((Time.time + speedB) * speedR , 90) / 100, Mathf.PingPong((Time.time + speedR) * speedG, 70) / 100, Mathf.PingPong((Time.time + speedG) * speedB, 90) / 100);
    }
}