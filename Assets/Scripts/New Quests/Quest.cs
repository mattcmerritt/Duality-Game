using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    [CreateAssetMenu(menuName = "Quest", fileName = "Quest")]
    public class Quest : ScriptableObject
    {
        public string Name;
        [TextArea] public string MenuDescription;
        public List<Task> Tasks;
        // TODO: add attribute for a quest reward here

        public bool IsActive;

        public void SetupAllTasks()
        {
            Tasks[0].Setup(null); // first task has no prereq
            for (int i = 1; i < Tasks.Count; i++)
            {
                Tasks[i].Setup(Tasks[i - 1]);
            }
        }

        public string GetObjectiveText()
        {
            foreach (Task task in Tasks)
            {
                if (!task.GetCompletion())
                {
                    return "- " + task.GetDescription() + (task.GetNumberOfTriggers() > 1 ? " (" + task.GetProgress() + "/" + task.GetNumberOfTriggers() + ")" : "") + "\n";
                }
            }
            return "";
        }

        public void UpdateCompletion()
        {
            bool prev = true;
            foreach (Task task in Tasks)
            {
                task.UpdateCompletion();

                // preventing sequence breaks
                if (!prev && task.Complete)
                {
                    Debug.LogWarning("Sequence break with " + task.Name + ", undoing");
                    // undoing invalid progress
                    for (int i = 0; i < task.TriggerStatuses.Length; i++)
                    {
                        task.TriggerStatuses[i] = false;
                    }
                    foreach (string name in task.TriggerNames)
                    {
                        GameObject currentTrigger = GameObject.Find(name);
                        currentTrigger.GetComponent<Dialogue.NPC>().SetSpokenWith(false);
                    }
                        task.Complete = false;
                    task.Progress = 0;
                }

                prev = task.Complete;
            }
        }
    }
}
