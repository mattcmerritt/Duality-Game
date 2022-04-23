using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(menuName = "Conversation", fileName = "Conversation")]
    public class Conversation : ScriptableObject
    {
        public List<Line> Lines;
        public bool HasDecision;
        public Decision Decision;

        public IDialogueElement BuildConversation()
        {
            for (int i = 0; i < Lines.Count - 1; i++)
            {
                Lines[i].SetNext(Lines[i + 1]);
            }

            if (HasDecision)
            {
                Lines[Lines.Count - 1].SetNext(Decision);
            }

            return Lines[0];
        }
    }
}