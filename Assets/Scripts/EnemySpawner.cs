using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField]
    private GameObject[] enemies;
    
    [Space(15)]
    [SerializeField]
    private float enemySpawnTime;
    
    private Camera _mainCam;
    private float _maxLeft;
    private float _maxRight;
    private float _enemyTimer;
    
    private void Start()
    {
        _mainCam = Camera.main;
        StartCoroutine(SetBoundariesCoroutine());
    }

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        _enemyTimer += Time.deltaTime;
        if (_enemyTimer >= enemySpawnTime)
        {
            var index = Random.Range(0, enemies.Length);
            var offset = enemies[index].GetComponent<SpriteRenderer>().bounds.size.x / 2f;
            Instantiate(enemies[index],
                new Vector3(Random.Range(_maxLeft + offset, _maxRight - offset), transform.position.y, 0f),
                Quaternion.identity);
            _enemyTimer = 0f;
        }
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