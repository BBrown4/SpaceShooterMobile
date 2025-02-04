using System;
using UnityEngine;

namespace PowerUps
{
    public class ShieldPowerUp : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerShieldActivator>().ActivateShield();
                Destroy(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}