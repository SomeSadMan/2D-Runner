using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IMovement _imovement;
    private IState state;

    public Rigidbody2D Rb { get; private set; }
    public Animator Anim { get; private set; }
    private BoxCollider2D coll;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float fallVelocity;
    [SerializeField] private LayerMask jumpableGround;

    private bool jump;
    private bool doubleJump;
    private bool down;
    public bool CanDoubleJump { get; private set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        _imovement = new PlayerMovement(Rb, jumpVelocity, fallVelocity);
        state = new PlayerState(Rb,Anim);
    }

    private void FixedUpdate()
    {
        FlagsChecker();
    }
    
    private void Update()
    {
        PlayerInputsObserver();
        state.CheckAnimationState(this);
        
    }

    private void PlayerInputsObserver()
    {
        if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
            jump = true;
        }
        
        if (Input.GetButtonDown("Jump") && CanDoubleJump && !IsGrounded())
        {
            doubleJump = true;
        }
        
        if (Input.GetButtonDown("Vertical"))
        {
            down = true;
        }
    }
    
    private void FlagsChecker()
    {
        if (jump)
        {
            _imovement.Jump();
            jump = false;
            CanDoubleJump = true;
        }
        
        if (doubleJump)
        {
            _imovement.DoubleJump();
            doubleJump = false;
            CanDoubleJump = false;
        }
        
        if (down)
        {
            _imovement.Down();
            down = false;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
