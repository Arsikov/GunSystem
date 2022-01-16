using System;

namespace GunClasses.Abilities
{
    public interface IGunAbility
    {
        public event Action EventToListenTo;

        protected virtual void Execute() { }
    }
}
