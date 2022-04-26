using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class EventDialogue : MonoBehaviour, ITogglable
    {
        [SerializeField] private Conversation MessageConversation;
        [SerializeField] private bool IsCollisionBased;

        private DialogueUpdater DialogueUI;

        public bool IsEnabled;

        private void Start()
        {
            DialogueUI = FindObjectOfType<DialogueUpdater>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsEnabled)
            {
                if (IsCollisionBased)
                {
                    StartConversation();
                }
            }
        }

        public void StartConversation()
        {
            if (IsEnabled)
            {
                DialogueUI.StartDialogue(MessageConversation.BuildConversation());
            }
        }

        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }
    }
}