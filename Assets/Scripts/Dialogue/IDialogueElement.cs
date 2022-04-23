using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue 
{
    public interface IDialogueElement 
    {
        public string GetText();
        public Character GetSpeaker();
        public IDialogueElement GetNext();
        public void SetNext(IDialogueElement next);
    }
}