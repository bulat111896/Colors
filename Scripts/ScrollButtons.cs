using UnityEngine;

public class ScrollButtons : MonoBehaviour
{
    public GameObject Buttons, Text, Tim, Number_txt;
    private Vector3 offset, offset2, offset3;

    void Update()
    {
        if (Buttons.transform.position.x < -1.1)
        {
            Buttons.transform.position = new Vector3(-1.1f, -0.75f, -0.3f);
            Text.transform.position = new Vector3(0.65f, -0.775f, -4.7f);
            Number_txt.transform.position = new Vector3(-1.385f, -0.43f, -4.7f);
        }
        else if (Buttons.transform.position.x > 0)
        {
            Buttons.transform.position = new Vector3(0, -0.75f, -0.3f);
            Text.transform.position = new Vector3(1.747f, -0.775f, -4.7f);
            Number_txt.transform.position = new Vector3(-0.285f, -0.43f, -4.7f);
        }
    }

    void OnMouseDown()
    {
        offset = Buttons.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x * 1.8f, 0, 0));
        offset2 = Text.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x * 1.8f, 0, 0));
        offset3 = Number_txt.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x * 1.8f, 0, 0));
    }

    void OnMouseDrag()
    {
        Buttons.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x * 1.8f, 0, 0)) + offset;
        Text.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x * 1.8f, 0, 0)) + offset2;
        Number_txt.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x * 1.8f, 0, 0)) + offset3;
    }
}