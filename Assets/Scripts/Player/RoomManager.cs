using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static string LastRoomName;
    public static Vector3 LastPlayerLocation;
    public static bool HasLocation;
    public static bool WasRoomTransition;

    public static void ChangeRoom(GameObject player, string roomName)
    {
        // saving values for next time
        LastPlayerLocation = player.transform.position;
        HasLocation = true;

        LastRoomName = roomName;

        WasRoomTransition = true;
    }

}
