namespace GunClasses.ShotgunClasses
{
    public class ShotgunShootInput : GunShootInput
    {
        private Shotgun _shotgun;
        private D_GunShootInput D_shotgunShootInput;

        public ShotgunShootInput(Gun gun, D_GunShootInput D_shotgunShootInput) : base(gun)
        {
            _shotgun = gun as Shotgun;
            this.D_shotgunShootInput = D_shotgunShootInput;

            shootKey = D_shotgunShootInput.ShootKey;
            minTimeBtwShoots = D_shotgunShootInput.MinTimeBtwShoots;
        }

        public override void HandleShootInput()
        {
            base.HandleShootInput();

            if (getShootKeyDown(shootKey) && isTimeBtwShootsPassed(minTimeBtwShoots))
            {
                _shotgun.Shoot.RunShootEvent();
                SetLastTimeShoot(minTimeBtwShoots);
            }
        }
    }
}