using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public bool a;
    void Start()
    {
        if (PlayerPrefs.GetInt("Colors") == 0 || a)
            GetComponent<Renderer>().material.color = new Color(Random.Range(0.3f, 1f), Random.Range(0.3f, 1f), Random.Range(0.3f, 1f));
    }
}