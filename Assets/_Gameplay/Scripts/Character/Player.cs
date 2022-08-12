using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float speed;
    public Joystick joystick;
    public LayerMask layerStep;
    public Transform rayTransform;

    private Vector3 mouseDir, moveDir;
    private Ray ray = new Ray();
    private RaycastHit hit;
    private Step step;

    private void Update()
    {
        if (!LevelManager.Ins.isEndGame)
        {
            JoystickMove();
        }
        else
        {
            EndGame();
        }
    }

    private void JoystickMove()
    {
        if (isFalling) return;

        mouseDir = joystick.mouseDir;

        if ((mouseDir - Vector3.zero).sqrMagnitude > 0.01f)
        {
            animator.SetTrigger(Constant.ANIM_RUN);
            CalculateMoveDir();
            CheckMovable();
            Move();
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.ResetTrigger(Constant.ANIM_RUN);
            animator.SetTrigger(Constant.ANIM_IDLE);
        }
    }

    private void CalculateMoveDir()
    {
        moveDir.x = mouseDir.x;
        moveDir.z = mouseDir.y;
        lookRotation = Quaternion.LookRotation(moveDir);
    }

    private void Move()
    {
        myTransform.position = Vector3.Lerp(myTransform.position, myTransform.position + moveDir, speed * Time.deltaTime);
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, lookRotation, speed * Time.deltaTime);
    }

    public void CheckMovable()
    {
        rayTransform.rotation = moveDir.z > 0 ? Quaternion.Euler(60f, 0f, 0f) : Quaternion.Euler(110f, 0f, 0f);

        ray = new Ray(rayTransform.position, rayTransform.forward);
        if (Physics.Raycast(ray, out hit, 100, layerStep))
        {
            step = CacheStep.Get(hit.collider);
            if (GetBrickCount() == 0 && step.color != color)
            {
                if (moveDir.z > 0) moveDir.z = 0;
                else if (moveDir.z < 0 && step.color == ColorEnum.none) moveDir.z = 0;
            }
        }
    }
}
