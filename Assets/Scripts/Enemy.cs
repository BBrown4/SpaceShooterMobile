using Managers;
using ScriptableObjects;
using UnityEngine;

public class Enemy : MonoBehaviour
{
       [SerializeField] protected float health;
       [SerializeField] protected Rigidbody2D rb;
       [SerializeField] protected Animator anim;
       [SerializeField] protected float damage;
       [SerializeField] protected GameObject explosionPrefab;
       [SerializeField] protected PowerUpSpawnerSO powerUpSpawner;

       [Header("Score")]
       [SerializeField] protected int scoreValue;

       public void TakeDamage(float dmg)
       {
              health -= dmg;
              HurtSequence();

              if (health <= 0)
              {
                     DeathSequence();
              }
       }

       public void TakeMaxDamage()
       {
              TakeDamage(health);
       }

       public virtual void HurtSequence()
       {
       }

       public virtual void DeathSequence()
       {
              EndGameManager.Instance.UpdateScore(scoreValue);
              if (powerUpSpawner != null)
              {
                     powerUpSpawner.SpawnPowerUp(transform.position);
              }
       }
}