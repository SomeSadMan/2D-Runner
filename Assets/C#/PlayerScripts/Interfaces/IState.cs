public interface IState
{
    public void CheckAnimationState(Player player , IHealth health);
    PlayerState.MovementState GetCurrentState();
}