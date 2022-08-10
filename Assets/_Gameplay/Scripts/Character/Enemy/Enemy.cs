using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { collect, attack, build }

public class Enemy : Character
{
    public EnemyState currentState;

    private List<Spawner> listSpawner;
    private Vector3 nextPos;
    private int Rand, numOfBricks;
    private Vector3 moveDir;
    private Quaternion lookRotation;
    private Spawner spawner;
    private Step step;

    private void Start()
    {
        listSpawner = new List<Spawner>();
        nextPos = trans.position;
    }

    private void Update()
    {
        StateMachine();
    }

    private void StateMachine()
    {
        switch (currentState)
        {
            case EnemyState.collect:
                CollectBricks();
                break;

            case EnemyState.attack:
                break;

            case EnemyState.build:
                break;

            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_SPAWNERHOLDER))
        {
            listSpawner = Cache.GetSpawnerHolder(other).GetListSpawner(myColor);
        }

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

    private void CollectBricks()
    {
        anim.SetTrigger(Constant.ANIM_RUN);
        if ((trans.position - nextPos).sqrMagnitude < 0.01f)
        {
            Rand = Random.Range(0, listSpawner.Count);
            nextPos = listSpawner[Rand].trans.position;
        }

        moveDir = (nextPos - trans.position).normalized;
        lookRotation = Quaternion.LookRotation(moveDir);

        trans.position = Vector3.Lerp(trans.position, trans.position + moveDir, speed * Time.deltaTime);
        trans.rotation = Quaternion.Slerp(trans.rotation, lookRotation, speed * Time.deltaTime);
    }
}
