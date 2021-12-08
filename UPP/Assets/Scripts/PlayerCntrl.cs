using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 5f;
    public float moveInput;
    public float playerspeed;
    public bool isgrounded = false;
    private bool playerIsFacingRight = true;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool faceRight = true;
    public Joystick joystick;
    private int ObjectCount;

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
        float verticalMove = joystick.Vertical;
        if (joystick.Horizontal !=0) 
            Run();
        else if (isgrounded)
            State = States.idle;
        if (verticalMove >= 0.5f)
            Jump();
    }

    private void Run()
    {
        if (isgrounded) State = States.run;
        /*
        moveInput = Input.GetAxis("Horizontal");
        */
        moveInput = joystick.Horizontal;
        /*
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        */
        rb.velocity = new Vector2(moveInput * playerspeed, rb.velocity.y);
    }
    
    private void Jump()
    {
        if (isgrounded)//if(Physics2D.OverlapCircle((transform.position - new Vector3(0,1,0)), 0.3f, 2))
        {
            anim.SetInteger("state", 3);
            /*rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse); */
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll((transform.position - new Vector3(0, 0.7f,0)),0.2f);
        ObjectCount = collider.Length;
        for (int i = 0; i < collider.Length; i++)
        {
            if (collider[i].gameObject.tag == "Rose")
            {
                ObjectCount--;
            }
        }
        isgrounded = ObjectCount > 1;
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
