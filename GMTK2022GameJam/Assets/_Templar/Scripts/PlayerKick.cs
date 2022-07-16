using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{

    public float KickRange = 2;
    public Dice[] AllDice;
    public void Update()
    {
        AllDice = FindObjectsOfType<Dice>();
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
        AllDice = FindObjectsOfType<Dice>();
        foreach (var item in AllDice)
        {
            float dist = Vector3.Distance(transform.position, item.transform.position);
            if (item.rb.velocity.magnitude < 0.1f && dist < KickRange)
            {
                item.Kick(transform.position);
            }
        }
    }    
}
