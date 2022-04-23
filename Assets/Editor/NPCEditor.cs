using UnityEngine;
using UnityEditor;

// Code adapted from https://www.youtube.com/watch?v=RInUu1_8aGw

[CustomEditor(typeof(Dialogue.NPC))]
public class NPCEditor : Editor
{
    SerializedProperty InitialLines;
    SerializedProperty InitialHasDecision;
    SerializedProperty DecisionQuestion;
    SerializedProperty DecisionSpeaker;
    SerializedProperty DecisionOptions;
    SerializedProperty DecisionBranches;

    void OnEnable()
    {
        InitialLines = serializedObject.FindProperty("Builder.Lines");
        InitialHasDecision = serializedObject.FindProperty("Builder.HasDecision");

        DecisionQuestion = serializedObject.FindProperty("Builder.Decision.Question");
        DecisionSpeaker = serializedObject.FindProperty("Builder.Decision.Speaker");
        DecisionOptions = serializedObject.FindProperty("Builder.Decision.Options");
        DecisionBranches = serializedObject.FindProperty("Builder.Decision.BranchingConversations");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        /*
        //base.OnInspectorGUI();

        Dialogue.NPC npc = (Dialogue.NPC) target;

        //EditorGUILayout.PropertyField(Builder);
        EditorGUILayout.PropertyField(InitialLines);
        EditorGUILayout.PropertyField(InitialHasDecision);

        if (npc.Builder.HasDecision)
        {
            // Debug.Log("Decision box checked");

            EditorGUILayout.PropertyField(DecisionQuestion);
            EditorGUILayout.PropertyField(DecisionSpeaker);
            EditorGUILayout.PropertyField(DecisionOptions);

            // npc.Builder.Decision.BranchingConversations = new Dialogue.ConversationBuilder[npc.Builder.Decision.Options.Length];

            // for (int i = 0; i < npc.Builder.Decision.Options.Length; i++) {
            //     GUILayout.Label("Branch for: " + npc.Builder.Decision.Options[i]);
            //     // npc.Builder.Decision.BranchingConversations[i] = new Dialogue.ConversationBuilder();
            //     SerializedProperty branch = serializedObject.FindProperty($"Builder.Decision.BranchingConversations[{i}].Lines");
            //     // EditorGUILayout.PropertyField(branch);
            //
            //     // some sort of code to cascade decisions down, for now we only allow one decision per conversation
            // }

            // temporary
            GUILayout.Label("MAKE SURE THAT OPTIONS AND BRANCHING CONVERSATIONS ARE OF THE SAME LENGTH");
            EditorGUILayout.PropertyField(DecisionBranches);
        }

        // pushing changes made in UI to the object
        serializedObject.ApplyModifiedProperties();
        */
    }
}
