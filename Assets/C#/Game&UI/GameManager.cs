
public class GameManager
{
    private IHealth _health;
    private IDeath _death;

    public GameManager(IHealth health, IDeath death )
    {
        _health = health;
        _death = death;
    }
}
