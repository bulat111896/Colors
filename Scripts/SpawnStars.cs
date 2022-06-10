using System.Collections;
using UnityEngine;

public class SpawnStars : MonoBehaviour
{
    public GameObject star;
    private int b = 3, i, a = 20;


    void Start()
    {
        StartCoroutine(_star());
    }

    private IEnumerator _star()
    {
        while (true)
        {
            if (PlayerPrefs.GetInt("Mode") == 1 && PlayerPrefs.GetInt("Toggle_2") == 0)
                StartCoroutine(spawn());
            yield return new WaitForSeconds(4);
        }
    }

    IEnumerator spawn()
    {
        while (true)
        {
            Instantiate(star, Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 10)), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            i++;
            if (i > a)
            {
                a = a * 3;
                if (b == 3)
                    b = 20;
                else
                    b = b * 2;
            }
            yield return new WaitForSeconds(b);
        }
    }
}