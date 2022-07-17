using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : MonoBehaviour
{
    public bool PlayerWithinRange;
    public GameObject RemoteGlow;
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RemoteGlow.SetActive(true);
            PlayerWithinRange = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RemoteGlow.SetActive(false);
            PlayerWithinRange = false;
        }
    }

    public void ChangeTexturesRequest()
    {
        if (PlayerWithinRange)
        {
            audioSource.Play();

            foreach (var item in FindObjectsOfType<DiceArt>())
            {
                item.AssignNewTexture();
            }
        }
       
    }

}
