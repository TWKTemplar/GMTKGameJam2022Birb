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
enum PlayerDir
{
    Left,
    Right
}

public class Player1 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    [SerializeField] Animator animator;

    public CharacterController controller;
    //public Material playerMaterial;
    public float playerSpeed = 2.0f;
    public PlayerKick1 PlayerKick;

    private Texture texRight;
    private Texture texLeft;

    [SerializeField]private PlayerState playerState;
    private PlayerDir playerDir;
    private bool flagKick = false;

    private void Start()
    {
        if (controller == null) controller = gameObject.GetComponent<CharacterController>();
        if (PlayerKick == null) PlayerKick = gameObject.GetComponent<PlayerKick1>();
        if (audioSource == null) audioSource = gameObject.GetComponent<AudioSource>();

        playerState = PlayerState.Idle;
    }
    public void PlayRandomAudio()
    {
        int random = Random.Range(0, audioClips.Length - 1);
        Debug.Log("Audio clip : " + random);
        audioSource.clip = audioClips[random];
        audioSource.Play();
    }

    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (move.x <= -0.1f) playerDir = PlayerDir.Left;
        if (move.x > 0.1f) playerDir = PlayerDir.Right;

        if (!flagKick && transform.position.y > 2) playerState = PlayerState.Flying;
        else if (!flagKick && playerState == PlayerState.Flying) playerState = PlayerState.Idle;

        switch (playerState)
        {
            case PlayerState.Idle:
                if (move.magnitude > 0.1f) playerState = PlayerState.Walking;
                if (playerDir == PlayerDir.Right) animator.Play("BirbRight");
                if (playerDir == PlayerDir.Left) animator.Play("BirbLeft");
                break;
            case PlayerState.Walking:
                if (move.magnitude < 0.1f) playerState = PlayerState.Idle;
                if (playerDir == PlayerDir.Right) animator.Play("BirbRightWalking");
                if (playerDir == PlayerDir.Left) animator.Play("BirbLeftWalking");
                break;
            case PlayerState.Attack:
                if (playerDir == PlayerDir.Right) animator.Play("BirbRightAttack");
                if (playerDir == PlayerDir.Left) animator.Play("BirbLeftAttack");
                break;
            case PlayerState.Flying:
                if (!flagKick && playerDir == PlayerDir.Right) animator.Play("BirbFlyRight");
                if (!flagKick && playerDir == PlayerDir.Left) animator.Play("BirbFlyLeft");
                controller.Move(Vector3.down * Time.deltaTime);
                break;
            default:
                break;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && playerState != PlayerState.Attack)
        {
            Kick();
        }

        if(playerState == PlayerState.Attack)
        {
            controller.Move(move * Time.deltaTime * playerSpeed * 2);
        }
        else
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
    }
    public void Kick()
    {
        flagKick = true;
        playerState = PlayerState.Attack;
        PlayerKick.RequestKick();
        FindObjectOfType<Remote>().ChangeTexturesRequest();
        Invoke("ReturnToIdle", 0.3f);
    }
    public void ReturnToIdle()
    {
        flagKick = false;
        playerState = PlayerState.Walking;
    }
}
