using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeRemote : MonoBehaviour
{
    public AudioListener audioListener;
    public float VolumePercent;

    public GameObject PositivePos;
    public GameObject NegativePos;


    void Start()
    {
        if (audioListener != null) audioListener = FindObjectOfType<AudioListener>();
    }
    public void Visualizer()
    {

    }
    void Update()
    {
        Visualizer();


    }
    public void ChangeVolume()
    {

    }
}
