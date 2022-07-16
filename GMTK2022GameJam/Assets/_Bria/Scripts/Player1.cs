using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public CharacterController controller;
    //public Material playerMaterial;
    public Vector3 playerVelocity;    
    public float playerSpeed = 2.0f;
    public PlayerKick1 PlayerKick;

    private Texture texRight;
    private Texture texLeft;

    private void Start()
    {
        if(controller == null) controller = gameObject.GetComponent<CharacterController>();
        if(PlayerKick == null) PlayerKick = gameObject.GetComponent<PlayerKick1>();

        //texRight = (Texture) Resources.Load("Assets/_Bria/BriaSprites/gamejamebirb-export.png");
        //texLeft = (Texture)Resources.Load("Assets/_Bria/BriaSprites/flip_gamejamebirb-export.png");
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move.x > 0)
        {
            //playerMaterial.SetTexture("_MainTex", texRight);
        }
        else
        {
            //playerMaterial.SetTexture("_MainTex", texLeft);
        }

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
