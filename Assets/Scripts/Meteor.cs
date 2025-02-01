using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float _speed;

    private void Start()
    {
        _speed = Random.Range(minSpeed, maxSpeed);
        rb.linearVelocity = Vector2.down * _speed;
    }

    public override void HurtSequence()
    {
    }

    public override void DeathSequence()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}