using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class WorldObject : MonoBehaviour
{

    private Player1 player;
    private Rigidbody rb;
    private Vector3 OffsetForce = new Vector3(0,200,0);
    private Vector3 SpinForce = new Vector3(0,20,0);

    private Vector3 followTarget = new Vector3(0,0,0);
    public float MoveSpeed = 25;
    private bool MoveToFollow = false;
    private int MoveMultiplier = 1;
    public void Start()
    {
        if (player == null) player = FindObjectOfType<Player1>();
        if (rb == null) rb = gameObject.GetComponent<Rigidbody>();
        rb.drag = .25f;
    }
    #region Effects Tools
    public void ResetState()
    {
        MoveMultiplier = 1;
        MoveToFollow = false;
    }
    public void TurnGravityOn()
    {
        rb.useGravity = true;
    }
    #endregion
    public void FixedUpdate()
    {
        if (MoveToFollow)
        {
            rb.AddForce(MoveSpeed * MoveMultiplier * (followTarget - transform.position).normalized);

        }
    }

    #region Effects
    public void EffectMakeConfident()
    {
        this.gameObject.transform.localScale = this.gameObject.transform.localScale * 1.2f;
    }
    public void EffectPullClose(Vector3 pos)
    {
        followTarget = pos;
        MoveToFollow = true;

        Invoke("ResetState", 5);
    }

    public void EffectStun()
    {
        rb.AddForce(OffsetForce * 2);
        rb.AddTorque(SpinForce * 300);
    }
    public void ZeroGravity()
    {
        rb.useGravity = false;
        rb.AddForce(OffsetForce * 0.4f);
        float ran = Random.Range(1, 10);
        rb.AddTorque(SpinForce * ran);
        Invoke("TurnGravityOn", 3);
    }
    public void EffectRunAway(Vector3 pos)
    {
        followTarget = pos;
        MoveToFollow = true;
        MoveMultiplier = -1;
        Invoke("ResetState", 5);
    }
    public void EffectPushAway(Vector3 pos)
    {

        Vector3 AdjustedPlayerPos = pos;
        AdjustedPlayerPos.y = transform.position.y;

        Vector3 Dir = Vector3.Normalize(transform.position - pos);
        rb.AddForce(Dir * 100 + OffsetForce * 2);

        float ran = Random.Range(1, 10);
        rb.AddTorque(SpinForce * ran);

        Invoke("ResetState", 5);
    }
    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
       if(followTarget != Vector3.zero) Gizmos.DrawLine(transform.position, followTarget);
    }
}
