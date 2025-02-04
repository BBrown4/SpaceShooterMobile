using System.Collections;
using Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Managers
{
    public class EndGameManager : PersistentSingleton<EndGameManager>
    {
        protected override void Awake()
        {
            base.Awake();
            Application.targetFrameRate = 60;
        }

        public bool IsGameOver { get; private set; }
        public const string LEVEL_UNLOCK = "LevelUnlock";

        private PanelController _panelController;
        private TextMeshProUGUI _scoreTextComponent;
        private int _score;

        public void SetGameOver(bool isGameOver)
        {
            IsGameOver = isGameOver;
        }

        public void UpdateScore(int score)
        {
            _score += score;
            _scoreTextComponent.text = $"Score: {_score}";
        }

        public void StartResolveSequence()
        {
            StopCoroutine(nameof(ResolveSequence));
            StartCoroutine(ResolveSequence());
        }

        private IEnumerator ResolveSequence()
        {
            yield return new WaitForSeconds(2f);
            ResolveGame();
        }
        
        public void ResolveGame()
        {
            if (!IsGameOver)
            {
                WinGame();
            }
            else
            {
                LoseGame();
            }
        }

        public void WinGame()
        {
            SaveScore();
            _panelController.ActivateWinScreen();
            var nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextLevel > PlayerPrefs.GetInt(LEVEL_UNLOCK, 0))
            {
                PlayerPrefs.SetInt(LEVEL_UNLOCK, nextLevel);
            }
        }

        public void LoseGame()
        {
            SaveScore();
            _panelController.ActivateLoseScreen();
        }

        private void SaveScore()
        {
            var scoreKey = $"Score{SceneManager.GetActiveScene().name}";
            var highScoreKey = $"HighScore{SceneManager.GetActiveScene().name}";
            
            PlayerPrefs.SetInt(scoreKey, _score);
            var highScore = PlayerPrefs.GetInt(highScoreKey, 0);
            if (_score > highScore)
            {
                PlayerPrefs.SetInt(highScoreKey, _score);
            }

            _score = 0;
        }

        public void RegisterPanelController(PanelController controller)
        {
            _panelController = controller;
        }

        public void RegisterScoreText(TextMeshProUGUI scoreText)
        {
            _scoreTextComponent = scoreText;
        }
    }
}