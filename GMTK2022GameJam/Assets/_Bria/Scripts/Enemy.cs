using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

enum EnemyState
{
    FollowPlayer,
    FollowTarget,
    Idle,
    ZeroGravity
}

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Player1 player;

    public Vector3 followTarget;

    
    public bool IsConfedent = false;
    public GameObject IsConfedentVisual;
    public float playerNoticeDistance = 6;

    [SerializeField]private EnemyState enemyState;
    public Rigidbody rb;
    [SerializeField] private float Power;
    public Vector3 OffsetForce;
    public Vector3 SpinForce;

    void Start()
    {
        agent.updateRotation = false;

        followTarget = new Vector3(0, -2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if(dist < playerNoticeDistance && enemyState == EnemyState.Idle && agent.enabled == true)
        {
            Debug.Log("Player has been seen by enemy " + gameObject.name);
            enemyState = EnemyState.FollowPlayer;
        }


        switch (enemyState)
        {
            case EnemyState.FollowPlayer:
                if(agent.enabled == true) agent.destination = player.transform.position;
                break;
            case EnemyState.FollowTarget:
                if (agent.enabled == true) agent.destination = followTarget;
                break;
            case EnemyState.Idle:
                
                break;
        }
    }
    #region Effects Tools
    public void ResetState()
    {
        enemyState = EnemyState.FollowPlayer;
    }
    public void TurnGravityOn()
    {
        rb.useGravity = true;
    }
    public void TurnAgentBackOn()
    {
        rb.useGravity = true;
        agent.enabled = true;
    }
    public void SetConfedence(bool SetConfedent)
    {
        IsConfedent = SetConfedent;
        IsConfedentVisual.SetActive(IsConfedent);
    }
    #endregion


    #region Effects
    public void EffectMakeConfident()
    {
        SetConfedence(true);
        agent.speed = agent.speed * 2;
        this.gameObject.transform.localScale = this.gameObject.transform.localScale * 1.2f;
    }
    public void EffectPullClose(Vector3 pos)
    {
        followTarget = pos;
        enemyState = EnemyState.FollowTarget;
        Invoke("ResetState", 4);
    }
    
    public void EffectStun()
    {
        
        agent.enabled = false;
        rb.AddTorque(SpinForce * 50);
        Invoke("TurnAgentBackOn", 2);
    }
    public void ZeroGravity()
    {
        agent.enabled = false;
        rb.useGravity = false;
        rb.AddForce(Power * OffsetForce * 0.4f);

        float ran = Random.Range(1, 10);
        rb.AddTorque(SpinForce * ran);
        
        Invoke("TurnGravityOn", 3);
        Invoke("TurnAgentBackOn", 6);
    }
    public void EffectRunAway(Vector3 pos)
    {

        Vector3 newpos = pos - transform.position;
        followTarget = newpos;
        enemyState = EnemyState.FollowTarget;
        Invoke("ResetState", 5);
    }
    public void EffectPushAway(Vector3 pos)
    {
        agent.enabled = false;  

        Vector3 AdjustedPlayerPos = pos;
        AdjustedPlayerPos.y = transform.position.y;

        Vector3 Dir = Vector3.Normalize(transform.position - pos);
        rb.AddForce(Dir * Power * 10 + OffsetForce * 2);

        float ran = Random.Range(1, 10);
        rb.AddTorque(SpinForce * ran);

        Invoke("TurnAgentBackOn", 5);
    }
    #endregion
    private void OnDrawGizmos()
    {
        if(enemyState != EnemyState.Idle) Gizmos.color = Color.red;
        else Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,playerNoticeDistance);
    }
}
