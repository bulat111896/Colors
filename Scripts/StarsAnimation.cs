using UnityEngine;

public class StarsAnimation : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Destroy(gameObject, 5);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Mode") == 0 || PlayerPrefs.GetInt("Toggle_2") == 1)
            Destroy(gameObject);
        transform.position += transform.up * Time.deltaTime * 0.2f;
    }
}
