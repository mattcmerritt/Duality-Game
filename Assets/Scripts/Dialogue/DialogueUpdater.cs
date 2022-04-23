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
        private IDialogueElement ActiveConversation;
        public bool DialogueActive = false;

        private Coroutine WritingCoroutine;

        // call this function to start a dialogue interaction
        public void StartDialogue(IDialogueElement activeConversation)
        {
            DialogueActive = true;
            // Taking control away from the player
            FindObjectOfType<PlayerMovement>().Freeze();

            ActiveConversation = activeConversation;
            DialogueBox.SetActive(true);
            OptionSelect.SetActive(true);
            if (ActiveConversation != null)
            {
                SpeakerName.SetText(ActiveConversation.GetSpeaker().Name);
                SpeakerImage.sprite = ActiveConversation.GetSpeaker().Portrait;
                WritingCoroutine = StartCoroutine(TypeText(ActiveConversation.GetText()));
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
                if (ActiveConversation.GetText() != DialogueText.text)
                {
                    DialogueText.SetText(ActiveConversation.GetText());
                }
                else if (ActiveConversation is Decision)
                {
                    Debug.Log("Decision reached, this cannot be skipped.");
                }
                else if (ActiveConversation.GetNext() != null)
                {
                    ActiveConversation = ActiveConversation.GetNext();
                    DialogueText.SetText("");
                    SpeakerName.SetText(ActiveConversation.GetSpeaker().Name);
                    SpeakerImage.sprite = ActiveConversation.GetSpeaker().Portrait;
                    StopCoroutine(WritingCoroutine);
                    WritingCoroutine = StartCoroutine(TypeText(ActiveConversation.GetText()));
                }
                else
                {
                    ClearDialogue();
                }
            }

            if (ActiveConversation is Decision)
            {
                // Debug.Log("Reached Decision");
                if (ActiveConversation.GetNext() != null)
                {
                    ActiveConversation = ActiveConversation.GetNext();
                    DialogueText.SetText("");
                    SpeakerName.SetText(ActiveConversation.GetSpeaker().Name);
                    SpeakerImage.sprite = ActiveConversation.GetSpeaker().Portrait;
                    StopCoroutine(WritingCoroutine);
                    WritingCoroutine = StartCoroutine(TypeText(ActiveConversation.GetText()));
                }
                else
                {
                    FindObjectOfType<OptionSelect>().StartDecision((Decision)ActiveConversation);
                }
            }
        }
    }
}
