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
        [SerializeField] private Chaingun _chaingun;
        [SerializeField] private Cannon _cannon;

        [SerializeField] private Ballista _ballista;
        [SerializeField] private PlasmaRifle _plasmaRifle;

        [SerializeField] private RocketLauncher _rocketLauncher;
        [SerializeField] private Shotgun _shotgun;
        #endregion

        public Transform GunPoint { get; private set; }
        public PlayerGunSwap Swapper { get; private set; }
        public PlayerGunUI GunUI { get; private set; }

        public void Awake()
        {
            InitializeGuns();
            Swapper = new PlayerGunSwap(new Gun[] { _chaingun, _cannon, _ballista, _plasmaRifle, _rocketLauncher, _shotgun }, _swapKeyBindings);
        }

        public void Update()
        {
            Swapper.HandleSwapInput();
        }

        private void InitializeGuns()
        {

        }
    }
}