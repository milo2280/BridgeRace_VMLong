using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    public Transform joystickTransform;
    public Transform stickTransform;

    private float dragOffset, sqrDragOffset;
    private Vector3 rootPos, dragPos, dragDir;
    public Vector3 mouseDir { get; private set; }

    private void Start()
    {
        dragOffset = 150f;
        sqrDragOffset = dragOffset * dragOffset;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && GameManager.Ins.IsState(GameState.Gameplay))
        {
            if (Input.GetMouseButtonDown(0))
            {
                rootPos = Input.mousePosition;
            }

            joystickTransform.gameObject.SetActive(true);
            joystickTransform.position = rootPos;

            dragPos = Input.mousePosition;
            dragDir = dragPos - rootPos;
            mouseDir = dragDir.normalized;

            if (dragDir.sqrMagnitude > sqrDragOffset)
            {
                dragPos = rootPos + mouseDir * dragOffset;
            }

            stickTransform.position = dragPos;
        }

        if (Input.GetMouseButtonUp(0) || LevelManager.Ins.isEndGame)
        {
            mouseDir = Vector3.zero;
            joystickTransform.gameObject.SetActive(false);
        }
    }
}
