using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class NPC : Character
    {
        // Dialogue loading
        public ConversationBuilder Builder;        

        // Dialogue data
        public DialogueElement CurrentConversation;
        private DialogueUpdater DialogueUI;

        // Instance Data
        private bool SpokenWith;

        // Create a list of dialogue items for when the NPC is interacted with
        private void Start()
        {
            CurrentConversation = Builder.Build();

            DialogueUI = FindObjectOfType<DialogueUpdater>();
        }

        public void StartConversation()
        {
            DialogueUI.StartDialogue(CurrentConversation);

            SpokenWith = true;

            // handling special interactions
            BoxScript box = GetComponent<BoxScript>();
            if (box != null)
            {
                box.Check();
            }
        }

        public bool CheckSpokenWith()
        {
            return SpokenWith;
        }

        public void ReplaceConversation(DialogueElement newConversation)
        {
            CurrentConversation = newConversation;
        }

        // TODO: override when necessary in child classes of NPC to create alternate ways of finishing a quest
        public bool CheckTaskComplete()
        {
            return CheckSpokenWith();
        }
    }
}

