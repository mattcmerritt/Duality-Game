using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    public DialogueUpdater Listener;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            //Listener.StartDialogue(new List<string> { "This is message 1.", "This is message 2.", "This is message 3." });
        }
    }
}
