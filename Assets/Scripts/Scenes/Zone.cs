using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    // order should be home, top of town, middle of town, bottom of town, mayor side
    public int ZoneIndex;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // change the active zone to this one
            ZoneManager.SetActiveZone(ZoneIndex);
        }
    }
}
