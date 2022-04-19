# Dialogue System:
We are using a bunch of different classes to contain our dialogue system.
Essentially, it boils down to a linked structure, with branches occurring at each decision point.

**As of right now, we are not able to support dialogue with more than one decision, due to recurisive serialization of the Builder classes**

*Should we be using individual scriptable objects for the lines instead, and then make a system to link them together?*

## Lines of Dialogue
These classes are the nodes of the dialogue tree, used polymorphically as `DialogueElement`s.
- `DialogueElement`
    - Text : `string`
    - Character : `Character`
    - Next : `DialogueElement`
- `Line`
    - Child of `DialogueElement`
- `Decision`
    - Child of `DialogueElement`
    - Options : `String[]`
    - Branches : `DialogueElement[]`

## Construction
These classes are Serializable classes that are supposed to be used in the UnityEditor to make the individual conversation elements.
- `ConversationBuilder`
    - Used for creating linear sequences of `Line`s, ending in a potential `Decision`
        - Lines : `List<Line>`
        - HasDecision : `bool`
        - DecisionBuilder : `Decision`
- `DecisionBuilder`
    - Use to make the decisions that appear at the end of a conversation and lead into other conversations
        - Question : `string`
        - Speaker : `Character`
        - Options : `string[]`
        - BranchingConversations : `EndingConversationBuilder[]`
            - *Note, this should be `ConversationBuilder[]` instead*
- `EndingConversationBuilder`
    - Temporary, used for creating a linear sequence of `Lines` that does not end in a `Decision`
        - Lines : `List<Line>`

## NPC
The NPC is the MonoBehaviour that can be put in the scene and contains the dialogue to run when they are interacted with. This dialogue is written in the inspector using a custom editor, as defined in `Editor/NPCEditor.cs`.

When interacted with, they send `CurrentConversation` to the `DialogueUpdater`, which handles the traversal of the tree and displaying to the UI.

- `NPC`
    - Builder : `ConversationBuilder`
    - CurrentConversation : `DialogueElement`

