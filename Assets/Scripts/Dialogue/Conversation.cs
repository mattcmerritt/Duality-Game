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
        public bool HasNextConversation;
        public Conversation NextConversation;
        public bool HasActions;
        public List<Action> Actions;

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
            else if (HasNextConversation)
            {
                Lines[Lines.Count - 1].SetNext(NextConversation.BuildConversation());
            }
            else if (HasActions)
            {
                Lines[Lines.Count - 1].SetNext(Actions[0]);
                for (int i = 0; i < Actions.Count - 1; i++)
                {
                    Actions[i].SetNext(Actions[i + 1]);
                }
                
            }

            return Lines[0];
        }
    }
}