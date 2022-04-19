using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Quests
{
    public class QuestManager : MonoBehaviour
    {
        public Quest UnpackingQuest;
        public Quest PapersQuest;
        public TMP_Text ObjectivesText;

        public void Start()
        {
            UnpackingQuest.SetupAllTasks();
            PapersQuest.SetupAllTasks();
            UpdateText();
        }

        public void Update()
        {
            UnpackingQuest.UpdateCompletion();
            PapersQuest.UpdateCompletion();
            UpdateText();
        }

        public void UpdateText()
        {
            string objectives = "Objectives:\n";
            objectives += UnpackingQuest.GetObjectiveText();
            objectives += PapersQuest.GetObjectiveText();
            ObjectivesText.text = objectives;
        }
    }
}

