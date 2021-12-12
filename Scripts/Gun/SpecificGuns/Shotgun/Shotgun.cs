using UnityEngine;

namespace GunClasses.ShotgunClasses
{
    public class Shotgun : Gun
    {
        public ShotgunBaseMode BaseMode { get; private set; }
        public ShotgunFullAutoMode FullAutoMode { get; private set; }

    }
}