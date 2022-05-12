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
    public Quests.Quest[] AllQuests;
    public static Item[] Items = new Item[5];
    public TMP_Text DescriptionPanel;
    public GameObject ObjectivesBox;

    // Inventory
    public Image[] ButtonImages;
    public Button[] Buttons;

    [System.Obsolete]
    public void Start()
    {
        MenuOpen = false;
        UpdateInventory();

        // starting the text box with the current quest
        DescriptionPanel.SetText(ChosenQuest.MenuDescription);

        // find objectives box
        ObjectivesBox = GameObject.Find("Objective Background");

        // set the quests to update as the game progresses
        foreach (Quests.Quest quest in AllQuests)
        {
            quest.SetDirty();
        }
    }

    public void MenuButtonUpdate()
    {
        if (MenuOpen)
        {
            MenuUI.SetActive(false);
            MenuOpen = false;
            ObjectivesBox.SetActive(true);
        }
        else
        {
            UpdateSelectedQuestTogglesOnLoad();
            MenuUI.SetActive(true);
            MenuOpen = true;
            ObjectivesBox.SetActive(false);
        }
    }

    public void UpdateSelectedQuestTogglesOnLoad()
    {
        foreach(Toggle t in QuestToggles)
        {
            t.isOn = false;
        }
        for(int i = 0; i < QuestToggles.Length; i++)
        {
            if (ChosenQuest == AllQuests[i])
            {
                QuestToggles[i].isOn = true;
            }
            if (!AllQuests[i].IsActive)
            {
                QuestToggles[i].interactable = false;
            }
            else
            {
                QuestToggles[i].interactable = true;
            }
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
                break;
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

                    string itemtext = IngameMenu.Items[i].Name + "\n\n" + IngameMenu.Items[i].Description;

                    UnityAction action = () =>
                    {
                        activeMenu.DescriptionPanel.SetText(itemtext);
                    };

                    activeMenu.Buttons[i].onClick.AddListener(action);
                }
            }
        }
    }
}
