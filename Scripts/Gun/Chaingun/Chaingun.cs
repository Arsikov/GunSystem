using UnityEngine;

namespace GunClasses.ChaingunClasses
{
    public class Chaingun : Gun
    {
        public ChaingunShield Shield { get; private set; }
        public ChaingunShieldInput ShieldInput { get; private set; }

        [SerializeField] private D_ChaingunShoot D_Shoot;
        [SerializeField] private D_ChaingunShootInput D_ShootInput;
        [SerializeField] private D_ChaingunAmmo D_Ammo;
        [SerializeField] private D_ChaingunShield D_Shield;
        [SerializeField] private D_ChaingunShieldInput D_ShieldInput;

        protected override void Awake()
        {
            base.Awake();

            ShootInput = new ChaingunShootInput(this, D_ShootInput);
            Shoot = new ChaingunShoot(this, D_Shoot);
            Ammo = new ChaingunAmmo(this, D_Ammo);
            ShieldInput = new ChaingunShieldInput(this, D_ShieldInput);
            Shield = new ChaingunShield(this, D_Shield);
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (Holder != null)
            {
                SetMovement(Holder.transform.position, Holder.GetComponent<Rigidbody2D>().rotation);
            }
        }
    }
}
