using System.Collections;
using Enums;
using UnityEngine;

namespace Bosses
{
    public class BossAttack : BossBaseState
    {
        [SerializeField] private float speed;
        [SerializeField] private float shootRate;
        [SerializeField] private GameObject bulletPrefab;

        [Header("Shooting Points")]
        [SerializeField] private Transform[] shootingPoints;

        public override void RunState()
        {
            StartCoroutine(RunFireState());
        }

        private IEnumerator RunFireState()
        {
            var timer = 0f;
            var fireStateTimer = 0f;
            var fireStateExitTime = Random.Range(5f, 10f);
            var targetPosition = GetRandomPosition();

            while (fireStateTimer <= fireStateExitTime)
            {
                if (Vector2.Distance(transform.position, targetPosition) > 0.01f)
                {
                    transform.position =
                        Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
                else
                {
                    targetPosition = GetRandomPosition();
                }

                timer += Time.deltaTime;
                if (timer >= shootRate)
                {
                    foreach (var point in shootingPoints)
                    {
                        Instantiate(bulletPrefab, point.position, Quaternion.identity);
                    }

                    timer = 0f;
                }

                yield return new WaitForEndOfFrame();
                fireStateTimer += Time.deltaTime;
            }

            // var randomPick = Random.Range(0, 2);
            // var state = randomPick != 0 ? EBossState.SpecialAttack : EBossState.Attack;
            // Controller.ChangeState(state);
            Controller.ChangeState(EBossState.SpecialAttack);
        }
    }
}