using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bosses
{
    public class SpecialBullet : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float speed;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float minExplodeTime = 1.5f;
        [SerializeField] private float maxExplodeTime = 2.5f;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private GameObject miniBulletPrefab;
        [SerializeField] private Transform[] spawnPoints;

        private void Start()
        {
            rb.linearVelocity = Vector2.down * speed;
            StartCoroutine(Explode());
        }

        private void Update()
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }

        private IEnumerator Explode()
        {
            var randExplodeTime = Random.Range(minExplodeTime, maxExplodeTime);
            yield return new WaitForSeconds(randExplodeTime);
            foreach (var spawnPoint in spawnPoints)
            {
                Instantiate(miniBulletPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
                Destroy(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}