using Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bosses
{
    public class BossStats : Enemy
    {
        [SerializeField] private BossController controller;

        public override void HurtSequence()
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg")) return;
            
            anim.SetTrigger("Damage");
        }

        public override void DeathSequence()
        {
            base.DeathSequence();
            controller.ChangeState(EBossState.Death);
            Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            }
        }
    }
}