using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New PowerUp Spawner", menuName = "Scriptable Objects/Power Ups/Spawner")]
    public class PowerUpSpawnerSO : ScriptableObject
    {
        public int spawnThreshold;
        public GameObject[] powerUps;

        public void SpawnPowerUp(Vector3 spawnPos)
        {
            var chance = Random.Range(0, 100);

            if (chance < spawnThreshold) return;
            var index = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[index], spawnPos, Quaternion.identity);
        }
    }
}
