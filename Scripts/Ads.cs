using System.Collections;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour
{
    private IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(150);
            ShowAdPlacementContent ad = null;
            while (ad == null)
            {
                if (Monetization.IsReady("video") && SceneManager.GetActiveScene().name != "play")
                {
                    ShowAdCallbacks options = new ShowAdCallbacks();
                    ad = Monetization.GetPlacementContent("video") as ShowAdPlacementContent;
                    ad.Show(options);
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("Ads") == 0)
        {
            Monetization.Initialize("3618991", false);
            StartCoroutine(Wait());
        }
    }
}