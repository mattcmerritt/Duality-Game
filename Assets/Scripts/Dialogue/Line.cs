using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Line</c> is the simplest implementation of <c>DialogueElement</c> which represents a single
/// message of displayable text.
/// </summary>
namespace Dialogue
{
    [CreateAssetMenu(menuName = "Line", fileName = "Line")]
    public class Line : ScriptableObject, IDialogueElement
    {
        [TextArea] public string Text;
        public Character Speaker;
        public IDialogueElement Next;
        public bool Italic;

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