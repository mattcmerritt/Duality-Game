using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour, ITogglable
{
    [SerializeField] private string Scene;
    [SerializeField] private bool IsDoor;
    [SerializeField] private string RoomName;

    [SerializeField] private Collider2D Collider;

    public bool IsEnabled;

    public void ActivateTransition()
    {
        if (IsEnabled)
        {
            FindObjectOfType<TransitionManager>().LoadRoom(Scene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsEnabled)
        {
            if (IsDoor)
            {
                RoomManager.ChangeRoom(collision.gameObject, RoomName);
            }
            ActivateTransition();
        }
    }

    public void Enable()
    {
        IsEnabled = true;

        Collider.enabled = true;
    }

    public void Disable()
    {
        IsEnabled = false;

        Collider.enabled = false;
    }
}
