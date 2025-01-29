using UnityEngine;

public interface ICharacter
{
    public Rigidbody2D Rb { get; }
    public Animator Anim { get; }
    public float JumpVelocity { get; }
    public float FallVelocity { get; }
    
}