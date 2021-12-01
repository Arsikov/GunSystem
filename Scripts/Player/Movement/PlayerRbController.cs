using UnityEngine;

namespace PlayerClasses.MovementClasses
{
    public class PlayerRbController : IRbController
    {
        public Rigidbody2D rb { get; protected set; }

        public PlayerRbController(Rigidbody2D rb)
        {
            this.rb = rb;
        }

        public void SetVelocity(Vector2 velocity)
        {
            rb.velocity = velocity;
        }
        public void AddVelocity(Vector2 velocity)
        {
            rb.velocity += velocity;
        }
        public void SetRotation(float rotation)
        {
            rb.rotation = rotation;
        }
    }
}
