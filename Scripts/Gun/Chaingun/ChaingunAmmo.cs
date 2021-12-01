using GunClasses.AmmoClasses;

namespace GunClasses.ChaingunClasses
{
    public class ChaingunAmmo : GunAmmo
    {
        public ChaingunAmmo(Chaingun chaingun, D_ChaingunAmmo D_GunAmmo)
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