using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Code adapted from https://www.youtube.com/watch?v=_nRzoTzeyxU

public class DialogueUpdater : MonoBehaviour
{
    public GameObject DialogueBox;
    public TMP_Text DialogueText;
    private List<string> RemainingMessages;

    // call this function to start a dialogue interaction
    public void StartDialogue(List<string> messages)
    {
        RemainingMessages = messages;
        DialogueBox.SetActive(true);
        if(RemainingMessages.Count > 0)
        {
            StartCoroutine(TypeText(RemainingMessages[0]));
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
        RemainingMessages.Clear();
        DialogueBox.SetActive(false);
        DialogueText.SetText("");
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
            if (RemainingMessages[0] != DialogueText.text)
            {
                DialogueText.SetText(RemainingMessages[0]);
            }
            else if (RemainingMessages.Count > 1)
            {
                RemainingMessages.RemoveAt(0);
                DialogueText.SetText("");
                StartCoroutine(TypeText(RemainingMessages[0]));
            }
            else
            {
                ClearDialogue();
            }
        }
    }
}
