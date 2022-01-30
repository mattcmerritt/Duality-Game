using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Components
    [SerializeField]
    private Collider2D col;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Leaving the scene");
        }
    }

    public void AllowExit()
    {
        col.enabled = true;
    }
}
