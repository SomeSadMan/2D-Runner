using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : IMovement
{
    private Rigidbody2D rigidbody2D;
    private float jumpVelocity;
    private float fallSpeed;

    

    public PlayerMovement(Rigidbody2D _rigidbody2D , float _jumpVelocity, float _fallSpeed)
    {
        rigidbody2D = _rigidbody2D;
        jumpVelocity = _jumpVelocity;
        fallSpeed = _fallSpeed;


    }
    
    public void Jump()
    { 
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpVelocity);
    }

    public void DoubleJump()
    { 
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpVelocity);
    }
    public void Down()
    { 
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x , -fallSpeed);
    }
}
