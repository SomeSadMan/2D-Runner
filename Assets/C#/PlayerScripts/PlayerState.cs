using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : IState
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public MovementState CurrentState { get; private set; }
    public MovementState GetCurrentState() => CurrentState;
    

    public PlayerState(Rigidbody2D _rigidbody2D, Animator _animator)
    {
        rigidbody2D = _rigidbody2D;
        animator = _animator;
    }
    
    public enum MovementState {PlayerRun, JumpUp, JumpDown, DoubleJump, Death }
    public void CheckAnimationState( Player player, IHealth health)
    {
        MovementState state = MovementState.PlayerRun;
        
        if (rigidbody2D.velocity.y > .1f)
        {
            state = MovementState.JumpUp;
            Debug.Log("прыг");
        }
        else if (rigidbody2D.velocity.y < -.1f)
        {
            state = MovementState.JumpDown;
            Debug.Log("вниз");
        }

        if (!player.IsGrounded() && player.CanDoubleJump == false && rigidbody2D.velocity.y > .1f)
        {
            state = MovementState.DoubleJump;
            Debug.Log("прыг2");
        }
        else if (!player.IsGrounded() && player.CanDoubleJump == false && rigidbody2D.velocity.y < -.1f)
        {
            state = MovementState.JumpDown;
            Debug.Log("вниз2");
        }

        if (health.IsPlayerAlive == false )
        {
            state = MovementState.Death;
            Debug.Log("смэрт");
        }

        CurrentState = state;
        animator.SetInteger("state",(int)state);
    }
}