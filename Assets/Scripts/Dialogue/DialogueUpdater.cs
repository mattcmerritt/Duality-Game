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
        public bool WritingFirst = false;

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

            // starting the dialogue for the first message
            PrepareTextbox();
            RestartTyping();

            WritingFirst = true;
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

        // preparing the textbox with the current conversation's info
        private void PrepareTextbox()
        {
            // clearing the text
            DialogueText.SetText("");
            // getting character details
            SpeakerName.SetText(ActiveConversation.GetSpeaker().Name);
            SpeakerImage.sprite = ActiveConversation.GetSpeaker().Portrait;
        }

        private void RestartTyping()
        {
            // ending the previous coroutine if there was one
            if (WritingCoroutine != null)
            {
                StopCoroutine(WritingCoroutine);
            }
            // starting the new typing coroutine
            WritingCoroutine = StartCoroutine(TypeText(ActiveConversation.GetText()));
        }

        // check for spacebar input
        private void Update()
        {
            // special element handling
            if (ActiveConversation is Decision)
            {
                // if the user has selected an option, continue the dialogue from the new option
                if (ActiveConversation.GetNext() != null)
                {
                    ActiveConversation = ActiveConversation.GetNext();
                    PrepareTextbox();
                    RestartTyping();
                }
                // otherwise, activate the decision UI
                else
                {
                    FindObjectOfType<OptionSelect>().StartDecision((Decision)ActiveConversation);
                }
            }
            else if (ActiveConversation is Action)
            {
                // performing the action
                ((Action)ActiveConversation).StartAction();
                // moving the conversation along
                ActiveConversation = ActiveConversation.GetNext();
            }

            // ending the conversation if no lines remain
            if (ActiveConversation == null)
            {
                ClearDialogue();
            }

            // player control
            if (DialogueActive)
            {
                if (Input.GetKeyDown(KeyCode.Space) && DialogueBox.activeSelf)
                {
                    if (!WritingFirst)
                    {
                        // if we are still typing out the message
                        if (ActiveConversation.GetText() != DialogueText.text)
                        {
                            // stop the writing routine
                            StopCoroutine(WritingCoroutine);
                            // complete the message
                            DialogueText.SetText(ActiveConversation.GetText());
                        }
                        // else if text is fully typed
                        else
                        {
                            if (!(ActiveConversation is Decision))
                            {
                                ActiveConversation = ActiveConversation.GetNext();
                                // only load the next message is there is one
                                if (ActiveConversation != null && !(ActiveConversation is Action))
                                {
                                    PrepareTextbox();
                                    RestartTyping();
                                }
                            }
                        }
                    }
                    else
                    {
                        WritingFirst = false;
                    }
                }
            }
        }
    }
}
