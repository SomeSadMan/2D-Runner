using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathService : IDeath
{
    public DeathService(ICharacter _player , IHealth health)
    {
        if (health != null)
        {
            health.OnDeath += () => Death(_player);
        }
    }
    
    public void Death(ICharacter player)
    {
        player.Rb.bodyType = RigidbodyType2D.Static;
        Debug.Log("Character is dead! Physical body is now static.");
        
    }

    
}
