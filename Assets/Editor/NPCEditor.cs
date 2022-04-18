using UnityEngine;
using UnityEditor;

// Code adapted from https://www.youtube.com/watch?v=RInUu1_8aGw

[CustomEditor(typeof(Dialogue.NPC))]
public class NPCEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Dialogue.NPC npc = (Dialogue.NPC) target;

        if (npc.Builder.HasDecision)
        {
            //EditorGUILayout.ObjectField(Temp);
        }
    }
}
