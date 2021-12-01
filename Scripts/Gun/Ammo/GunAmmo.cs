namespace GunClasses.AmmoClasses
{
    public abstract class GunAmmo
    {
        public int CurrentAmmo { get; protected set; }

        protected void ReduceCurrectAmmo(int cost)
        {
            CurrentAmmo -= cost;
        }
    }
}