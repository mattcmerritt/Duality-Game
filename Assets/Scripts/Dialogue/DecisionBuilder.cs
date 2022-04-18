using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [System.Serializable]
    public class DecisionBuilder 
    {
        public string Question;
        public NPC Speaker;
        public string[] Options;
        // ideally, this should be just ConversationBuilder
        public EndingConversationBuilder[] BranchingConversations;

        public DialogueElement Build()
        {
            Decision d = new Decision(Question, Speaker);
            d.Options = Options;
            
            DialogueElement[] branches = new DialogueElement[BranchingConversations.Length];
            for (int i = 0; i < branches.Length; i++)
            {
                branches[i] = BranchingConversations[i].Build();
            }
            d.Branches = branches;

            return d;
        }
    }
}