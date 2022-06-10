using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public GameObject Panel_Error;
    public Image progressBar;
    public Text progressText;
    private float progress;
    public Color[] colors;

    void Start()
    {
        progressBar.color = colors[PlayerPrefs.GetInt("ProgressBar")];
        PlayerPrefs.SetInt("ProgressBar", PlayerPrefs.GetInt("ProgressBar") + 1);
        if (PlayerPrefs.GetInt("ProgressBar") > colors.Length - 1)
            PlayerPrefs.SetInt("ProgressBar", 0);
        DontDestroyOnLoad(gameObject);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        for (int i = 1; i < 6; i++)
            yield return StartCoroutine(LoadAsynchronoualy(i));
        Destroy(gameObject);
    }

    private IEnumerator LoadAsynchronoualy(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            progress = Mathf.Clamp01(operation.progress / 1);
            progressText.text = Convert.ToInt32(20 * (sceneIndex - 1 + progress)) + "%";
            progressBar.fillAmount = 20 * (sceneIndex - 1 + progress) / 100;
            yield return null;
        }
    }
}