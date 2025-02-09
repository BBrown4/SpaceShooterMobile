using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bosses
{
    public class BossBaseState : MonoBehaviour
    {
        protected Camera MainCam;
        protected Vector3 Offset;
        protected float MaxLeft;
        protected float MaxRight;
        protected float MaxDown;
        protected float MaxUp;
        protected float HalfSizeX;
        protected float HalfSizeY;
        protected BossController Controller;

        private void Awake()
        {
            Controller = GetComponent<BossController>();
        }

        protected virtual void Start()
        {
            MainCam = Camera.main;
            StartCoroutine(SetBoundariesCoroutine());
        }
        
        public virtual void RunState() {}

        public virtual void StopState()
        {
            StopAllCoroutines();
        }
        
        [Button]
        private void SetBoundaries()
        {
            MaxLeft = MainCam.ScreenToWorldPoint(Screen.safeArea.min).x;
            MaxRight = MainCam.ScreenToWorldPoint(Screen.safeArea.max).x;
        
            MaxDown = MainCam.ScreenToWorldPoint(Screen.safeArea.min).y;
            MaxUp = MainCam.ScreenToWorldPoint(Screen.safeArea.max).y;

            HalfSizeX = GetComponent<SpriteRenderer>().bounds.size.x / 2f;
            HalfSizeY = GetComponent<SpriteRenderer>().bounds.size.y / 2f;
        }

        private IEnumerator SetBoundariesCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            SetBoundaries();
        }

        protected Vector2 GetRandomPosition()
        {
            return new Vector2(Random.Range(MaxLeft + HalfSizeX, MaxRight - HalfSizeX),
                Random.Range(MaxUp - HalfSizeY, MaxDown / 2f + HalfSizeY));
        }
    }
}
