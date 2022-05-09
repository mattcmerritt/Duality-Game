using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUIComponent : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private float OffsetX, OffsetY;

    // Some sources used:
    // https://answers.unity.com/questions/1095047/detect-mouse-events-for-ui-canvas.html
    // https://docs.unity3d.com/2018.1/Documentation/ScriptReference/EventSystems.IPointerDownHandler.html
    public void OnPointerDown(PointerEventData eventData)
    {
        OffsetX = GetComponent<RectTransform>().anchoredPosition.x - (Input.mousePosition.x - 480); // size of canvas is 960
        OffsetY = GetComponent<RectTransform>().anchoredPosition.y - (Input.mousePosition.y - 300); // size of canvas is 600
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(Input.mousePosition.x + OffsetX, Input.mousePosition.y + OffsetY, 0), Quaternion.identity);
    }
}
