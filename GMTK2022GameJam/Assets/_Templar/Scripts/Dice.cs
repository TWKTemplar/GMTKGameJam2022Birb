using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public bool THERECANBEONLYONE = true;
    public bool IncreaseVolumeOnMusicBox = true;
    public Rigidbody rb;
    [SerializeField]private float Power;
    public Vector3 OffsetForce;
    public Vector3 SpinForce;
    public bool LOADED;
    public Transform[] NumbersArray;
    public DiceArt diceArt;
    public GameObject Outline;
    public FunnyDiceEffects funnyDiceEffects;
    public void SetOutlineVisable(bool setActive)
    {
        Outline.SetActive(setActive);
    }
    public void Update()
    {
        if(rb.velocity.magnitude < 0.1f)
        {
            diceArt.SetColorKickable();
            if (LOADED == true)
            {
                LOADED = false;
                Roll();
            }
        }
        else
        {
            diceArt.SetColorNOTKickable();
            
        }
    }
    public void THERECANBEONLYONERemoveOthers()
    {
        THERECANBEONLYONE = false;
        foreach (var item in FindObjectsOfType<Dice>())
        {
            if (item == this) continue;
            Destroy(item.gameObject);
        }
    }
    public void Roll()
    {
        Transform highestPoint = null;
        foreach (var point in NumbersArray)
        {
            if(highestPoint == null )
            { 
                highestPoint = point;
                continue;
            }
            if (point.position.y > highestPoint.position.y)
            {
                highestPoint = point;
            }

        }
        int RollResult = int.Parse(highestPoint.name);
        Debug.Log("Roll Result: " + RollResult);
        funnyDiceEffects.Roll(RollResult);
    }
    public void LoadRoll()
    {
        LOADED = true;
    }
    public void Kick(Vector3 OriginPos)
    {
        if(THERECANBEONLYONE) THERECANBEONLYONERemoveOthers();
        if (IncreaseVolumeOnMusicBox) FindObjectOfType<MusicBox>().DiceWasKicked();
        Invoke("LoadRoll", 0.5f);
        Vector3 AdjustedPlayerPos = OriginPos;
        AdjustedPlayerPos.y = transform.position.y;

        Vector3 Dir = Vector3.Normalize(transform.position - OriginPos);
        rb.AddForce(Dir * Power + OffsetForce);

        float ran = Random.Range(1, 10);
        rb.AddTorque(SpinForce * ran);


    }
}
