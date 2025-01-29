using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : IMovement
{
    private Rigidbody2D rigidbody2D;
    

    

    public PlayerMovement(Rigidbody2D _rigidbody2D)
    {
        rigidbody2D = _rigidbody2D;
    }
    
    public void Jump(float velocity)
    { 
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, velocity);
    }

    public void DoubleJump(float velocity)
    { 
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, velocity);
    }
    public void Down(float velocity)
    { 
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x , -velocity);
    }
}
