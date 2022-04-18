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

        public string UpdateObjectiveText()
        {
            foreach (Task task in Tasks)
            {
                if (!task.GetCompletion())
                {
                    return task.GetDescription();
                }
            }
            return "ERROR";
        }

        public void UpdateCompletion()
        {
            foreach (Task task in Tasks)
            {
                task.UpdateCompletion();
            }
        }
    }
}
