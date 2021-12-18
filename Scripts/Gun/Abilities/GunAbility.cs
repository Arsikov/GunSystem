using System;

namespace GunClasses.Abilities
{
    public abstract class GunAbility
    {
        public event Action EventToListenTo;

        protected abstract void Execute();
    }
}
