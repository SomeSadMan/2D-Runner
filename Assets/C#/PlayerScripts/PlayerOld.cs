using System;
using System.Collections;
using UnityEngine;


public class PlayerOld : MonoBehaviour
{
    [SerializeField] private CharacterHealth characterHealth;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    public static bool PlayerAlive;
    private bool canDoubleJump;
    private bool jump;
    private bool doubleJump;
    private bool down;

    private IMovement _movement;
    
    [SerializeField] private float fallSpeed;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpForce;
    [SerializeField] private ObstaclesPool pool;
    internal bool IsSpeedIncreased;

    public float JumpForce
    {
        get => jumpForce;
        set
        {
            jumpForce = value;
            if (IsSpeedIncreased)
            {
                StartCoroutine(ResetAfterDelay(5));
                
            }
        }
        
    }
    
    private enum MovementState {PlayerRun, JumpUp, JumpDown, DoubleJump }

    private void Awake()
    { 
        
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        PlayerAlive = true;
        canDoubleJump = false;
    }
    
    void Update()
    {
        CheckMovementsInputs();
        ObservationForPlayer();
        UpdateAnimState();
    }

    private void FixedUpdate()
    {
        Jump();
        DoubleJump();
        Down();
    }

    private void CheckMovementsInputs()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            jump = true;
            
            
        }

        if (Input.GetButtonDown("Vertical"))
        {
            down = true;
        }

        if (!IsGrounded() && canDoubleJump && Input.GetButtonDown("Jump"))
        {
            doubleJump = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            characterHealth.HpValue -= characterHealth.takenDamage;
            characterHealth.HideHeartFromBar();
            //TODO:сделать анимацию получения урона (мигание спрайта или визуальный эффект) 
            Debug.Log($"hp deducted, your current hp is {characterHealth.HpValue}");
            pool.ReturnObstacle(collision.gameObject);
            
            
        }
    }

    internal void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        PlayerAlive = false;
    }

    private void Down()
    {
        if (down)
        { 
            rb.velocity = new Vector2(rb.velocity.x , -fallSpeed);
            down = false;
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

        if (!IsGrounded() && canDoubleJump == false && rb.velocity.y > .1f)
        {
            state = MovementState.DoubleJump;
        }
        else if (!IsGrounded() && canDoubleJump == false && rb.velocity.y < -.1f)
        {
            state = MovementState.JumpDown;
        }
        
        anim.SetInteger("state",(int)state);
    }

    private void Jump()
    {
        if (jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            jump = false;
            canDoubleJump = true;
        }
    }

    void DoubleJump()
    {
        if (doubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            doubleJump = false;
            canDoubleJump = false;
        }
    }

    private void ObservationForPlayer()
    {
        if (PlayerAlive == false)
        {
            Time.timeScale = 0f;
        }
    }
    
    private IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        IsSpeedIncreased = false;
        JumpForce = 7;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void JumpButton()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            doubleJump = true;
        }
        else if (doubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            doubleJump = false;
        }
    }
    public void DownButton()
    {
        rb.velocity = new Vector2(rb.velocity.x, -fallSpeed);
    }
    
    
}
