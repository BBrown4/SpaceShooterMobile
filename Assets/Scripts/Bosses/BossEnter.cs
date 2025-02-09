using System.Collections;
using Enums;
using UnityEngine;

namespace Bosses
{
    public class BossEnter : BossBaseState
    {
        [SerializeField] private float speed;
        private Vector2 _enterPoint;
        
        protected override void Start()
        {
            base.Start();
            _enterPoint = MainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.7f));
        }

        public override void RunState()
        {
            StartCoroutine(RunEnterState());
        }

        private IEnumerator RunEnterState()
        {
            while (Vector2.Distance(transform.position, _enterPoint) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _enterPoint, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            
            Controller.ChangeState(EBossState.Attack);
        }
    }
}