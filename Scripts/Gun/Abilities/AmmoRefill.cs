using System;

namespace GunClasses.Abilities
{ 
    public class AmmoRefill : IGunAbility
    {
        public event Action EventToListenTo;

        public AmmoRefill()
        {

        }

        protected void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
