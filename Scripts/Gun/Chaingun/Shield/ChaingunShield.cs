using UnityEngine;
    
namespace GunClasses.ChaingunClasses
{
    public class ChaingunShield : GunShoot
    {
        private Chaingun chaingun;
        private D_ChaingunShield D_shield;

        private GameObject shield;
        private bool shieldActivated;

        public ChaingunShield(Chaingun chaingun, D_ChaingunShield D_chaingunShield)
        {
            this.chaingun = chaingun;
            D_shield = D_chaingunShield;

            shield = null;
            shieldActivated = false;

            chaingun.ShieldInput.OnSpawnShield += SpawnShield;
            chaingun.ShieldInput.OnRemoveShield += RemoveShield;
        }

        private void SpawnShield()
        {
            if (!shieldActivated)
            {
                shield = GameObject.Instantiate(D_shield.ShieldPrefab, Vector2.zero, Quaternion.identity);
                shieldActivated = true;
            }
            shield.transform.position = chaingun.ShootPoint.position;
            shield.transform.rotation = chaingun.ShootPoint.rotation;
        }

        private void RemoveShield()
        {
            GameObject.Destroy(shield);
            shield = null;
            shieldActivated = false;
        }
    }
}