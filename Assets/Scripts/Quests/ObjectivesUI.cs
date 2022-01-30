using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ObjectivesBox;

    public void ChangeText(string newText)
    {
        string content = "Objectives:\n";
        ObjectivesBox.SetText(content + newText);
    }
}
