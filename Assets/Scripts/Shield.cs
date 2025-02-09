using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private int maxHits = 3;
    [SerializeField] private GameObject[] shieldIcons;
    private int _hitsToDestroy;
    public bool IsProtected { get; private set; }

    private void OnEnable()
    {
        _hitsToDestroy = maxHits;
        foreach (var shieldIcon in shieldIcons)
        {
            shieldIcon.SetActive(true);
        }
        
        IsProtected = true;
    }

    private void UpdateUI()
    {
        if (_hitsToDestroy == maxHits)
        {
            foreach (var icon in shieldIcons)
            {
                icon.SetActive(true);
            }
        }
        else
        {
            shieldIcons[_hitsToDestroy].SetActive(false);
        }
    }

    private void DamageShield()
    {
        _hitsToDestroy -= 1;
        if (_hitsToDestroy <= 0)
        {
            _hitsToDestroy = 0;
            IsProtected = false;
            gameObject.SetActive(false);
        }
        
        UpdateUI();
    }

    public void RepairShield()
    {
        _hitsToDestroy = maxHits;
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            if (other.CompareTag("Boss"))
            {
                _hitsToDestroy = 0;
                DamageShield();
                return;
            }
            
            enemy.TakeMaxDamage();
            DamageShield();
        }
        else
        {
            Destroy(other.gameObject);
            DamageShield();
        }
    }
}
