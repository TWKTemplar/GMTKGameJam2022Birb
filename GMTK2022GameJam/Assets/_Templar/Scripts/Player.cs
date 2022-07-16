using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CharacterController controller;
    public Vector3 playerVelocity;    
    public float playerSpeed = 2.0f;
    public PlayerKick PlayerKick;

    private void Start()
    {
        if(controller == null) controller = gameObject.GetComponent<CharacterController>();
        if(PlayerKick == null) PlayerKick = gameObject.GetComponent<PlayerKick>();
    }

    void Update()
    {
        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("KICK");
            PlayerKick.RequestKick();
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
