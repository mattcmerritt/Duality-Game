using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Line</c> is the simplest implementation of <c>DialogueElement</c> which represents a single
/// message of displayable text.
/// </summary>
namespace Dialogue
{
    [System.Serializable]
    public class Line : DialogueElement
    {
        public Line(string text, Character speaker) : base(text, speaker) {}
        public Line(string text, Character speaker, DialogueElement next) : this(text, speaker) {}
    }
}