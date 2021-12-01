using UnityEngine;

public interface IRbController 
{
    public void SetVelocity(Vector2 velocity);
    public void AddVelocity(Vector2 velocity);
    public void SetRotation(float rotation);
}
