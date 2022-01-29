using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLine
{
    public string Text;
    public Sprite Portrait;
    public string Name;

    public DialogueLine(string text, Sprite portrait, string name)
    {
        Text = text;
        Portrait = portrait;
        Name = name;
    }
}
