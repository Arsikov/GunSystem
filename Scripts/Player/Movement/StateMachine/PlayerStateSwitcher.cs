namespace PlayerClasses.MovementClasses.StateClasses
{
    public class PlayerStateSwitcher
    {
        public PlayerState currentState { get; private set; }

        public void Initialize(PlayerState startState)
        {
            currentState = startState;
            currentState.Enter();
        }

        public void SwitchState(PlayerState newState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }
    }
}
