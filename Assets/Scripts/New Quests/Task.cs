using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Quests
{
    [CreateAssetMenu(menuName = "Task", fileName = "Task")]
    public class Task : ScriptableObject
    {
        public string Name;
        [TextArea] public string Description;
        public List<string> TriggerNames;
        public int Progress;
        public bool Complete = false;

        public bool[] TriggerStatuses;

        public void Setup()
        {
            TriggerStatuses = new bool[TriggerNames.Count];
            string savedProgress = PlayerPrefs.GetString(Name);
            string[] finishedTriggers = savedProgress.Split(',');
            foreach (string index in finishedTriggers)
            {
                TriggerStatuses[Int32.Parse(index)] = true;
            }
            UpdateCompletionValues();
        }

        // Update progress counter, and mark as complete if all steps are complete
        public void UpdateCompletion()
        {
            
            for (int i = 0; i < TriggerNames.Count; i++)
            {
                GameObject currentTrigger = GameObject.Find(TriggerNames[i]);
                if(currentTrigger != null && currentTrigger.GetComponent<NPC>().CheckTaskComplete())
                {
                    TriggerStatuses[i] = true;
                }
            }

            UpdateCompletionValues();
        }

        public void UpdateCompletionValues()
        {
            int count = 0;
            string saveString = "";
            for (int i = 0; i < TriggerStatuses.Length; i++)
            {
                if (TriggerStatuses[i])
                {
                    count++;
                    saveString += i + ",";
                }
            }
            Progress = count;
            if (Progress == TriggerNames.Count)
            {
                Complete = true;
            }

            saveString = saveString.Substring(0, saveString.Length - 1);
            PlayerPrefs.SetString(Name, saveString);
        }

        public string GetName()
        {
            return Name;
        }

        public string GetDescription()
        {
            return Description;
        }

        public int GetProgress()
        {
            return Progress;
        }

        public bool GetCompletion()
        {
            return Complete;
        }

    }
}
