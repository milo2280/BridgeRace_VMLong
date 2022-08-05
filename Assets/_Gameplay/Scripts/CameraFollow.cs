using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTranform, player;
    public Vector3 offset;

    private void LateUpdate()
    {
        cameraTranform.position = player.position + offset;
    }
}
