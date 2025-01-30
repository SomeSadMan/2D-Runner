using UnityEngine;

public class GameManager
{
    private IHealth _health;
    private IDeath _death;

    public GameManager(IHealth health,  ICharacter player, IDeath death )
    {
        _health = health;
        _death = death;
    }
    
    
    
   
}
