using PlayerClasses.MovementClasses.InputClasses;

namespace PlayerClasses.MovementClasses.StateClasses
{
    public class PlayerState
    {
        protected PlayerMovementService playerMovementService;
        protected PlayerStateSwitcher stateSwitcher;
        protected PlayerRbController rbController;
        protected PlayerInputHandler inputHandler;

        public PlayerState(PlayerMovementService playerMovementService, PlayerStateSwitcher stateSwitcher, PlayerRbController rbController, PlayerInputHandler inputHandler)
        {
            this.playerMovementService = playerMovementService;
            this.stateSwitcher = stateSwitcher;
            this.rbController = rbController;
            this.inputHandler = inputHandler;
        }

        public virtual void Enter()
        {

        }
        public virtual void Exit()
        {

        }
        public virtual void Update()
        {

        }
        public virtual void FixedUpdate()
        {

        }

        protected void SwitchState(PlayerState state)
        {
            stateSwitcher.SwitchState(state);
        }
    }
}
