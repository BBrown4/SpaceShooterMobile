using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;

    private void OnEnable()
    {
        var scoreKey = $"Score{SceneManager.GetActiveScene().name}";
        var highScoreKey = $"HighScore{SceneManager.GetActiveScene().name}";

        var score = PlayerPrefs.GetInt(scoreKey, 0);
        scoreText.text = $"Score: {score}";

        var highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highscoreText.text = $"Best: {highScore}";
    }
}