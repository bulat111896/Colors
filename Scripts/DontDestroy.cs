using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Audio").Length == 2 || GameObject.FindGameObjectsWithTag("Untagged").Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}