
using UnityEngine;

public class MusicCollider : MonoBehaviour
{
    public AudioClip MyMusicClip;
    public AudioSource MusicBoxAudioSource; 

    private void Start()
    {
        if(MusicBoxAudioSource == null) MusicBoxAudioSource = transform.parent.GetComponent<MusicBox>().audioSource;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (MusicBoxAudioSource.clip != MyMusicClip)
            {
                MusicBoxAudioSource.clip = MyMusicClip;   
                MusicBoxAudioSource.Play();
            }
        }
    }  
}
