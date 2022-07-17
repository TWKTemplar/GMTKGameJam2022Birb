using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnyDiceEffects : MonoBehaviour
{
    public Dice dice;
    public GameObject[] Effects;

    public Enemy[] enemies;
    public WorldObject[] worldObjects;
    public float Distance;
    public void Start()
    {
        GatherThings();
    }
    public void GatherThings()
    {
        enemies = FindObjectsOfType<Enemy>();
        worldObjects = FindObjectsOfType<WorldObject>();
    }

    [ContextMenu("Do 1")] public void Do1() { Roll(1);}
    [ContextMenu("Do 2")] public void Do2() { Roll(2);}
    [ContextMenu("Do 3")] public void Do3() { Roll(3);}
    [ContextMenu("Do 4")] public void Do4() { Roll(4);}
    [ContextMenu("Do 5")] public void Do5() { Roll(5);}
    [ContextMenu("Do 6")] public void Do6() { Roll(6);}



    public void Roll(int outcome)
    {
        GatherThings();

        GameObject effect = Instantiate(Effects[outcome-1]);
        effect.transform.position = transform.position;
        Destroy(effect, 3);
        
        switch (outcome)
        {
            case 1:
                Debug.Log("Exsplosion");
                foreach (var ene in enemies)
                {
                    float dist = Vector3.Distance(transform.position, ene.transform.position);
                    if (dist < Distance) ene.EffectPushAway(transform.position);
                }
                foreach (var obj in worldObjects)
                {
                    float dist = Vector3.Distance(transform.position, obj.transform.position);
                    if (dist < Distance) obj.EffectPushAway(transform.position);
                }
                break;
            case 2:
                Debug.Log("Gravity Well");
                foreach (var ene in enemies)
                {
                    float dist = Vector3.Distance(transform.position, ene.transform.position);
                    if (dist < Distance) ene.EffectPullClose(transform.position);
                }
                foreach (var obj in worldObjects)
                {
                    float dist = Vector3.Distance(transform.position, obj.transform.position);
                    if (dist < Distance) obj.EffectPullClose(transform.position);
                }
                break;
            case 3:
                Debug.Log("Stun");
                foreach (var ene in enemies)
                {
                    float dist = Vector3.Distance(transform.position, ene.transform.position);
                    if (dist < Distance) ene.EffectStun();
                }
                foreach (var obj in worldObjects)
                {
                    float dist = Vector3.Distance(transform.position, obj.transform.position);
                    if (dist < Distance) obj.EffectStun();
                }
                break;
            case 4:
                Debug.Log("Run Away");
                foreach (var ene in enemies)
                {
                    float dist = Vector3.Distance(transform.position, ene.transform.position);
                    if (dist < Distance) ene.EffectRunAway(transform.position);
                }
                foreach (var obj in worldObjects)
                {
                    float dist = Vector3.Distance(transform.position, obj.transform.position);
                    if (dist < Distance) obj.EffectRunAway(transform.position);
                }
                break;
            case 5:
                Debug.Log("Zero Gravity");
                foreach (var ene in enemies)
                {
                    float dist = Vector3.Distance(transform.position, ene.transform.position);
                    if (dist < Distance) ene.ZeroGravity();
                }
                foreach (var obj in worldObjects)
                {
                    float dist = Vector3.Distance(transform.position, obj.transform.position);
                    if (dist < Distance) obj.ZeroGravity();
                }
                break;
            case 6:
                Debug.Log("Made Confedent");
                foreach (var ene in enemies)
                {
                    float dist = Vector3.Distance(transform.position, ene.transform.position);
                    if (dist < Distance) ene.EffectMakeConfident();
                }
                foreach (var obj in worldObjects)
                {
                    float dist = Vector3.Distance(transform.position, obj.transform.position);
                    if (dist < Distance) obj.EffectMakeConfident();
                }
                break;
        }
    }
    private void OnDrawGizmos()
    {

        if(dice.THERECANBEONLYONE == false)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, Distance);
        }
    }
}
