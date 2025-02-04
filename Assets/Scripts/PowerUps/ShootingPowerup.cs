using System;
using UnityEngine;

namespace PowerUps
{
    public class ShootingPowerup : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerShooting>().IncreaseUpgrade(1);
                Destroy(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}