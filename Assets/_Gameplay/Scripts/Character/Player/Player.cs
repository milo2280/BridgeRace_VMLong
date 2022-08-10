using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Vector3 rootPos, dragPos, mouseDir, moveDir;
    private Quaternion lookRotation;

    private Spawner spawner;
    private Step step;
    private int numOfBricks;

    public LayerMask layerStep;
    public Transform rayTrans;
    private Ray ray = new Ray();
    private RaycastHit hit;

    private void Start()
    {
        numOfBricks = 0;
    }

    private void Update()
    {
        JoystickMove();
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

            CheckWalkable();

            trans.position = Vector3.Lerp(trans.position, trans.position + moveDir, speed * Time.deltaTime);
            trans.rotation = Quaternion.Slerp(trans.rotation, lookRotation, speed * Time.deltaTime);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            anim.ResetTrigger(Constant.ANIM_RUN);
            anim.SetTrigger(Constant.ANIM_IDLE);
        }
    }

    private void Fall()
    {
        //anim.SetBool(Constant.FALL, true);
        //anim.SetBool(Constant.FALL, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_SPAWNER))
        {
            spawner = Cache.GetSpawner(other);
            if (myColor == spawner.color)
            {
                brickHolder.AddBrick();
                spawner.TurnOff();
                numOfBricks++;
            }
        }

        if (other.CompareTag(Constant.TAG_STEP))
        {
            step = Cache.GetStep(other);
            if (numOfBricks > 0 && step.color != myColor)
            {
                brickHolder.UseBrick();
                step.SetColor(myColor);
                numOfBricks--;
            }
        }
    }

    private void CheckWalkable()
    {
        rayTrans.rotation = moveDir.z > 0 ? Quaternion.Euler(60f, 0f, 0f) : Quaternion.Euler(110f, 0f, 0f);

        ray = new Ray(rayTrans.position, rayTrans.forward);
        if (Physics.Raycast(ray, out hit, 100, layerStep))
        {
            step = Cache.GetStep(hit.collider);
            if (numOfBricks == 0 && step.color != myColor) moveDir.z = 0;
        }
    }
}
