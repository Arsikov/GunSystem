using UnityEngine;

namespace GunClasses.ChaingunClasses
{
    public class Chaingun : Gun
    {
        public GunMod ShieldMod { get; private set; }
        public GunMod BaseMod { get; private set; }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}
