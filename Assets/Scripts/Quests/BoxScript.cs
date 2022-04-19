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
        Checked = true;
        Particles.SetActive(false);
        npc.enabled = false;
        col.enabled = false;
    }

    public bool BoxChecked()
    {
        return Checked;
    }

    public void toggleParticles(bool enabled)
    {
        Particles.SetActive(enabled);
    }
}
