using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    private Vector3 rootPos, dragPos;
    public Image joystick;
    public Image stick;

    private float dragOffset = 150f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                rootPos = Input.mousePosition;
            }

            joystick.gameObject.SetActive(true);
            joystick.transform.position = rootPos;

            dragPos = Input.mousePosition;

            if ((rootPos - dragPos).sqrMagnitude > dragOffset * dragOffset)
            {
                dragPos = rootPos + (dragPos - rootPos).normalized * dragOffset;
            }

            stick.transform.position = dragPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            joystick.gameObject.SetActive(false);
        }
    }
}
