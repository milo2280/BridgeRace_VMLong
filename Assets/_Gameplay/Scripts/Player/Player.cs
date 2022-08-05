using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float speed;

    private Vector3 rootPos, dragPos, mouseDir, moveDir;
    private Quaternion lookRotation;

    public Transform trans;
    public Animator anim;

    private void Update()
    {
        JoystickMove();
        Fall();
    }

    private void JoystickMove()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                rootPos = Input.mousePosition;
            }

            dragPos = Input.mousePosition;
            mouseDir = (dragPos - rootPos).normalized;

            moveDir.x = mouseDir.x;
            moveDir.z = mouseDir.y;

            if ((moveDir - Vector3.zero).sqrMagnitude > 0.01f)
            {
                lookRotation = Quaternion.LookRotation(moveDir);
                anim.SetTrigger(Constant.ANIM_RUN);
            }

            trans.position = Vector3.Lerp(trans.position, trans.position + moveDir, speed * Time.deltaTime);
            trans.rotation = Quaternion.Slerp(trans.rotation, lookRotation, speed * Time.deltaTime);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            moveDir = Vector3.zero;
            anim.ResetTrigger(Constant.ANIM_RUN);
            anim.SetTrigger(Constant.ANIM_IDLE);
        }
    }

    private void Fall()
    {
        //anim.SetBool(Constant.FALL, true);

        //anim.SetBool(Constant.FALL, false);
    }
}
