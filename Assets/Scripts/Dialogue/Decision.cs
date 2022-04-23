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
    [CreateAssetMenu(menuName = "Decision", fileName = "Decision")]
    public class Decision : ScriptableObject, IDialogueElement
    {
        [TextArea] public string Text;
        public Character Speaker;
        public IDialogueElement Next;

        public string[] Options;
        public Conversation[] Branches;
        
        public string GetText() 
        {
            return Text;
        }

        public Character GetSpeaker()
        {
            return Speaker;
        }

        public IDialogueElement GetNext()
        {
            return Next;
        }

        public void SetNext(IDialogueElement next)
        {
            Next = next;
        }
    }
}