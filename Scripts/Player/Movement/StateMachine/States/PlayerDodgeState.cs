using UnityEngine;
using PlayerClasses.MovementClasses.InputClasses;

namespace PlayerClasses.MovementClasses.StateClasses
{
    public class PlayerDodgeState : PlayerState
    {
        public Vector2 DodgeDirection { get; private set; }

        private D_PlayerDodgeState data;
        private float performTime;
        private float lastTimeDodged;

        public PlayerDodgeState(PlayerMovementService playerMovementService, PlayerStateSwitcher stateSwitcher, PlayerRbController rbController, PlayerInputHandler inputHandler, D_PlayerDodgeState data) : base(playerMovementService, stateSwitcher, rbController, inputHandler)
        {
            this.data = data;
            lastTimeDodged = 0;
        }

        public override void Enter()
        {
            base.Enter();

            rbController.SetVelocity(Vector2.zero);
            DodgeDirection = inputHandler.WalkDirection;
            DodgeDirection.Normalize();

            performTime = data.PerformTime;
        }

        public override void Update()
        {
            base.Update();

            performTime -= Time.deltaTime;

            if (performTime < 0)
            {
                if(inputHandler.WalkDirection != Vector2.zero)
                {
                    SwitchState(playerMovementService._walkState);
                }
                else
                {
                    SwitchState(playerMovementService._idleState);
                }
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            rbController.AddVelocity(DodgeDirection * data.Speed);
        }

        public override void Exit()
        {
            base.Exit();

            rbController.SetVelocity(Vector2.zero);
            lastTimeDodged = Time.time;
        }

        public bool AbleToDodge()
        {
            return Time.time >= lastTimeDodged + data.Cooldown;
        }

        public bool iDodging()
        {
            if (stateSwitcher.currentState != null) return false;
            return true;
        }
    }
}
