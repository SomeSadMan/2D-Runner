using System;

public interface IHealth
{
    public bool IsPlayerAlive { get; set; }
    public void HideHeartFromBar();

    public void TakeDamage(int value);
    
    public void AddHeartInBar();
    
    event Action OnDeath;
}