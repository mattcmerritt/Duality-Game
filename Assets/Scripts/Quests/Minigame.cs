using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    // Components
    [SerializeField]
    private Collider2D col;
    public int catsCaught = 0;
    public float timeUntilNextCatAction = 5;
    public bool catActive = false;
    public bool minigameActive = false;
    public Sprite Cat, BushCat, Martin;

    // Objectives Display
    private ObjectivesUI QuestUI;

    private void Awake()
    {
        QuestUI = FindObjectOfType<ObjectivesUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // and some flag is active for the cat game to trigger
        {
            List<DialogueLine> BeginGameLines = new List<DialogueLine>();
            BeginGameLines.Add(new DialogueLine("Cookie, is that you??", PlayerInteractions.Portrait, PlayerInteractions.Name));
            BeginGameLines.Add(new DialogueLine("*Meow*", BushCat, "Cookie"));
            BeginGameLines.Add(new DialogueLine("It looks like she wants to play?", PlayerInteractions.Portrait, PlayerInteractions.Name));
            BeginGameLines.Add(new DialogueLine("Cookie, this is no time for games!", PlayerInteractions.Portrait, PlayerInteractions.Name));

            FindObjectOfType<DialogueUpdater>().StartDialogue(BeginGameLines);

            collision.GetComponent<PlayerMovement>().Freeze();
            collision.GetComponent<PlayerMovement>().GetComponent<Animator>().Play("PlayerIdleDown");
            minigameActive = true;
        }
    }

    private void Update()
    {
        if(minigameActive)
        {
            FindObjectOfType<PlayerMovement>().Freeze();
            FindObjectOfType<PlayerMovement>().GetComponent<Animator>().Play("PlayerIdleDown");

            LeafPile[] piles = GameObject.FindObjectsOfType<LeafPile>();

            if (catsCaught < 3)
            {
                timeUntilNextCatAction -= Time.deltaTime;

                // enable cat
                if (timeUntilNextCatAction <= 0 && !catActive)
                {
                    catActive = true;
                    int chosenPile = Random.Range(0, piles.Length);
                    piles[chosenPile].HasCat = true;
                    timeUntilNextCatAction = 2;
                }

                // disable cat
                else if (timeUntilNextCatAction <= 0 && catActive)
                {
                    catActive = false;
                    foreach (LeafPile pile in piles)
                    {
                        pile.HasCat = false;
                    }
                    timeUntilNextCatAction = 5;
                }

                else if (catActive)
                {
                    foreach (LeafPile pile in piles)
                    {
                        if (Input.GetKeyDown(pile.PileKey))
                        {
                            if (pile.HasCat)
                            {
                                catsCaught++;
                            }

                            // skip to next phase after a valid press, regardless of result
                            timeUntilNextCatAction = 0;
                        }
                    }
                }
            }
            else
            {
                foreach (LeafPile pile in piles)
                {
                    pile.HasCat = false;
                }
                FindObjectOfType<PlayerMovement>().Unfreeze();
                minigameActive = false;
                
                // trigger dialogue for finding cat
                List<DialogueLine> EndGameLines = new List<DialogueLine>();
                EndGameLines.Add(new DialogueLine("Caught you! Come on, let’s go, Martin is worried about you.", PlayerInteractions.Portrait, PlayerInteractions.Name));
                EndGameLines.Add(new DialogueLine("*Meow*", Cat, "Cookie"));

                FindObjectOfType<DialogueUpdater>().StartDialogue(EndGameLines);

                QuestUI.ChangeText("- Go return Cookie to Martin");

                // find Martin and change his dialogue
                List<DialogueLine> MartinCookieLines = new List<DialogueLine>();
                MartinCookieLines.Add(new DialogueLine("Cookie!! You found her. Thank you so much.", Martin, "Martin"));
                MartinCookieLines.Add(new DialogueLine("Happy to help, Martin.", PlayerInteractions.Portrait, PlayerInteractions.Name));
                MartinCookieLines.Add(new DialogueLine("Here, have this cat paw medallion I got from the shelter. I know it’s not valuable, but as a token of my appreciation. We’re both very thankful.", Martin, "Martin"));
                MartinCookieLines.Add(new DialogueLine("*Meow*", Cat, "Cookie"));

                FindObjectOfType<Demo.NPC>().ReplaceConversation(MartinCookieLines);
            }
        }
    }
}
