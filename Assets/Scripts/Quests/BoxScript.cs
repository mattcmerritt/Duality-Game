using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    // Object data
    private bool Checked;

    // Components
    [SerializeField]
    private GameObject Particles;
    [SerializeField]
    private Dialogue.NPC npc;
    [SerializeField]
    private Collider2D col;

    public void Check()
    {
        Debug.Log("Box checked");
        Checked = true;
        Particles.SetActive(false);
        npc.enabled = false;
        col.enabled = false;
    }

    public bool BoxChecked()
    {
        Debug.Log("Checking " + gameObject.name);
        return Checked;
    }

    public void toggleParticles(bool enabled)
    {
        Particles.SetActive(enabled);
    }
}
