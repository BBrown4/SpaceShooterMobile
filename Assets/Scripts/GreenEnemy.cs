using UnityEngine;

public class GreenEnemy : Enemy
{
    [SerializeField] private float speed;
    
    private void Start()
    {
        rb.linearVelocity = Vector2.down * speed;
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
        base.DeathSequence();
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}