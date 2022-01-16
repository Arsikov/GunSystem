using System;

namespace GunClasses.Abilities
{
    public class TargetStun : IGunAbility
    {
        public event Action EventToListenTo;

        public TargetStun()
        {

        }

        protected void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
