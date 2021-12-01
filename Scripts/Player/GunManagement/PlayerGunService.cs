using UnityEngine;
using PlayerClasses.GunClasses.InputClasses;

using GunClasses;
using GunClasses.BallistaClasses;
using GunClasses.ChaingunClasses;
using GunClasses.ShotgunClasses;
using GunClasses.PlasmaClasses;
using GunClasses.RocketClasses;
using GunClasses.CannonClasses;

namespace PlayerClasses.GunClasses
{   
    public class PlayerGunService : MonoBehaviour
    {
        [SerializeField] private SwapKeyBindings _swapKeyBindings;

        #region GunPrefabs
        [Header("Gun Prefabs")]
        [SerializeField] private Chaingun Chaingun;
        [SerializeField] private Cannon Cannon;

        [SerializeField] private Ballista Ballista;
        [SerializeField] private PlasmaRiffle PlasmaRiffle;

        [SerializeField] private RocketLauncher RocketLauncher;
        [SerializeField] private Shotgun Shotgun;
        #endregion

        public Transform GunPoint { get; private set; }
        public PlayerGunSwap Swapper { get; private set; }
        public PlayerGunUI GunUI { get; private set; }

        public void Awake()
        {
            Swapper = new PlayerGunSwap(new Gun[] { Chaingun, Cannon, Ballista, PlasmaRiffle, RocketLauncher, Shotgun }, _swapKeyBindings);
        }

        public void Update()
        {
            Swapper.HandleSwapInput();
        }
    }
}