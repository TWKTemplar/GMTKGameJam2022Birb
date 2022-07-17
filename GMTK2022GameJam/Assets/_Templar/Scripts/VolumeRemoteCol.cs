using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeRemoteCol : MonoBehaviour
{
    public bool PlayerWithinRange;
    public GameObject RemoteGlow;
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

    public void ChangeVolumeRequest()
    {
        if (PlayerWithinRange)
        {
            foreach (var item in FindObjectsOfType<VolumeRemote>())
            {
                item.ChangeVolume();
            }
        }

    }
}
