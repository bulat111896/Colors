using UnityEngine;

public class SelectModels : MonoBehaviour
{
    public GameObject _500, Diamond, Check, Select;
    public string nowModel;
    private int i, a;

    private void OnTrigger(bool a, bool b, bool c, bool d)
    {
        Select.SetActive(a);
        _500.SetActive(b);
        Diamond.SetActive(c);
        Check.SetActive(d);
    }

    void OnTriggerEnter(Collider other)
    {
        other.transform.position += new Vector3(0, 0.3f, 0);
        other.transform.localScale += new Vector3(30, 30, 30);
        nowModel = other.gameObject.name;
        for (i = 0; i < 10; i++)
            if (nowModel == "BoxCollider " + i)
                a = i;
        if (PlayerPrefs.GetInt(other.gameObject.name) == 1)
        {
            if (PlayerPrefs.GetInt("Select") == a)
                OnTrigger(false, false, false, true);
            else
                OnTrigger(true, false, false, false);
        }
        else
            OnTrigger(false, true, true, false);
    }

    void OnTriggerExit(Collider other)
    {
        other.transform.position -= new Vector3(0, 0.3f, 0);
        other.transform.localScale -= new Vector3(30, 30, 30);
    }
}