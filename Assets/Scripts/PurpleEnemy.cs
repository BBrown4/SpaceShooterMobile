using System;
using UnityEngine;

public class PurpleEnemy : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private float shootInterval;
    [SerializeField] private Transform leftCannon, rightCannon;
    [SerializeField] private GameObject bulletPrefab;
    private float _shootTimer;

    private void Start()
    {
        rb.linearVelocity = Vector2.down * speed;
    }

    private void Update()
    {
        _shootTimer += Time.deltaTime;

        if (_shootTimer >= shootInterval)
        {
            Instantiate(bulletPrefab, leftCannon.position, Quaternion.identity);
            Instantiate(bulletPrefab, rightCannon.position, Quaternion.identity);
            _shootTimer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            DeathSequence();
        }
    }

    public override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
        {
            return;
        }
        
        anim.SetTrigger("Damage");
    }

    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
