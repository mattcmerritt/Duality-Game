using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [System.Serializable]
    public class ConversationBuilder
    {
        public List<Line> Lines;
        public bool HasDecision;
        public DecisionBuilder Decision;

        public DialogueElement Build() 
        {
            for (int i = 0; i < Lines.Count - 1; i++)
            {
                Lines[i].AddNext(Lines[i+1]);
            }

            if (HasDecision)
            {
                Lines[Lines.Count - 1].AddNext(Decision.Build());
            }
            
            return Lines[0];
        }
    }
}