using UnityEngine;

namespace GunClasses.ChaingunClasses
{
    public class Chaingun : Gun
    {
        public GunMode ShieldMode { get; private set; }
        public GunMode BaseMode { get; private set; }

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
