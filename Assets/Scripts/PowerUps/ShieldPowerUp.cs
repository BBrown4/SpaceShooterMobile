using UnityEngine;

namespace PowerUps
{
    public class ShieldPowerUp : BasePowerup
    {
        public override void ActivatePowerup(GameObject other)
        {
            base.ActivatePowerup(other);
            other.GetComponent<PlayerShieldActivator>().ActivateShield();
            Destroy(gameObject);
        }
    }
}