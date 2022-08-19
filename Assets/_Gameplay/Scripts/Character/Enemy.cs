using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState { collect, attack, build }

public class Enemy : Character
{
    public EnemyState currentState;
    public List<Spawner> mySpawner;

    private Vector3 nextPos;
    private int Rand;
    private SpawnerHolder spawnerHolder;
    private Transform[] listGate;

    private void Start()
    {
        mySpawner = new List<Spawner>();
        nextPos = myTransform.position;
        navMeshAgent.speed = LevelManager.Ins.currentEnemySpeed;
    }

    private void Update()
    {
        if (!LevelManager.Ins.isEndGame)
        {
            if (!isFalling)
            {
                StateMachine();
            }
            else
            {
                navMeshAgent.ResetPath();
            }
        }
        else
        {
            EndGame();
        }
    }

    private void StateMachine()
    {
        isReachDes = !navMeshAgent.pathPending 
            && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance 
            && (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f);
        switch (currentState)
        {
            case EnemyState.collect:
                Collect();
                break;

            case EnemyState.attack:
                break;

            case EnemyState.build:
                Build();
                break;

            default:
                break;
        }
    }

    private void SwitchState(EnemyState nextState)
    {
        currentState = nextState;
    }

    private void Collect()
    {
        animator.SetTrigger(Constant.ANIM_RUN);
        if (GetBrickCount() >= 10) SwitchState(EnemyState.build);

        if (isReachDes)
        {
            RandomNextPos();
            navMeshAgent.destination = nextPos;
        }
    }

    private void RandomNextPos()
    {
        if (mySpawner.Count > 0)
        {
            Rand = Random.Range(0, mySpawner.Count);
            nextPos = mySpawner[Rand].myTransform.position;
        }
    }

    private void Build()
    {
        if (GetBrickCount() == 0)
        {
            navMeshAgent.ResetPath();
            SwitchState(EnemyState.collect);
        }
        else
        {
            if (isReachDes) navMeshAgent.destination = listGate[Random.Range(0, listGate.Length)].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_SPAWNERHOLDER))
        {
            spawnerHolder = CacheSpawnerHolder.Get(other);
            mySpawner = spawnerHolder.GetListSpawner(color);
            listGate = spawnerHolder.GetListGate();
        }
    }
}
