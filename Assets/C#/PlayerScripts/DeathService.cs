using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathService : IDeath
{
    private ICharacter player;
    private IHealth health;
    
    public DeathService(ICharacter player , IHealth health)
    {
        Debug.Log("DeathService создан!");
        this.player = player;
        this.health = health;
    }

    public void AddEvent()
    { 
        Debug.Log("DeathService: AddEvent() вызван");
        health.OnDeath += () => Death(player);
    }
    
    public void Death(ICharacter player)
    {
        player.Rb.bodyType = RigidbodyType2D.Static;
        Debug.Log("Character is dead! Physical body is now static.");
        
    }

    
}
