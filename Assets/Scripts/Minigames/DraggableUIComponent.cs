using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUIComponent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform Canvas;
    private float OffsetX, OffsetY;

    // Some sources used:
    // https://answers.unity.com/questions/1095047/detect-mouse-events-for-ui-canvas.html
    // https://docs.unity3d.com/2018.1/Documentation/ScriptReference/EventSystems.IPointerDownHandler.html
    public void OnPointerDown(PointerEventData eventData)
    {
        OffsetX = GetComponent<RectTransform>().anchoredPosition.x - (Input.mousePosition.x - Canvas.anchoredPosition.x); // default size of canvas is 960
        OffsetY = GetComponent<RectTransform>().anchoredPosition.y - (Input.mousePosition.y - Canvas.anchoredPosition.y); // default size of canvas is 600
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OffsetX = 0;
        OffsetY = 0;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(Input.mousePosition);
        GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(Input.mousePosition.x + OffsetX, Input.mousePosition.y + OffsetY, 0), Quaternion.identity);
    }
}
