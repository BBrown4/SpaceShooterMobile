using UnityEngine;

namespace PowerUps
{
    public class ShootingPowerup : BasePowerup
    {
        public override void ActivatePowerup(GameObject other)
        {
            base.ActivatePowerup(other);
            other.GetComponent<PlayerShooting>().IncreaseUpgrade(1);
            Destroy(gameObject);
        }
    }
}