using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue 
{
    public abstract class DialogueElement 
    {
        public string Text;
        public Character Speaker;
        public DialogueElement Next;

        public DialogueElement(string text, Character speaker)
        {
            Text = text;
            Speaker = speaker;
        }

        public DialogueElement(string text, Character speaker, DialogueElement next) : this(text, speaker)
        {
            Next = next;
        }

        public void AddNext(DialogueElement next) 
        {
            Next = next;
        }

    }
}