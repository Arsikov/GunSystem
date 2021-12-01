using UnityEngine;
using PlayerClasses.GunClasses;
using GunClasses.InputClasses;
using GunClasses.AmmoClasses;

// gotta rewrite Gun to Holder relationship, espesially Gun's movement
namespace GunClasses
{
    public abstract class Gun : MonoBehaviour
    {
        public PlayerGunService Holder { get; protected set; }
        public Transform ShootPoint { get; private set; }

        #region Components
        public GunAmmo Ammo { get; protected set; }
        public GunShootInput ShootInput { get; protected set; }
        public GunShoot Shoot { get; protected set; }
        #endregion

        [SerializeField] protected KeyBindings _keyBindings;

        protected Rigidbody2D _gunRb;

        protected virtual void Awake()
        {
            _gunRb = GetComponent<Rigidbody2D>();

            ShootPoint = transform.GetChild(0);
        }

        protected virtual void Update()
        {

        }

        protected virtual void FixedUpdate()
        {
            //SetMovement(Holder.transform.position, Holder.GetComponent<Rigidbody2D>().rotation);
        }

        public void SetMovement(Vector2 pos, float rotation)
        {
            transform.position = pos;
            _gunRb.rotation = rotation;
        }
    }
}