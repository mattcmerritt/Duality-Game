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
        public List<string> RewardNames; // objects to activate on completion
        public List<string> RemovedNames; // objects to remove on completion

        public Task Prerequisite;

        public void Setup(Task prereq)
        {
            // adding a prereq task to prevent early triggers
            Prerequisite = prereq;

            TriggerStatuses = new bool[TriggerNames.Count];
            string savedProgress = PlayerPrefs.GetString(Name);
            string[] finishedTriggers = savedProgress.Split(',');
            foreach (string index in finishedTriggers)
            {
                if(index == "")
                {
                    continue;
                }
                TriggerStatuses[Int32.Parse(index)] = true;
            }
            UpdateCompletionValues();
        }

        // Update progress counter, and mark as complete if all steps are complete
        public void UpdateCompletion()
        {
            // if there is a trigger, let them handle completion, otherwise don't change it
            if (TriggerNames.Count > 0)
            {
                for (int i = 0; i < TriggerNames.Count; i++)
                {
                    GameObject currentTrigger = GameObject.Find(TriggerNames[i]);
                    if (currentTrigger != null && currentTrigger.GetComponent<Dialogue.NPC>().CheckTaskComplete())
                    {
                        TriggerStatuses[i] = true;
                    }
                }
            }
            UpdateCompletionValues();
        }

        public void UpdateCompletionValues()
        {
            // only go if prereq is met
            if (Prerequisite == null || Prerequisite.Complete)
            {
                // if there is a trigger, let them handle completion
                if (TriggerNames.Count > 0)
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
                    if (Progress == TriggerNames.Count && !Complete)
                    {
                        Complete = true;
                        for (int i = 0; i < RewardNames.Count; i++)
                        {
                            // enables all toggleable objects
                            Debug.LogWarning("Rewarded " + RewardNames[i]);
                            GameObject obj = GameObject.Find(RewardNames[i]);
                            if (obj != null)
                            {
                                obj.GetComponent<ITogglable>().Enable();
                            }
                        }

                        for (int i = 0; i < RemovedNames.Count; i++)
                        {
                            // disables all toggleable objects
                            Debug.LogWarning("Removed " + RemovedNames[i]);
                            GameObject obj = GameObject.Find(RemovedNames[i]);
                            if (obj != null)
                            {
                                obj.GetComponent<ITogglable>().Disable();
                            }
                        }
                    }

                    saveString = saveString.Substring(0, Mathf.Max(saveString.Length - 1, 0));
                    PlayerPrefs.SetString(Name, saveString);
                }
                // if not, completion will be handled by something else, but still deal with rewards and removing
                else
                {
                    if (Complete)
                    {
                        for (int i = 0; i < RewardNames.Count; i++)
                        {
                            // enables all toggleable objects
                            Debug.LogWarning("Rewarded " + RewardNames[i]);
                            GameObject obj = GameObject.Find(RewardNames[i]);
                            if (obj != null)
                            {
                                obj.GetComponent<ITogglable>().Enable();
                            }
                        }

                        for (int i = 0; i < RemovedNames.Count; i++)
                        {
                            // disables all toggleable objects
                            Debug.LogWarning("Removed " + RemovedNames[i]);
                            GameObject obj = GameObject.Find(RemovedNames[i]);
                            if (obj != null)
                            {
                                obj.GetComponent<ITogglable>().Disable();
                            }
                        }
                    }
                }
            } 
        }

        public void ForceComplete()
        {
            Complete = true;
            for (int i = 0; i < TriggerStatuses.Length; i++)
            {
                TriggerStatuses[i] = true;
            }
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

        public int GetNumberOfTriggers()
        {
            return TriggerNames.Count;
        }

    }
}
