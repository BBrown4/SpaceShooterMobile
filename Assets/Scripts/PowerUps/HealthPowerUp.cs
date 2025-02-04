using System;
using UnityEngine;

namespace PowerUps
{
    public class HealthPowerUp : MonoBehaviour
    {
        [SerializeField] private int healAmount;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerStats>().AddHealth(healAmount);
                Destroy(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
