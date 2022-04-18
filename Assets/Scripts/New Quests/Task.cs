using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    [CreateAssetMenu(menuName = "Task", fileName = "Task")]
    public class Task : ScriptableObject
    {
        public string Name;
        [TextArea] public string Description;
        public List<NPC> Triggers;
        public int Progress;
        public bool Complete = false;

        public void UpdateCompletion()
        {
            int count = 0;
            foreach (NPC trigger in Triggers)
            {
                if(trigger.CheckTaskComplete())
                {
                    count++;
                }
            }

            Progress = count;
            if(Progress == Triggers.Count)
            {
                Complete = true;
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

        public List<NPC> GetTriggers()
        {
            return Triggers;
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
