using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [System.Serializable]
    public class EndingConversationBuilder
    {
        public List<Line> Lines;

        public DialogueElement Build()
        {
            for (int i = 0; i < Lines.Count - 1; i++)
            {
                Lines[i].AddNext(Lines[i + 1]);
            }

            return Lines[0];
        }
    }
}