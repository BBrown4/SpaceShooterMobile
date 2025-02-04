using Managers;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawners;
    
    private float _timer;

    // Update is called once per frame
    void Update()
    {
        if (EndGameManager.Instance.IsGameOver) return;
        
        _timer += Time.deltaTime;

        if (_timer >= possibleWinTime)
        {
            foreach (var spawner in spawners)
            {
                spawner.SetActive(false);
            }
            
            EndGameManager.Instance.StartResolveSequence();
            gameObject.SetActive(false);
        }
    }
}
