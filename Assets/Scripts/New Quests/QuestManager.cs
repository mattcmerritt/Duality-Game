using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Quests
{
    public class QuestManager : MonoBehaviour
    {
        public Quest[] AllQuests;
        public TMP_Text ObjectivesText;

        public void Awake()
        {
            foreach (Quest quest in AllQuests)
            {
                if (quest.IsActive)
                {
                    quest.SetupAllTasks();
                }
            }
            UpdateText();
        }

        public void Update()
        {
            foreach (Quest quest in AllQuests)
            {
                if (quest.IsActive)
                {
                    quest.UpdateCompletion();
                }
            }
            UpdateText();
        }

        public void UpdateText()
        {
            string objectives = "Objectives:\n";
            string obj = IngameMenu.ChosenQuest.GetObjectiveText();
            if (obj.Equals(""))
            {
                objectives += "Quest complete! Select a new quest in the menu.";
            }
            else
            {
                objectives += obj;
            }
            ObjectivesText.text = objectives;
        }

        public void ActivateQuest(int index)
        {
            AllQuests[index].IsActive = true;
        }
    }
}

