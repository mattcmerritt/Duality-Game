using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Components
    [SerializeField]
    private Collider2D col;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("OutsidePast");
        }
    }

    public void AllowExit()
    {
        col.enabled = true;
    }
}
