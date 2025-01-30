using UnityEngine;

public class GameManager
{
    private IHealth _health;
    private IDeath _death;

    public GameManager(IHealth health,  ICharacter player )
    {
        _health = health;
        _death = new DeathService(player ,_health);
    }
    
   
}
