using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public static string CurrentTime;
    public static bool HasLocation;
    public static Vector3 PlayerPosition;
    public static bool WasTimeTransition;

    public static void ChangeTime(GameObject player)
    {
        PlayerPosition = player.transform.position;
        HasLocation = true;
        if (CurrentTime == "Past")
        {
            CurrentTime = "Future";
            SceneManager.LoadScene("OutsideFuture");
        }
        else
        {
            CurrentTime = "Past";
            SceneManager.LoadScene("OutsidePast");
        }
        WasTimeTransition = true;
    }

    public static Vector3 GetLastLocation()
    {
        return PlayerPosition;
    }

    public static bool HasLastLocation()
    {
        return HasLocation;
    }
}
