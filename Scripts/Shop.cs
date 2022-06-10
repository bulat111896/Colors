using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject Models, arrow1, arrow2;
    private Vector3 offset;
    private bool a;

    void Update()
    {
        if (a == true)
        {
            if (Models.transform.position.x > 0)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(0, 0, Models.transform.position.z), Time.deltaTime * 20);
            else if (Models.transform.position.x < 0 && Models.transform.position.x > -1)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(0, 0, Models.transform.position.z), Time.deltaTime * 5);
            else if (Models.transform.position.x < -2 && Models.transform.position.x > -3 || Models.transform.position.x > -2 && Models.transform.position.x < -1)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(-2, 0, Models.transform.position.z), Time.deltaTime * 5);
            else if (Models.transform.position.x < -4 && Models.transform.position.x > -5 || Models.transform.position.x > -4 && Models.transform.position.x < -3)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(-4, 0, Models.transform.position.z), Time.deltaTime * 5);
            else if (Models.transform.position.x < -6 && Models.transform.position.x > -7 || Models.transform.position.x > -6 && Models.transform.position.x < -5)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(-6, 0, Models.transform.position.z), Time.deltaTime * 5);
            else if (Models.transform.position.x < -8 && Models.transform.position.x > -9 || Models.transform.position.x > -8 && Models.transform.position.x < -7)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(-8, 0, Models.transform.position.z), Time.deltaTime * 5);
            else if (Models.transform.position.x < -10 && Models.transform.position.x > -11 || Models.transform.position.x > -10 && Models.transform.position.x < -9)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(-10, 0, Models.transform.position.z), Time.deltaTime * 5);
            else if (Models.transform.position.x < -12 && Models.transform.position.x > -13 || Models.transform.position.x > -12 && Models.transform.position.x < -11)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(-12, 0, Models.transform.position.z), Time.deltaTime * 5);
            else if (Models.transform.position.x < -14 && Models.transform.position.x > -15 || Models.transform.position.x > -14 && Models.transform.position.x < -13)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(-14, 0, Models.transform.position.z), Time.deltaTime * 5);
            else if (Models.transform.position.x < -16 && Models.transform.position.x > -17 || Models.transform.position.x > -16 && Models.transform.position.x < -15)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(-16, 0, Models.transform.position.z), Time.deltaTime * 5);
            else if (Models.transform.position.x > -18 && Models.transform.position.x < -17)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(-18, 0, Models.transform.position.z), Time.deltaTime * 5);
            else if (Models.transform.position.x < -18)
                Models.transform.position = Vector3.MoveTowards(Models.transform.position, new Vector3(-18, 0, Models.transform.position.z), Time.deltaTime * 20);
        }
        if (Models.transform.position.x < -18 || Models.transform.position.x > -18.00001f && Models.transform.position.x < -17.99999f)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(true);
        }
        else
            arrow1.SetActive(true);
        if (Models.transform.position.x > 0 || Models.transform.position.x < 0.00001f && Models.transform.position.x > -0.00001f)
        {
            arrow1.SetActive(true);
            arrow2.SetActive(false);
        }
        else
            arrow2.SetActive(true);

        if (Models.transform.position.x < -19)
            Models.transform.position = new Vector3(-19, 0, 5);
        else if (Models.transform.position.x > 1)
            Models.transform.position = new Vector3(1, 0, 5);
    }

    void OnMouseDown()
    {
        a = false;
        offset = Models.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x * 2.4f, 0, 0));
    }

    void OnMouseDrag()
    {
        Models.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x * 2.4f, 0, 0)) + offset;
    }

    void OnMouseUp()
    {
        a = true;
    }
}