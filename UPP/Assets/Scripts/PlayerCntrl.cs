using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 5f;
    public float moveInput;
    public float playerspeed;
    private bool isgrounded = false;
    private bool playerIsFacingRight = true;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool faceRight = true;

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (playerIsFacingRight == false && moveInput > 0)
        {
            FlipPlayer();
            playerIsFacingRight = true;
        }
        else if (playerIsFacingRight == true && moveInput < 0)
        {
            FlipPlayer();
            playerIsFacingRight = false;
        }
    }
    private void Update()
    {
        CheckGround();
        if (Input.GetButton("Horizontal"))
            Run();
        else if (isgrounded)
            State = States.idle;
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        if (isgrounded) State = States.run;
        moveInput = Input.GetAxis("Horizontal");
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * playerspeed, rb.velocity.y);
    }
    
    private void Jump()
    {
        if (isgrounded)
        {
            anim.SetInteger("state", 3);
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        }
        private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 2f);
        isgrounded = collider.Length > 1;
        if (!isgrounded) State = States.jump;
    }
    private void FlipPlayer()
    {
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}

public enum States
{
    idle,
    run,
    jump
}
