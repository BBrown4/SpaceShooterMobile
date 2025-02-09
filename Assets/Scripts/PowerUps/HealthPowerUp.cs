using UnityEngine;

namespace PowerUps
{
    public class HealthPowerUp : BasePowerup
    {
        [SerializeField] private int healAmount;

        public override void ActivatePowerup(GameObject other)
        {
            base.ActivatePowerup(other);
            other.GetComponent<PlayerStats>().AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
