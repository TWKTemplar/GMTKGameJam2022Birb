using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Target;
    public float speed;
    void FixedUpdate()
    {
        Vector3 tempos = Target.transform.position;
        tempos.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, tempos, speed); 
    }
}
