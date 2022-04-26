using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class NPC : MonoBehaviour
    {
        // Dialogue loading
        public Conversation ConversationObject;        

        // Dialogue data
        public IDialogueElement CurrentConversation;
        private DialogueUpdater DialogueUI;

        // Instance Data
        private bool SpokenWith;

        // Create a list of dialogue items for when the NPC is interacted with
        private void Start()
        {
            CurrentConversation = ConversationObject.BuildConversation();

            DialogueUI = FindObjectOfType<DialogueUpdater>();
        }

        public void StartConversation()
        {
            DialogueUI.StartDialogue(CurrentConversation);

            SpokenWith = true;

            // handling special interactions
            InteractableObject obj = GetComponent<InteractableObject>();
            if (obj != null)
            {
                obj.InteractWith();
            }
        }

        public bool CheckSpokenWith()
        {
            return SpokenWith;
        }

        public void ReplaceConversation(IDialogueElement newConversation)
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

