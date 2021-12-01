using UnityEngine;

namespace GunClasses.ChaingunClasses
{
    public class ChaingunShootInput : GunShootInput
    {
        private Chaingun _chaingun;
        private D_ChaingunShootInput D_chaingunShootInput;

        private float _attackTime;

        public ChaingunShootInput(Gun gun, D_ChaingunShootInput D_chaingunShootInput) : base(gun)
        {
            _chaingun = gun as Chaingun;
            this.D_chaingunShootInput = D_chaingunShootInput;

            shootKey = D_chaingunShootInput.ShootKey;
            minTimeBtwShoots = D_chaingunShootInput.MinTimeBtwShoots;
            _attackTime = D_chaingunShootInput.AttackTime;
        }

        public override void HandleShootInput()
        {
            base.HandleShootInput();

            if (getShootKeyDown(shootKey) && isTimeBtwShootsPassed(minTimeBtwShoots))
            {
                _chaingun.Shoot.RunShootEvent();
                SetLastTimeShoot(minTimeBtwShoots);
            }

            if (getShootKey(shootKey) && isTimeBtwShootsPassed(minTimeBtwShoots))
            {
                _attackTime -= Time.deltaTime;

                if (_attackTime < 0)
                {
                    _attackTime = D_chaingunShootInput.AttackTime;

                    _chaingun.Shoot.RunShootEvent();
                    SetLastTimeShoot(minTimeBtwShoots);
                }
            }
        }
    }
}