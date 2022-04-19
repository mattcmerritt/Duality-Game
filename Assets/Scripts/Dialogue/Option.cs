using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Option : MonoBehaviour
{
    private RectTransform Transform;
    [SerializeField]
    private GameObject Textbox;

    private void Awake()
    {
        Transform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        CheckSize();
        transform.localScale = Vector3.one;
    }

    public void SetMessage(string msg)
    {
        TMP_Text tbText = Textbox.GetComponent<TMP_Text>();
        tbText.text = msg;

        RectTransform tbRect = Textbox.GetComponent<RectTransform>();
        Transform.sizeDelta = new Vector2(tbRect.rect.width, tbRect.rect.height);
    }

    public void CheckSize()
    {
        RectTransform tbRect = Textbox.GetComponent<RectTransform>();
        Transform.sizeDelta = new Vector2(tbRect.rect.width, tbRect.rect.height);
    }

    public void SetLocation(float x, float y)
    {
        Transform.anchoredPosition = new Vector3(x, y, 0f);
    }

    public float GetHeight()
    {
        return Transform.rect.height;
    }

    public void SetText(string msg)
    {
        GetComponentInChildren<TMP_Text>().text = msg;
    }
}
