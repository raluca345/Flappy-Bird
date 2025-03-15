using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    private int highScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject clouds;
    private float rainbowTime;
    public bool isGameOver = false;
    public Text highScoreText;

    public void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    [ContextMenu("Add Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        clouds.GetComponent<ParticleSystem>().Play();
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
        clouds.GetComponent<ParticleSystem>().Pause();
    }

    public void Update()
    {
        if (playerScore >= 50)
        {
            rainbowTime += Time.deltaTime;
            scoreText.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(rainbowTime, 1));
        }
        else if (playerScore >= 40)
        {
            scoreText.color = new Color(0.859f, 0.482f, 0.482f, 1.0f);
        }
        else if (playerScore >= 30)
        {
            scoreText.color = new Color(0.027f, 0.796f, 0.949f, 1.0f);
        }
        else if (playerScore >= 20)
        {
            scoreText.color = new Color(0.537f, 0.859f, 0.482f, 1.0f);
        }
        else if (playerScore >= 10)
        {
            scoreText.color = Color.yellow;
        }
    }

    public float GetSpeedMultiplier()
    {
        return 1.0f + (playerScore / 50.0f); // Increase speed by 2% for every 10 points
    }

    public float GetAdjustedSpawnRate(float baseSpawnRate)
    {
        return baseSpawnRate / GetSpeedMultiplier(); // Decrease spawn rate as speed increases
    }

}
