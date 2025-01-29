using System;

public interface IHealth
{
    public void HideHeartFromBar();

    public void TakeDamage(int value);
    
    public void AddHeartInBar();
    
    event Action OnDeath;
}