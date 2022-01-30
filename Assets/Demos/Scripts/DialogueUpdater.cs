using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Code adapted from https://www.youtube.com/watch?v=_nRzoTzeyxU

public class DialogueUpdater : MonoBehaviour
{
    public GameObject DialogueBox;
    public TMP_Text DialogueText;
    public TMP_Text SpeakerName;
    public Image SpeakerImage;
    private List<DialogueLine> RemainingMessages;
    public bool DialogueActive = false;

    // call this function to start a dialogue interaction
    public void StartDialogue(List<DialogueLine> messages)
    {
        DialogueActive = true;
        // Taking control away from the player
        FindObjectOfType<PlayerMovement>().Freeze();

        RemainingMessages = new List<DialogueLine>(messages);
        DialogueBox.SetActive(true);
        if(RemainingMessages.Count > 0)
        {
            SpeakerName.SetText(RemainingMessages[0].Name);
            SpeakerImage.sprite = RemainingMessages[0].Portrait;
            StartCoroutine(TypeText(RemainingMessages[0].Text));
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

        RemainingMessages.Clear();
        DialogueBox.SetActive(false);
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
            if (RemainingMessages[0].Text != DialogueText.text)
            {
                DialogueText.SetText(RemainingMessages[0].Text);
            }
            else if (RemainingMessages.Count > 1)
            {
                RemainingMessages.RemoveAt(0);
                DialogueText.SetText("");
                SpeakerName.SetText(RemainingMessages[0].Name);
                SpeakerImage.sprite = RemainingMessages[0].Portrait;
                StartCoroutine(TypeText(RemainingMessages[0].Text));
            }
            else
            {
                ClearDialogue();
            }
        }
    }
}
