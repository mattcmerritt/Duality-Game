using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [System.Serializable]
    public class DecisionBuilder 
    {
        public string Question;
        public Character Speaker;
        public string[] Options;
        // ideally, this should be just ConversationBuilder
        public EndingConversationBuilder[] BranchingConversations;

        public IDialogueElement Build()
        {
            /*
            Decision d = new Decision(Question, Speaker);
            d.Options = Options;
            
            IDialogueElement[] branches = new DialogueElement[BranchingConversations.Length];
            for (int i = 0; i < branches.Length; i++)
            {
                branches[i] = BranchingConversations[i].Build();
            }
            d.Branches = branches;

            return d;
            */
            return null;
        }
    }
}