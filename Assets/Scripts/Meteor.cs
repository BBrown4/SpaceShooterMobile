using UnityEngine;
using Random = UnityEngine.Random;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotateSpeed;
    private float _speed;

    private void Start()
    {
        _speed = Random.Range(minSpeed, maxSpeed);
        rb.linearVelocity = Vector2.down * _speed;
    }

    private void Update()
    {
        transform.Rotate(0,0, rotateSpeed * Time.deltaTime);
    }

    public override void HurtSequence()
    {
    }

    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        var playerStats = other.GetComponent<PlayerStats>();
        playerStats.PlayerTakeDamage(damage);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}