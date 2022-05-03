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
            foreach (Quest quest in AllQuests)
            {
                if (quest.IsActive)
                {
                    objectives += quest.GetObjectiveText();
                }
            }
            ObjectivesText.text = objectives;
        }

        public void ActivateQuest(int index)
        {
            AllQuests[index].IsActive = true;
        }
    }
}

