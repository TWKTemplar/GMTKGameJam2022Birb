using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick1 : MonoBehaviour
{

    public float KickRange = 2;
    public Dice[] AllDice;
    public GameObject FeathersEffect;
    public GameObject FeathersParent;

    public void FindAllDice() // TODO note: needs to be reworked with sprite object
    {
        AllDice = FindObjectsOfType<Dice>();
    }
    public void Update()
    {
        
        OutLineManagement();
    }
    public void OutLineManagement()
    {
        foreach (var item in AllDice)
        {
            if (item == null)
            {
                FindAllDice();
                break;
            }

            float dist = Vector3.Distance(transform.position, item.transform.position);
            Debug.DrawLine(transform.position, item.transform.position);
            if (dist < KickRange )
            {
                item.SetOutlineVisable(true);
            }
            else
            {
                item.SetOutlineVisable(false);
            }
        }
    }
    public void Start()
    {
        FindAllDice();
    }
    public void RequestKick()
    {
        foreach (var item in AllDice)
        {
            float dist = Vector3.Distance(transform.position, item.transform.position);
            //Debug.Log("dist: " + dist + ", kickRange: " + KickRange);
            if (dist < KickRange)
            {
                item.Kick(transform.position);
                GameObject effect = Instantiate(FeathersEffect);
                effect.transform.position = FeathersParent.transform.position;
                effect.transform.SetParent(FeathersParent.transform);
                Destroy(effect, 5);
            }

        }
    }    
}
