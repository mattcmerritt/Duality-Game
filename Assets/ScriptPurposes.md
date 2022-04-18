# Scripts
This file outlines the purposes of each script, as well as how they are being used.
Use this to determine what scripts need to be edited to accomplish a given task.

## Game State
Various scripts that are controlling the flow of the game. This will need to be entirely redone.
- `Scripts/Quests/GameManager.cs`

## UI
Various UI scripts.
- `Scripts/Menu/Menu.cs` - This script just handles the start button.
- `Scripts/Quests/ObjectivesUI.cs` - Contians the textbox in the top-left and a method to change the text.

## New Dialogue Systems
These scripts handle the new dialogue systems. They are all contianed in the `Dialogue` namespace, to prevent any duplicate name issues.
- `Scripts/Dialogue/Character.cs` - Base class for anything that can talk, comes with a name and portrait.
- `Scripts/Dialogue/Conversation.cs` - Unused, intended to contain a collection of `DialogueElement`s.
- `Scripts/Dialogue/ConversationBuilder.cs` - A serializable object that can be used to load in individual messages in a sequence, with the potential for a decision at the end that leads to multiple other `ConversationBuilder`s.
- `Scripts/Dialogue/Decision.cs` - A `DialogueElement` that forces the user to select an option to continue dialogue.
- `Scripts/Dialogue/DecisionBuilder.cs` - A serializable object that can be used to load in a decision for a `ConversationBuilder`.
- `Scripts/Dialogue/DialogueElement.cs` - An abstract parent class that helps to generalize items that can be said.
- `Scripts/Dialogue/DialogueUpdater.cs` - Makes the player run through the linked structure that is currently loaded in as the `DialogueElement`.
- `Scripts/Dialogue/Line.cs` - An instantiable version of `DialogueElement`.
- `Scripts/Dialogue/NPC.cs` - Contains a conversation as well as some `Character` data for when they get interacted with.

## Old Dialogue Systems
These scripts are all involved in displaying text and running through a conversation.
- `Demos/Scripts/DialogueLine.cs` - Represents a singular line of dialogue, with message and speaker details.
- `Demos/Scripts/DialogueTest.cs` - Nothing, can be removed.
- `Demos/Scripts/DialogueUpdater.cs` - Loads in a list of `DialogueLine` objects, and makes the player run through those until the list is fully exhausted.
- `Demos/Scripts/NPC.cs` - Contains the full conversation with a given object, and creates a list of `DialogueLine`s with that data that will be activate when the player interacts with them.

Note: We will likely need to modify `NPC` significantly in the process of designing a new dialogue system.

## Player Systems
Scripts involved with making the player move around the scene.
Hopefully these will not need too many changes.
- `Demos/Scripts/CameraController.cs`
- `Demos/Scripts/PlayerMovement.cs`
- `Demos/Scripts/PlayerInteractions.cs` - Contains some info for displaying the player info in dialogue as static data, but primarily handles activating `NPC` elements in front of the player.

## Individual Quests
These scripts are the individual quests currently in the game. These should be changed to be scriptable objects.
They currently depend on the `ObjectivesUI` to display the current items to complete, and use an `NPC` or multiple to determine if the quest has been completed.
- `Scripts/Quests/CatQuestFuture.cs`
- `Scripts/Quests/CatQuestPast.cs`
- `Scripts/Quests/PapersQuest.cs`
- `Scripts/Quests/UnpackingQuest.cs`

Note: These are all parented from the `Quest` class at `Scripts/Quests/Quest.cs`. This class is basically an abstract class with two booleans for if the quest is active or completed.

## Door Scripts
These scripts are all scripts for triggers to activate a load trigger.
These can probably be generalize into one script with a scene to load.
- `Scripts/Quests/EnterTownHall.cs`
- `Scripts/Quests/Exit.cs`
- `Scripts/Quests/ExitTownHall.cs`

## Cat Quest
These scripts contain the behavior and dialogue for the the cat minigame with the leaves. 
These will likely be removed or rewritten entirely.
- `Scripts/Quests/Minigame.cs`
- `Scripts/Quests/LeafPile.cs`

## Box Quest
These scripts contain the behavior for the individual boxes in the beginning.
This can likely be turned into an `NPC`, and we can just give the `NPC` script additional data about whether it is a person or an item to see if particle effects are necessary.
We can also add a collectible field to the `NPC` for any item the player might have gained from the interaction.
- `Scripts/Quests/BoxScripts.cs`
