using UnityEngine;

public class GameManager
{
    private IHealth _health;
    private IDeath _death;
    private IState _state;

    public GameManager(IHealth health,  ICharacter player, IDeath death , IState state  )
    {
        _health = health;
        _death = death;
        _state = state;
    }

    public void GlobalStuff()
    {
        Debug.Log("GlobalStuff() вызван");
        if (_state.GetCurrentState() == PlayerState.MovementState.Death)
        {
            Debug.Log("глобальный метод сработал");
        }
    }
    
    
    
   
}
