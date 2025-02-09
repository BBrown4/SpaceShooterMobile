using Enums;
using UnityEngine;

namespace Bosses
{
    public class BossController : MonoBehaviour
    {
        [SerializeField] private BossEnter enterState;
        [SerializeField] private BossAttack attackState;
        [SerializeField] private BossSpecial specialAttackState;
        [SerializeField] private BossDeath deathState;

        [SerializeField] private bool test;
        [SerializeField] private EBossState testState;

        private void Start()
        {
            if (test)
            {
                ChangeState(testState);
                return;
            }
            
            ChangeState(EBossState.Enter);
        }

        public void ChangeState(EBossState state)
        {
            switch (state)
            {
                case EBossState.Enter:
                    enterState.RunState();
                    break;
                case EBossState.Attack:
                    attackState.RunState();
                    break;
                case EBossState.SpecialAttack:
                    specialAttackState.RunState();
                    break;
                case EBossState.Death:
                    enterState.StopState();
                    attackState.StopState();
                    specialAttackState.StopState();
                    deathState.RunState();
                    break;
            }
        }
    }
}
