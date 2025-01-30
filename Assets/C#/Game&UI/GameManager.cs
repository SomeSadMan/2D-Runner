using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IHealth _health;
    private ICharacter _player;

    public void GameManagerConstruct (IHealth health,  ICharacter player )
    {
        _health = health;
        _player = player;
        DeathService death = new DeathService();
        health.OnDeath += () => death.Death(_player);
    }
    
    public void AddEvent()
    { 
        Debug.Log("DeathService: AddEvent() вызван");
        
    }

    public void GlobalStuff()
    {
       
    }
    
    
    
   
}
