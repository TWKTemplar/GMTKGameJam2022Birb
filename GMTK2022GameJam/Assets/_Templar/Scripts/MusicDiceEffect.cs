using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs; 
public class MusicDiceEffect : MonoBehaviour
{
    public GameObject ParticleSystem;
    public MusicBox musicBox;
    // Start is called before the first frame update
    void Start()
    {
        if (musicBox == null) musicBox = FindObjectOfType<MusicBox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (musicBox.VolumeMultiplier > 0.1f) ParticleSystem.SetActive(true);
        else ParticleSystem.SetActive(false);
    }
}
