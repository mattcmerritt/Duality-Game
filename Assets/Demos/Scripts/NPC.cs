using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Dialogue data
    [SerializeField]
    private List<string> Lines;
    [SerializeField]
    private List<bool> SpokenByPlayer;
    private List<DialogueLine> DialogueItems;
    private DialogueUpdater DialogueUI;

    // NPC information
    [SerializeField]
    private string Name;
    [SerializeField]
    private Sprite Portrait;

    // Instance Data
    private bool SpokenWith;

    // Create a list of dialogue items for when the NPC is interacted with
    private void Start()
    {
        DialogueItems = new List<DialogueLine>();
        for (int i = 0; i < Lines.Count; i++)
        {
            if (!SpokenByPlayer[i])
            {
                DialogueItems.Add(new DialogueLine(Lines[i], Portrait, Name));
            }
            else
            {
                DialogueItems.Add(new DialogueLine(Lines[i], PlayerInteractions.Portrait, PlayerInteractions.Name));
            }
        }

        DialogueUI = FindObjectOfType<DialogueUpdater>();
    }

    public void StartConversation()
    {
        DialogueUI.StartDialogue(DialogueItems);

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

    public void ReplaceConversation(List<DialogueLine> newLines)
    {
        DialogueItems = newLines;
    }

    // TODO: override when necessary in child classes of NPC to create alternate ways of finishing a quest
    public bool CheckTaskComplete()
    {
        return CheckSpokenWith();
    }

}
