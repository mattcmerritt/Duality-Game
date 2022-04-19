using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Decision</c> is a <c>DialogueElement</c> which represents a single decision point in the
/// conversation where the dialogue splits into branches.
/// Rather than using a singular <value>Next</value> value, there is an array of next options in the 
/// <value>Branches</value>, along with the <value>Options</value> array which contains the text to
/// put in each button on the UI.
/// </summary>
namespace Dialogue
{
    [System.Serializable]
    public class Decision : DialogueElement
    {
        public string[] Options;
        public DialogueElement[] Branches;

        public Decision(string text, Character speaker) : base(text, speaker) {}
        
    }
}