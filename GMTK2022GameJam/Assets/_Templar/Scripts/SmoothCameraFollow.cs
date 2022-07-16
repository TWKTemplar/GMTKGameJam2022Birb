using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public Vector3 targetPositionMod;

    public MusicBox musicBox;
    public Camera camera;
    private void Start()
    {
        if (camera == null) camera = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        Move();
    }
    public void FOV()
    {
        float FOV = 90;

        if(musicBox.VolumeMultiplier < 1)
        {
            FOV = musicBox.VolumeMultiplier * 0.5f + 0.5f;
        }

        camera.fieldOfView = FOV;
    }

    public void Move()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(targetPositionMod);

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }


}
