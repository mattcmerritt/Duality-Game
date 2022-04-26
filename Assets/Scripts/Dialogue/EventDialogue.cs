using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class EventDialogue : MonoBehaviour
    {
        [SerializeField] private Conversation MessageConversation;
        [SerializeField] private bool IsCollisionBased;

        private DialogueUpdater DialogueUI;

        private void Start()
        {
            DialogueUI = FindObjectOfType<DialogueUpdater>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsCollisionBased)
            {
                //StartConversation();
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            Debug.Log("Collision Occurring");
        }

        public void StartConversation()
        {
            DialogueUI.StartDialogue(MessageConversation.BuildConversation());
        }

        public void DisableEvent()
        {
            this.enabled = false;
        }
    }
}