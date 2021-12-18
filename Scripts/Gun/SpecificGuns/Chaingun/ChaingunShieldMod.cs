using System;
using UnityEngine;
using GunClasses.AmmoClasses;

namespace GunClasses.ChaingunClasses
{
    public class ChaingunShieldMode : GunMod, IAmmoRequiredGunMod
    {
        public event Action<int> AmmoRequest;

        public event Action OnChaingunShieldModSpawn;
        public event Action OnChaingunShieldModIsActivated;
        public event Action OnChaingunShieldModRemove;

        private ChaingunInput _chaingunInput;
        private D_ChaingunShieldMod D_chaingunShieldMod;

        protected GunAmmoRequest _ammoRequest;

        private GameObject _shieldPrefab;
        private float _maxActiveTime;
        private float _timeUnitToSpendAmmo;
        private bool _shieldActivated;

        public ChaingunShieldMode(ChaingunInput chaingunInput, D_ChaingunShieldMod D_chaingunShieldMod, GunBulletAmmoContainer bulletAmmoContainer)
        {
            _chaingunInput = chaingunInput;

            this.D_chaingunShieldMod = D_chaingunShieldMod;

            _bulletAmmoContainer = bulletAmmoContainer;

            _maxActiveTime = D_chaingunShieldMod.MaxActivateTime;
            _timeUnitToSpendAmmo = D_chaingunShieldMod.TimeUnitToSpendAmmo;
            _shieldActivated = false;

            chaingunInput.OnShieldModEnableInputDown += OnEnableInputDown;
            chaingunInput.OnShieldModEnableInputPressed += OnEnableInputPressed;
            chaingunInput.OnShieldModDisableInputUp += OnDisableInputUp;

            OnChaingunShieldModSpawn += SpawnShield;

            OnChaingunShieldModIsActivated += ManipulateShield;
            OnChaingunShieldModIsActivated += CountDown;
            OnChaingunShieldModIsActivated += SpendAmmo;

            OnChaingunShieldModRemove += RemoveShield;
        }

        public override void Update()
        {
            base.Update();

            RechargeShield();
        }

        #region OnInput
        private void OnEnableInputDown()
        {
            if (_maxActiveTime >= D_chaingunShieldMod.MaxActivateTime)
            {
                OnChaingunShieldModSpawn?.Invoke();
            }
        }

        private void OnEnableInputPressed()
        {
            if (!_shieldActivated)
            {
                OnChaingunShieldModIsActivated?.Invoke();
            }
        }

        private void OnDisableInputUp()
        {
            if (_shieldActivated)
            {
                OnChaingunShieldModRemove?.Invoke();
            }
        }
        #endregion

        #region MethodsCalledOnEvent
        private void SpawnShield()
        {
            _shieldPrefab = GameObject.Instantiate(D_chaingunShieldMod.ShieldPrefab);
            _shieldActivated = true;
        }

        private void ManipulateShield()
        {

        }

        private void CountDown()
        {
            _maxActiveTime -= Time.deltaTime;

            if (_maxActiveTime < 0)
            {
                OnChaingunShieldModRemove?.Invoke();
            }
        }

        private void SpendAmmo()
        {
            _timeUnitToSpendAmmo -= Time.deltaTime;

            if (_timeUnitToSpendAmmo < 0)
            {
                _timeUnitToSpendAmmo = D_chaingunShieldMod.TimeUnitToSpendAmmo;
                if (_ammoRequest.GetAmmoValue() >= D_chaingunShieldMod.AmmoCost)
                {
                    _bulletAmmoContainer.CallOnModifyAmmoEvent(-D_chaingunShieldMod.AmmoCost);
                }
                else
                {
                    OnChaingunShieldModRemove?.Invoke();
                }
            }
        }

        private void RemoveShield()
        {
            GameObject.Destroy(_shieldPrefab);
            _shieldActivated = false;
        }
        #endregion

        private void RechargeShield()
        {
            if (!_shieldActivated && _maxActiveTime<D_chaingunShieldMod.MaxActivateTime)
            {
                _maxActiveTime += Time.deltaTime;
            }   
        }
    }
}