using UnityEngine;

public class Animation : MonoBehaviour
{
    private bool a = true;
    private float speed = 0.2f;
    private Vector3 target = new Vector3(0, 1, 3), offset;

    void FixedUpdate()
    {
        if (a)
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position == target)
        {
            if (target.y != 0.5f)
                target.y = 0.5f;
            else
                target.y = 1;
            speed = 0.2f;
        }
        transform.Rotate(Vector3.up * 0.2f);
    }

    void OnMouseDown()
    {
        a = false;
        speed = 2.5f;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }

    void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) + offset;
    }

    void OnMouseUp()
    {
        a = true;
    }
}