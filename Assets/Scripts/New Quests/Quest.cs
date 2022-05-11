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
            foreach (Task task in Tasks)
            {
                task.Setup();
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
                if (!prev)
                {
                    // undoing invalid progress
                    for (int i = 0; i < task.TriggerStatuses.Length; i++)
                    {
                        task.TriggerStatuses[i] = false;
                    }
                    task.Complete = false;
                    task.Progress = 0;
                }

                prev = task.Complete;
            }
        }
    }
}
