using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorSpawner : MonoBehaviour
{
        [SerializeField] private GameObject[] meteorPrefabs;
        [SerializeField] private float spawnTime;
        private float _timer;
        private int _i;

        private Camera _mainCam;
        private float _maxLeft;
        private float _maxRight;

        private void Start()
        {
                _mainCam = Camera.main;
                StartCoroutine(SetBoundariesCoroutine());
        }

        private void Update()
        {
                _timer += Time.deltaTime;
                if (!(_timer > spawnTime)) return;
                _i = Random.Range(0, meteorPrefabs.Length);

                var offset = 0f;
                if (meteorPrefabs[_i].TryGetComponent<SpriteRenderer>(out var spriteRenderer))
                {
                      offset = spriteRenderer.bounds.size.x / 2f;
                }
                
                Instantiate(meteorPrefabs[_i], new Vector3(Random.Range(_maxLeft + offset, _maxRight - offset), transform.position.y, -5),
                        Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                _timer = 0f;
        }

        [Button]
        private void SetBoundaries()
        {
                _maxLeft = _mainCam.ScreenToWorldPoint(Screen.safeArea.min).x;
                _maxRight = _mainCam.ScreenToWorldPoint(Screen.safeArea.max).x;
                var yPos = _mainCam.ScreenToWorldPoint(Screen.safeArea.max).y + 1.5f;
                
                transform.position = new Vector3(0, yPos, 0);
        }

        private IEnumerator SetBoundariesCoroutine()
        {
                yield return new WaitForSeconds(0.5f);
                SetBoundaries();
        }
}