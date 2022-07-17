using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnyDiceEffects : MonoBehaviour
{
    public GameObject[] Effects;

    public Player1 player;
    public Enemy[] enemies;
    public void Start()
    {
        GatherThings();
    }
    public void GatherThings()
    {
        if (player == null) FindObjectOfType<Player>();
        enemies = FindObjectsOfType<Enemy>();
    }
    public void Roll(int outcome)
    {
        GameObject effect = Instantiate(Effects[outcome-1]);
        effect.transform.position = transform.position;
        Destroy(effect, 5);
        switch (outcome)
        {
            case 1:
                Debug.Log("Exsplosion");
                foreach (var ene in enemies)
                {
                    ene.EffectPushAway(transform.position);
                }
                break;
            case 2:
                Debug.Log("Gravity Well");
                foreach (var ene in enemies)
                {
                    ene.EffectPullClose(transform.position);
                }
                break;
            case 3:
                Debug.Log("Stun");
                foreach (var ene in enemies)
                {
                    ene.EffectStun();
                }
                break;
            case 4:
                Debug.Log("Run Away");
                foreach (var ene in enemies)
                {
                    ene.EffectRunAway(transform.position);
                }
                break;
            case 5:
                Debug.Log("Zero Gravity");
                foreach (var ene in enemies)
                {
                    ene.ZeroGravity();
                }
                break;
            case 6:
                Debug.Log("Made Confedent");
                foreach (var ene in enemies)
                {
                    ene.EffectMakeConfident();
                }
                break;
        }
    }
}
