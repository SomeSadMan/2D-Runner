using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathService : IDeath
{
    public void Death(ICharacter player)
    {
        if (player != null && player.Rb != null)
        {
            player.Rb.bodyType = RigidbodyType2D.Static;
            Debug.Log("Character is dead! Physical body is now static.");
        }
    }

    
}
