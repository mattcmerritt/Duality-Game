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
        public Quest CatQuest;
        public TMP_Text ObjectivesText;

        public void Awake()
        {
            UnpackingQuest.SetupAllTasks();
            PapersQuest.SetupAllTasks();
            CatQuest.SetupAllTasks();
            UpdateText();
        }

        public void Update()
        {
            UnpackingQuest.UpdateCompletion();
            PapersQuest.UpdateCompletion();
            CatQuest.UpdateCompletion();
            UpdateText();
        }

        public void UpdateText()
        {
            string objectives = "Objectives:\n";
            objectives += UnpackingQuest.GetObjectiveText();
            objectives += PapersQuest.GetObjectiveText();
            objectives += CatQuest.GetObjectiveText();
            ObjectivesText.text = objectives;
        }
    }
}

