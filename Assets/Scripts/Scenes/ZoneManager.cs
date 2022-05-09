using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneManager : MonoBehaviour
{
    // currently selected zone
    public static int ActiveZone = 0;
    // list of the spawn locations associated with each zone
    // order should be home, top of town, middle of town, bottom of town, mayor side
    public GameObject[] Spawns;

    // if the scene is outside, move the player to the last place they were at when loaded
    public void MovePlayerToStart()
    {
        if (SceneManager.GetActiveScene().name.ToLower().Contains("outside"))
        {
            // find player and move to active zone
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = Spawns[ActiveZone].transform.position;
        }
    }

    public static void SetActiveZone(int zone)
    {
        ActiveZone = zone;
    }
}
