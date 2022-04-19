using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Dialogue
{
    // Code adapted from https://www.youtube.com/watch?v=_nRzoTzeyxU

    public class DialogueUpdater : MonoBehaviour
    {
        public GameObject DialogueBox;
        public GameObject OptionSelect;
        public TMP_Text DialogueText;
        public TMP_Text SpeakerName;
        public Image SpeakerImage;
        private DialogueElement ActiveConversation;
        public bool DialogueActive = false;

        private Coroutine WritingCoroutine;

        // call this function to start a dialogue interaction
        public void StartDialogue(DialogueElement activeConversation)
        {
            DialogueActive = true;
            // Taking control away from the player
            FindObjectOfType<PlayerMovement>().Freeze();

            ActiveConversation = activeConversation;
            DialogueBox.SetActive(true);
            OptionSelect.SetActive(true);
            if (ActiveConversation != null)
            {
                SpeakerName.SetText(ActiveConversation.Speaker.Name);
                SpeakerImage.sprite = ActiveConversation.Speaker.Portrait;
                WritingCoroutine = StartCoroutine(TypeText(ActiveConversation.Text));
            }
            else
            {
                ClearDialogue();
            }
        }

        IEnumerator TypeText(string message)
        {
            char[] MessageChars = message.ToCharArray();
            foreach (char character in MessageChars) {
                DialogueText.SetText(DialogueText.text + character);
                yield return new WaitForSeconds(0.05f);
            }
        }

        public void ClearDialogue()
        {
            // Giving the player back control of the character
            FindObjectOfType<PlayerMovement>().Unfreeze();

            ActiveConversation = null;
            DialogueBox.SetActive(false);
            OptionSelect.SetActive(false);
            DialogueText.SetText("");
            SpeakerName.SetText("");
            DialogueActive = false;
        }

        // this isn't used, but could be
        public bool CheckIfDialogueOpen()
        {
            return DialogueBox.activeSelf;
        }

        // check for spacebar input
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && DialogueBox.activeSelf)
            {
                StopAllCoroutines();
                if (ActiveConversation.Text != DialogueText.text)
                {
                    DialogueText.SetText(ActiveConversation.Text);
                }
                else if (ActiveConversation is Decision)
                {
                    Debug.Log("Decision reached, this cannot be skipped.");
                }
                else if (ActiveConversation.Next != null)
                {
                    ActiveConversation = ActiveConversation.Next;
                    DialogueText.SetText("");
                    SpeakerName.SetText(ActiveConversation.Speaker.Name);
                    SpeakerImage.sprite = ActiveConversation.Speaker.Portrait;
                    StopCoroutine(WritingCoroutine);
                    WritingCoroutine = StartCoroutine(TypeText(ActiveConversation.Text));
                }
                else
                {
                    ClearDialogue();
                }
            }

            if (ActiveConversation is Decision)
            {
                // Debug.Log("Reached Decision");
                if (ActiveConversation.Next != null)
                {
                    ActiveConversation = ActiveConversation.Next;
                    DialogueText.SetText("");
                    SpeakerName.SetText(ActiveConversation.Speaker.Name);
                    SpeakerImage.sprite = ActiveConversation.Speaker.Portrait;
                    StopCoroutine(WritingCoroutine);
                    WritingCoroutine = StartCoroutine(TypeText(ActiveConversation.Text));
                }
                else
                {
                    FindObjectOfType<OptionSelect>().StartDecision((Decision)ActiveConversation);
                }
            }
        }
    }
}
