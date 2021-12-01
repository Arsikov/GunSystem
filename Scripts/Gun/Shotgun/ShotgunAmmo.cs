using GunClasses.AmmoClasses;

namespace GunClasses.ShotgunClasses
{
    public class ShotgunAmmo : GunAmmo
    {
        public ShotgunAmmo(Shotgun chaingun, D_ShotgunAmmo D_GunAmmo)
        {
            chaingun.Shoot.OnShoot += OnChaingunShoot;

            CurrentAmmo = D_GunAmmo.TotalAmmo;
        }

        private void OnChaingunShoot()
        {
            ReduceCurrectAmmo(1);
        }
    }
}
