using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public ColorEnum color;
    public Animator animator;
    public Transform myTransform;
    public BrickHolder brickHolder;
    public CapsuleCollider myCollider;

    protected bool isFalling;
    protected Quaternion lookRotation;

    public void Fall()
    {
        isFalling = true;
        animator.ResetTrigger(Constant.ANIM_RUN);
        animator.SetTrigger(Constant.ANIM_FALL);
        brickHolder.DropBrick();
        myCollider.enabled = false;
        Invoke("KipUp", 6f);
    }

    public void KipUp()
    {
        isFalling = false;
        myCollider.enabled = true;
    }

    public void AddBrick()
    {
        brickHolder.AddBrick(color);
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
