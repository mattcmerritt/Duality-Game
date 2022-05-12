using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class NPC : MonoBehaviour, ITogglable
    {
        // Dialogue loading
        public Conversation ConversationObject;        

        // Dialogue data
        public IDialogueElement CurrentConversation;
        private DialogueUpdater DialogueUI;

        // Instance Data
        public bool SpokenWith;

        // Alternate Conversation
        public Conversation AlternateConversation;

        // Toggling Data
        public Collider2D Collider;
        public bool CurrentlyActive;

        // Replacement Dialogues
        public ReplaceDialogue[] Replacements;
        public InventoryDialogueSplit[] BranchingReplacements;

        // Create a list of dialogue items for when the NPC is interacted with
        private void Awake()
        {
            CurrentConversation = ConversationObject.BuildConversation();

            DialogueUI = FindObjectOfType<DialogueUpdater>();

            // only enabling NPCs if this flag is set
            // interactable objects handle this themselves
            if (GetComponent<InteractableObject>() == null)
            {
                Collider.enabled = CurrentlyActive;
            } 

            // replacing dialogue if needed
            if (Replacements != null)
            {
                foreach (ReplaceDialogue rep in Replacements)
                {
                    rep.Reload();
                }
            }
            if (BranchingReplacements != null)
            {
                foreach (InventoryDialogueSplit rep in BranchingReplacements)
                {
                    rep.Reload();
                }
            }
        }

        public void StartConversation()
        {
            DialogueUI.StartDialogue(CurrentConversation);

            SpokenWith = true;

            // swap the conversation to the alt conversation for the next time
            if (AlternateConversation != null)
            {
                ReplaceConversation(AlternateConversation, null);
            }

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

        public void SetSpokenWith(bool val)
        {
            SpokenWith = val;
        }

        public void ReplaceConversation(Conversation newConversation, Conversation altConversation)
        {
            Debug.Log("Replacing with " + newConversation.name);
            CurrentConversation = newConversation.BuildConversation();
            AlternateConversation = altConversation;
        }

        // TODO: override when necessary in child classes of NPC to create alternate ways of finishing a quest
        public bool CheckTaskComplete()
        {
            return CheckSpokenWith();
        }

        public void Enable()
        {
            CurrentlyActive = true;

            Collider.enabled = true; // enable collision for interaction
        }

        public void Disable()
        {
            CurrentlyActive = false;

            Collider.enabled = false; // disable collision for interaction
        }
    }
}

