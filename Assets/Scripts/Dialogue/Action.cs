using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(menuName = "Action", fileName = "Action")]
    public class Action : ScriptableObject, IDialogueElement
    {
        public string ActionObjectName;

        public IDialogueElement Next;

        public void StartAction()
        {
            GameObject ActionObject = GameObject.Find(ActionObjectName);

            IActionObject action = ActionObject.GetComponent<IActionObject>();
            action.Act();
        }

        public string GetText() { return null; }
        public Character GetSpeaker() { return null; }
        public IDialogueElement GetNext() { return Next; }
        public void SetNext(IDialogueElement next) { Next = next; }
    }
}