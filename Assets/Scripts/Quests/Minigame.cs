using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    // Components
    [SerializeField]
    private Collider2D col;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // and some flag is active for the cat game to trigger
        {

            collision.GetComponent<PlayerMovement>().Freeze();

            int catsCaught = 0;
            float timeUntilNextCatAction = 300;
            bool catActive = false;
            LeafPile[] piles = GameObject.FindObjectsOfType<LeafPile>();

            while (catsCaught < 3)
            {
                timeUntilNextCatAction -= Time.deltaTime;

                // enable cat
                if(timeUntilNextCatAction <= 0 && !catActive)
                {
                    catActive = true;
                    int chosenPile = Random.Range(0, piles.Length);
                    piles[chosenPile].HasCat = true;
                    timeUntilNextCatAction = 60;
                }

                // disable cat
                else if (timeUntilNextCatAction <= 0 && catActive)
                {
                    catActive = false;
                    foreach (LeafPile pile in piles)
                    {
                        pile.HasCat = false;
                    }
                }

                else if (catActive)
                {
                    foreach(LeafPile pile in piles)
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

            collision.GetComponent<PlayerMovement>().Unfreeze();
        }
    }
}
