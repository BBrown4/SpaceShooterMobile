using UnityEngine;

namespace PowerUps
{
    public class BasePowerup : MonoBehaviour
    {
        [SerializeField] private AudioClip audioToPlay;
        
        public virtual void ActivatePowerup(GameObject other)
        {
            AudioSource.PlayClipAtPoint(audioToPlay, transform.position, 1f);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ActivatePowerup(other.gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}