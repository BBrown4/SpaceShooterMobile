using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;

    private bool _canPlayAnim = true;
    private float _health;

    private void Start()
    {
        _health = maxHealth;
        healthFill.fillAmount = _health / maxHealth;
    }

    public void PlayerTakeDamage(float damage)
    {
        _health -= damage;
        healthFill.fillAmount = _health / maxHealth;
        if (_canPlayAnim)
        {
            anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());
        }

        if (!(_health <= 0)) return;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private IEnumerator AntiSpamAnimation()
    {
        _canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        _canPlayAnim = true;
    }
}