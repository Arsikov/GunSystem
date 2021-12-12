using UnityEngine;

namespace GunClasses.RocketClasses
{
    public class RocketLauncher : Gun
    {
        public RocketLauncherBaseMod BaseMod { get; private set; }
        public RocketLauncherBurstMod BurstMod { get; private set; }
    }
}