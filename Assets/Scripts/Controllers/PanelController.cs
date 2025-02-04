using Managers;
using UnityEngine;

namespace Controllers
{
    public class PanelController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private GameObject winScreen;
        [SerializeField] private GameObject loseScreen;

        private void Start()
        {
            EndGameManager.Instance.RegisterPanelController(this);
        }

        public void ActivateWinScreen()
        {
            canvasGroup.alpha = 1;
            winScreen.SetActive(true);
        }

        public void ActivateLoseScreen()
        {
            canvasGroup.alpha = 1;
            loseScreen.SetActive(true);
        }
    }
}