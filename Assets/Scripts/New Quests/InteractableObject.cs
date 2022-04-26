using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, ITogglable
{
    public bool IsEnabled;
    public bool Checked;
    public bool SingleUse;

    [SerializeField] private GameObject Particles;
    [SerializeField] private Collider2D Collider;
    [SerializeField] private Dialogue.NPC NPC;

    public void InteractWith()
    {
        if (IsEnabled)
        {
            Checked = true;
            if (SingleUse)
            {
                Disable();
            }
        }
    }

    public bool CheckForInteraction()
    {
        return Checked;
    }

    public void Enable()
    {
        IsEnabled = true;

        Particles.SetActive(true);
        Collider.enabled = true;
        NPC.enabled = true;
    }

    public void Disable()
    {
        IsEnabled = false;

        Particles.SetActive(false);
        Collider.enabled = false;
        NPC.enabled = false;
    }
}
