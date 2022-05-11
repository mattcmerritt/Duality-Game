using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class IngameMenu : MonoBehaviour
{
    public bool MenuOpen;
    public GameObject MenuUI;
    public static Quests.Quest ChosenQuest; // might need to write this to session storage to persist between scenes
    public Toggle[] QuestToggles;
    public Quests.Quest UnpackingQuest, MayorQuest, MartinQuest;
    public static Item[] Items = new Item[5];
    public TMP_Text DescriptionPanel;

    // Inventory
    public Image[] ButtonImages;
    public Button[] Buttons;

    public void Start()
    {
        MenuOpen = false;
        UpdateInventory();

        // starting the text box with the current quest
        DescriptionPanel.SetText(ChosenQuest.MenuDescription);
    }

    public void MenuButtonUpdate()
    {
        if (MenuOpen)
        {
            MenuUI.SetActive(false);
            MenuOpen = false;
        }
        else
        {
            UpdateSelectedQuestTogglesOnLoad();
            MenuUI.SetActive(true);
            MenuOpen = true;
        }
    }

    public void UpdateSelectedQuestTogglesOnLoad()
    {
        foreach(Toggle t in QuestToggles)
        {
            t.isOn = false;
        }
        if (ChosenQuest == UnpackingQuest)
        {
            QuestToggles[0].isOn = true;
        }
        else if (ChosenQuest == MayorQuest)
        {
            QuestToggles[1].isOn = true;
        }
        else if (ChosenQuest == MartinQuest)
        {
            QuestToggles[2].isOn = true;
        }
        else
        {
            // no quest selected, do nothing
        }
    }

    public void SetSelectedQuest(Quests.Quest toggleQuest)
    {
        ChosenQuest = toggleQuest;
        GameObject.FindObjectOfType<Quests.QuestManager>().UpdateText();

        DescriptionPanel.SetText(ChosenQuest.MenuDescription);
    }

    // TODO: implement with Item instead of string
    public static void AddItem(Item item)
    {
        // fill first empty inventory spot
        for (int i = 0; i < IngameMenu.Items.Length; i++)
        {
            if (IngameMenu.Items[i] == null)
            {
                IngameMenu.Items[i] = item;
            }
        }

        UpdateInventory();
    }

    public static void UpdateInventory()
    {
        // method needs to be static, so this needs to find the instance of itself to work with
        IngameMenu activeMenu = FindObjectOfType<IngameMenu>();
        
        if (activeMenu != null)
        {
            for (int i = 0; i < IngameMenu.Items.Length; i++)
            {
                if (IngameMenu.Items[i] != null)
                {
                    activeMenu.ButtonImages[i].sprite = IngameMenu.Items[i].Image;

                    UnityAction action = () =>
                    {
                        activeMenu.DescriptionPanel.SetText(IngameMenu.Items[i].Name + "\n\n" + IngameMenu.Items[i].Description);
                    };

                    activeMenu.Buttons[i].onClick.AddListener(action);
                }
            }
        }
    }
}
