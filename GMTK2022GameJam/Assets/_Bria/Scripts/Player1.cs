using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState
{
    Idle,
    Walking,
    Flying,
    Attack
}

public class Player1 : MonoBehaviour
{
    [SerializeField] Animator animator;

    public CharacterController controller;
    //public Material playerMaterial;
    public Vector3 playerVelocity;    
    public float playerSpeed = 2.0f;
    public PlayerKick1 PlayerKick;

    private Texture texRight;
    private Texture texLeft;

    private PlayerState playerState;

    private void Start()
    {
        if(controller == null) controller = gameObject.GetComponent<CharacterController>();
        if(PlayerKick == null) PlayerKick = gameObject.GetComponent<PlayerKick1>();

        playerState = PlayerState.Idle;
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        switch (playerState)
        {
            case PlayerState.Idle:
                if (move.x != 0 || move.y != 0) playerState = PlayerState.Walking;
                break;
            case PlayerState.Walking:
                if (move.x == 0 && move.y == 0) playerState = PlayerState.Idle;
                if (move.x > 0) animator.Play("BirbRight");
                if (move.x <= 0) animator.Play("BirbLeft");
                break;
            case PlayerState.Attack:
                if (move.x > 0) animator.Play("BirbRightAttack");
                if (move.x <= 0) animator.Play("BirbLeftAttack");
                break;
            case PlayerState.Flying:
                if (move.x > 0) animator.Play("BirbFlyRight");
                if (move.x <= 0) animator.Play("BirbFlyLeft");
                break;
            default:
                break;
        }

        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && playerState != PlayerState.Attack)
        {
            Debug.Log("KICK");
            playerState = PlayerState.Attack;
            PlayerKick.RequestKick();
            StartCoroutine(WaitAttack(1));
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    IEnumerator WaitAttack(float time)
    {
        yield return new WaitForSeconds(time);
        playerState = PlayerState.Walking;
    }
}
