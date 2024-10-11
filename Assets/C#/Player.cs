using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private bool doubleJump;
    
    [SerializeField] private GameObject ChangeSpeedFor;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallSpeed;
    [SerializeField] private LayerMask jumpableGround;

    public static bool playerAlive;

    private enum MovementState {PlayerRun, JumpUp, JumpDown, doublejump }
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        doubleJump = false;
        playerAlive = true;
        
    }
    
    void Update()
    {

        ObservationForPlayer();
        Jump();
        UpdateAnimState();
        Down();
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        playerAlive = false;

    }

    private void Down()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            rb.velocity = new Vector2(rb.velocity.x , -fallSpeed);
        }
    }

    private void UpdateAnimState()

    {
        MovementState state = 0;
        
        if (rb.velocity.y > .1f)
        {

            state = MovementState.JumpUp;

        }
        else if (rb.velocity.y < -.1f)
        {

            state = MovementState.JumpDown;

        }

        if (!IsGrounded() && doubleJump == false && rb.velocity.y > .1f)
        {
            state = MovementState.doublejump;
        }
        else if (!IsGrounded() && doubleJump == false && rb.velocity.y < -.1f)
        {
            state = MovementState.JumpDown;
        }

            anim.SetInteger("state",(int)state);

    }

    private void Jump()
    {
        if (IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = true;

            }

        }
        else if (doubleJump && Input.GetButtonDown("Jump"))
        {

            rb.velocity = (new Vector2(rb.velocity.x, jumpForce));
            doubleJump = false;
            Debug.Log("double jump");
        }
    }

    private void ObservationForPlayer()
    {
        if (playerAlive == false)
        {
            Time.timeScale = 0f;
        }
        
       
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void JumpButton()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = true;
        }
        else if (doubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = false;
        }
    }
    public void DownButton()
    {
        rb.velocity = new Vector2(rb.velocity.x, -fallSpeed);
    }
}
