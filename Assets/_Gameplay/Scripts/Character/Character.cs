using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public ColorEnum color;
    public Animator animator;
    public Transform myTransform;
    public BrickHolder brickHolder;
    public CapsuleCollider myCollider;
    public Transform winPos;
    public NavMeshAgent navMeshAgent;

    protected bool isFalling;
    protected bool isReachDes;
    protected bool isWin;
    protected bool oneTime;
    protected Quaternion lookRotation;

    protected void EndGame()
    {
        if (isWin == true)
        {
            OnWin();
        }
        else
        {
            OnLose();
        }
    }

    public void Win()
    {
        isWin = true;
        navMeshAgent.destination = winPos.position;
    }

    protected void OnWin()
    {
        isReachDes = !navMeshAgent.pathPending
            && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance
            && (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f);

        if (isReachDes && !oneTime)
        {
            animator.ResetTrigger(Constant.ANIM_RUN);
            animator.SetTrigger(Constant.ANIM_WIN);
            brickHolder.ClearBrick();
            oneTime = true;
        }
    }

    protected void OnLose()
    {
        if (!oneTime)
        {
            animator.ResetTrigger(Constant.ANIM_RUN);
            animator.SetTrigger(Constant.ANIM_LOSE);
            brickHolder.ClearBrick();
            oneTime = true;
        }
    }

    public void Fall()
    {
        isFalling = true;
        animator.ResetTrigger(Constant.ANIM_RUN);
        animator.SetTrigger(Constant.ANIM_FALL);
        brickHolder.DropBrick();
        myCollider.enabled = false;
        Invoke(nameof(KipUp), 6f);
    }

    public void KipUp()
    {
        isFalling = false;
        myCollider.enabled = true;
    }

    public void AddBrick()
    {
        brickHolder.AddBrick();
    }

    public void UseBrick()
    {
        brickHolder.UseBrick();
    }

    public int GetBrickCount()
    {
        return brickHolder.brickCount;
    }
}
