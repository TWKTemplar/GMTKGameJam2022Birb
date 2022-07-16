using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick1 : MonoBehaviour
{

    public float KickRange = 2;
    public List<Dice> AllDice;

    public void CollectAllCloseDice()
    {
        AllDice.Clear();

        RaycastHit[] hitArray = Physics.SphereCastAll(transform.position,KickRange,transform.forward,8);
        if (hitArray.Length != 0)
        {
            foreach (var hit in hitArray)
            {
                if (hit.collider.gameObject.CompareTag("Die"))
                {
                    AllDice.Add(hit.collider.gameObject.GetComponent<Dice>());
                }
            }
        }
    }
    public void Update()
    {
        CollectAllCloseDice();
        OutLineManagement();
    }
    public void OutLineManagement()
    {
        foreach (var item in AllDice)
        {
            float dist = Vector3.Distance(transform.position, item.transform.position);
            if (dist < KickRange && item.rb.velocity.magnitude < 0.1f)
            {
                item.SetOutlineVisable(true);
            }
            else
            {
                item.SetOutlineVisable(false);
            }
        }
    }
    public void RequestKick()
    {
        foreach (var item in AllDice)
        {
            float dist = Vector3.Distance(transform.position, item.transform.position);
            if (dist < KickRange)
            {
                // kick the ball
                if (item.rb.velocity.magnitude < 0.1f)
                {
                    item.Power = 50;
                }
                else
                {
                    item.Power = 100;
                }
                item.Kick(transform.position);
            }
        }
    }    
}
