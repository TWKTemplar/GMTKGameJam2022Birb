
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource audioSource;
    public bool IsBossFight = false;
    public float Volume = 1;
    public float VolumeMultiplier = 0;
    public float FallOffSpeed = 0.2f;
    public float VolumeMultiplierSetToOnKick = 2;

    public Transform TargetCube;

    public void Start()
    {
        if(audioSource == null) audioSource = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if (TargetCube != null) transform.position = TargetCube.position;



       if(VolumeMultiplier > 0)
       {
           VolumeMultiplier = VolumeMultiplier - Time.deltaTime * FallOffSpeed;
       }
        if (IsBossFight) VolumeMultiplier = 1;
        audioSource.volume = Mathf.Clamp(Volume * VolumeMultiplier,0, Volume);
    }
    public void DiceWasKicked()
    {
        VolumeMultiplier = VolumeMultiplierSetToOnKick;
    }
}
