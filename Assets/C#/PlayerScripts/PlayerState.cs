using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : IState
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    

    public PlayerState(Rigidbody2D _rigidbody2D, Animator _animator)
    {
        rigidbody2D = _rigidbody2D;
        animator = _animator;
    }
    
    private enum MovementState {PlayerRun, JumpUp, JumpDown, DoubleJump, Death }
    public void CheckAnimationState( Player player, IHealth health)
    {
        MovementState state = 0;
        
        if (rigidbody2D.velocity.y > .1f)
        {
            state = MovementState.JumpUp;
        }
        else if (rigidbody2D.velocity.y < -.1f)
        {
            state = MovementState.JumpDown;
        }

        if (!player.IsGrounded() && player.CanDoubleJump == false && rigidbody2D.velocity.y > .1f)
        {
            state = MovementState.DoubleJump;
        }
        else if (!player.IsGrounded() && player.CanDoubleJump == false && rigidbody2D.velocity.y < -.1f)
        {
            state = MovementState.JumpDown;
        }

        if (health.IsPlayerAlive == false )
        {
            state = MovementState.Death;
        }
        
        animator.SetInteger("state",(int)state);
    }
}