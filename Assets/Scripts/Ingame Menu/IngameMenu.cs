using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenu : MonoBehaviour
{
    public bool MenuOpen;
    public GameObject MenuUI;

    public void Start()
    {
        MenuOpen = false;
    }

    public void MenuButtonUpdate()
    {
        if(MenuOpen)
        {
            MenuUI.SetActive(false);
        }
        else
        {
            MenuUI.SetActive(true);
        }
    }
}
