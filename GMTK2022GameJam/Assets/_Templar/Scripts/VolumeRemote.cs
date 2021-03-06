using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeRemote : MonoBehaviour
{
    public AudioListener audioListener;
    [Range(0,8)]public int VolumeNum = 8;
    public Player1 Player;
    public GameObject PositivePos;
    public GameObject NegativePos;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public AudioSource audioSource;


    void Start()
    {
        if (audioListener != null) audioListener = FindObjectOfType<AudioListener>();
        if (Player == null) Player = FindObjectOfType<Player1>();
        Visualizer();
        AudioListener.volume = VolumeNum;
    }
    public void Visualizer()
    {
        float num = VolumeNum;
        for (int i = -1; i < 8; i++)
        {
            if (i != -1)
            skinnedMeshRenderer.SetBlendShapeWeight(i,Mathf.Clamp(-num,0,1) * 100);
            num--;
        }
    }
    private bool IsPlayerCloserToPositive()
    {
      float distPos = Vector3.Distance(Player.gameObject.transform.position, PositivePos.transform.position);
      float distNeg = Vector3.Distance(Player.gameObject.transform.position, NegativePos.transform.position);

      if(distPos < distNeg) return true;
      else return false;

    }
    public void ChangeVolume()
    {
        if (IsPlayerCloserToPositive())
        {
            VolumeNum++;
        }
        else
        {
            VolumeNum--;
        }
        audioSource.Play();
        Visualizer();
        AudioListener.volume = VolumeNum;
    }
}
