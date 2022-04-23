using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Dialogue
{
    public class OptionSelect : MonoBehaviour
    {
        private Decision ActiveDecision;
        [SerializeField] private GameObject ButtonPrefab;

        private List<GameObject> ActiveButtons;
        private bool WaitingOnPlayer;

        public void StartDecision(Decision decision)
        {
            if (!WaitingOnPlayer)
            {
                WaitingOnPlayer = true;
                ActiveButtons = new List<GameObject>();
                ActiveDecision = decision;

                for (int i = 0; i < ActiveDecision.Options.Length; i++)
                {
                    GameObject buttonObj = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity);
                    buttonObj.transform.SetParent(transform);
                    Option optionScript = buttonObj.GetComponent<Option>();
                    optionScript.SetText(ActiveDecision.Options[i]);

                    IDialogueElement correspondingDialogue = ActiveDecision.Branches[i].BuildConversation();
                    Button button = buttonObj.GetComponent<Button>();
                    UnityAction selectDialogue = () =>
                    {
                        // push corresponding dialogue to decision as next
                        // dialogue updater should move on to next
                        ActiveDecision.Next = correspondingDialogue;
                        // remove buttons
                        RemoveButtons();
                    };

                    button.onClick.AddListener(selectDialogue);

                    ActiveButtons.Add(buttonObj);
                }
            }  
        }

        public void RemoveButtons()
        {
            while (ActiveButtons.Count > 0)
            {
                Destroy(ActiveButtons[0]);
                ActiveButtons.RemoveAt(0);
            }
            WaitingOnPlayer = false;
        }
    }
}