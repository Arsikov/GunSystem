using GunClasses.DataClasses;
using UnityEngine;

namespace GunClasses.ShotgunClasses
{
    public class ShotgunShootInput : GunInput
    {

        private D_ShotgunBaseModeInput D_baseModeInput;
        private D_ShotgunFullAutoModeInput D_fullAutoModeInput;

        public ShotgunShootInput(D_GunModeTriggerInput D_gunModeTriggerInput) : base(D_gunModeTriggerInput)
        {
        }

        protected override void HandleInput()
        {
            if (GetKeyDown(D_gunModeTriggerInput.BaseModeTriggerInput) && GetTimeSinceLastTriggerPassed(D_baseModeInput.MinTimeBtwTriggers))
            {
                InvokeOnModeDownInputEvent();
                SetLastTimeTriggered();
            }
        }
    
    }
}