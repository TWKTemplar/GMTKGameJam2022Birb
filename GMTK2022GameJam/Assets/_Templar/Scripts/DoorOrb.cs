using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOrb : MonoBehaviour
{
    public bool DieInsideOrb = false;
    public float DoorTimer = 0;
    public float DoorMax = 5;//5 seconds to fill
    public GameObject Door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Die"))
        {
            DieInsideOrb = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Die"))
        {
            DieInsideOrb = false;
        }
    }
    public void Update()
    {
        if (DieInsideOrb) DoorTimer += Time.deltaTime;

        if (DoorTimer > DoorMax)
        {
            Door.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
