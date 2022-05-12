using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public Animator Animator;
    public float Duration;

    public GameObject[] Blocks;

    public void LoadRoom(string name)
    {
        foreach (GameObject block in Blocks)
        {
            block.SetActive(true);
        }
        StartCoroutine(LoadScene(name));
    }

    IEnumerator LoadScene(string name)
    {
        Animator.SetTrigger("Leaving");

        yield return new WaitForSeconds(Duration);

        SceneManager.LoadScene(name);
    }
}
