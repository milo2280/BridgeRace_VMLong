using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTranform, player;
    public Vector3 offset, offset2;

    private void LateUpdate()
    {
        if (!LevelManager.Ins.isEndGame)
        {
            cameraTranform.position = player.position + offset;
        }
        else
        {
            cameraTranform.position = Vector3.Lerp(cameraTranform.position, player.position + offset2, Time.deltaTime);
        }
    }
}
