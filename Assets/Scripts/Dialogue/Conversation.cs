using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class Conversation : DialogueElement
    {
        public Conversation(string text, Character speaker) : base(text, speaker) {}
        public Conversation(string text, Character speaker, DialogueElement next) : this(text, speaker) {}
    }
}