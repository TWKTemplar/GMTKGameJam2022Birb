using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

enum EnemyState
{
    FollowPlayer,
    FollowTarget,
    ZeroGravity
}

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Player1 player;

    public Vector3 followTarget;

    private EnemyState enemyState;

    void Start()
    {
        enemyState = EnemyState.FollowPlayer;

        agent.updateRotation = false;

        followTarget = new Vector3(0, -2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.FollowPlayer:
                agent.destination = player.transform.position;
                break;
            case EnemyState.FollowTarget:
                agent.destination = followTarget;
                break;
        }
    }
}
