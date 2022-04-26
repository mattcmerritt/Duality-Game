using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Instance Data
    [SerializeField]
    private Vector4 CameraBounds; // x is left, y is right, z is bottom, w is top
    [SerializeField]
    private bool LockedCamera;
    private Vector3 PreviousPosition;
    [SerializeField]
    private GameObject Player;

    // Constants
    private float Speed = 1f;

    private void LateUpdate()
    {
        // Camera should follow the player
        if (!LockedCamera)
        {
            Vector3 playerPosition = Player.transform.position;
            Vector3 newPosition = Vector3.Lerp(PreviousPosition, playerPosition, Speed);
            transform.position = new Vector3(
                Mathf.Clamp(newPosition.x, CameraBounds.x, CameraBounds.y),
                Mathf.Clamp(newPosition.y, CameraBounds.z, CameraBounds.w),
                -10);
            PreviousPosition = transform.position;
        }
        // Room is too small, camera will stay locked in place
        else
        {
            transform.position = new Vector3(0f, 0f, -10f);
        }
    }

}
