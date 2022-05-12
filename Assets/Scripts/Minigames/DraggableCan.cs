using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableCan : MonoBehaviour
{
    public Vector3 Offset;
    public Rigidbody2D Rb;

    // Some sources used:
    // https://answers.unity.com/questions/1138645/how-do-i-drag-a-sprite-around.html

    public void OnMouseDown()
    {
        Offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rb.bodyType = RigidbodyType2D.Static;
    }

    public void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Offset;

        if (Input.GetMouseButton(1))
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, Vector3.zero, 0.01f);
        }
    }

    public void OnMouseUp()
    {
        Rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
