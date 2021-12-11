using UnityEngine;
using PlayerClasses.GunClasses;
using GunClasses.AmmoClasses;

namespace GunClasses
{
    public abstract class Gun : MonoBehaviour
    {
        public PlayerGunService Holder { get; protected set; }
        public Transform ShootPoint;

        protected Rigidbody2D _gunRb;

        protected virtual void Awake()
        {
            _gunRb = GetComponent<Rigidbody2D>();
        }

        protected virtual void FixedUpdate()
        {
            SetMovement(Holder.transform.position, Holder.GetComponent<Rigidbody2D>().rotation);
        }

        private void SetMovement(Vector2 pos, float rotation)
        {
            transform.position = pos;
            _gunRb.rotation = rotation;
        }

        public void SetHolder(PlayerGunService holder)
        {
            Holder = holder;
        }
    }
}