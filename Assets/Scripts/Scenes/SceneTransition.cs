using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour, ITogglable
{
    [SerializeField] private string Scene;
    [SerializeField] private bool IsDoor;

    [SerializeField] private Collider2D Collider;

    public bool IsEnabled;

    public void ActivateTransition()
    {
        if (IsEnabled)
        {
            SceneManager.LoadScene(Scene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsEnabled)
        {
            if (IsDoor)
            {
                ActivateTransition();
            }
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
