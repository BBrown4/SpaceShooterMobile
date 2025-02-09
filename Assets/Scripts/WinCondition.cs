using Managers;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private bool hasBoss;
    
    public bool CanSpawnBoss { get; private set; }
    
    private float _timer;

    // Update is called once per frame
    void Update()
    {
        if (EndGameManager.Instance.IsGameOver) return;
        
        _timer += Time.deltaTime;

        if (_timer >= possibleWinTime)
        {
            if (!hasBoss)
            {
                EndGameManager.Instance.StartResolveSequence();
            }
            else
            {
                CanSpawnBoss = true;
            }
            
            foreach (var spawner in spawners)
            {
                spawner.SetActive(false);
            }
            
            gameObject.SetActive(false);
        }
    }
}
