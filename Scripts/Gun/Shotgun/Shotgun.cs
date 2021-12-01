using UnityEngine;

namespace GunClasses.ShotgunClasses
{
    public class Shotgun : Gun
    {
        [SerializeField] private D_ShotgunShoot D_Shoot;
        [SerializeField] private D_ShotgunShootInput D_ShootInput;
        [SerializeField] private D_ShotgunAmmo D_Ammo;

        protected override void Awake()
        {
            base.Awake();

            ShootInput = new ShotgunShootInput(this, D_ShootInput);
            Shoot = new ShotgunShoot(this, D_Shoot);
            Ammo = new ShotgunAmmo(this, D_Ammo);
        }

        protected override void Update()
        {
            base.Update();

            if (Holder != null)
            {
                if (Ammo.CurrentAmmo > 0) ShootInput.HandleShootInput();    

                transform.position = Holder.GunPoint.position;
                _gunRb.rotation = Holder.GetComponent<Rigidbody2D>().rotation;
            }
        }
    }
}