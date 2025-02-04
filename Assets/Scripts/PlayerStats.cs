using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Shield shield;

    private PlayerShooting _playerShooting;
    private bool _canPlayAnim = true;
    private float _health;

    private void Start()
    {
        _health = maxHealth;
        healthFill.fillAmount = _health / maxHealth;
        EndGameManager.Instance.SetGameOver(false);
        _playerShooting = GetComponent<PlayerShooting>();
    }

    public void PlayerTakeDamage(float damage)
    {
        if (shield.IsProtected) return;
        
        _health -= damage;
        healthFill.fillAmount = _health / maxHealth;
        if (_canPlayAnim)
        {
            anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());
        }
        
        _playerShooting.DecreaseUpgrade();
        
        if (_health <= 0)
        {
            EndGameManager.Instance.SetGameOver(true);
            EndGameManager.Instance.StartResolveSequence();
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void AddHealth(int amount)
    {
        _health += amount;
        if (_health > maxHealth)
        {
            _health = maxHealth;
        }

        healthFill.fillAmount = _health / maxHealth;
    }

    private IEnumerator AntiSpamAnimation()
    {
        _canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        _canPlayAnim = true;
    }
}