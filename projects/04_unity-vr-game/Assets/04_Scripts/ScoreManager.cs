using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Image healthBar;
    public Text healthText;
    public Text scoreText;
    public Text gameOverText;
    public Text startGameText;

    public GameObject scoreCanvas;

    private int healthPoints = 100;
    private int score = 0;

    public Color greenColor = Color.green;
    public Color redColor = Color.red;

    public EnemySpawner enemySpawner;

    // Use this for initialization
    void Start()
    {
        scoreCanvas.SetActive(false);
    }

    public void ResetGame()
    {
        SetHealthPoints(100);
        SetScore(0);

        foreach (CactusBehaviour cactus in FindObjectsOfType<CactusBehaviour>())
        {
            Destroy(cactus.gameObject);
        }

        gameOverText.gameObject.SetActive(false);
        startGameText.text = "Restart Game";
        scoreCanvas.SetActive(true);

        enemySpawner.ResetGame();

        GetComponent<AudioManager>().StartGame();
    }

    public void GameOver()
    {
        foreach (CactusBehaviour cactus in FindObjectsOfType<CactusBehaviour>())
        {
            cactus.gameObject.GetComponent<Animator>().Play("Idle");
            cactus.gameObject.GetComponent<MoveCactus>().moveSpeed = 0;
        }

        enemySpawner.StopSpawning();

        gameOverText.gameObject.SetActive(true);

        GetComponent<AudioManager>().GameOver();
    }

    public void SetHealthPoints(int points)
    {
        healthPoints = Mathf.Clamp(points, 0, 100);

        // update GUI
        RectTransform rt = healthBar.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(healthPoints * 2, 50);

        Color barColor = 0.01f * healthPoints * greenColor + (1.0f - 0.01f * healthPoints) * redColor;
        healthBar.color = barColor;

        healthText.text = string.Format("{0}%", healthPoints);

        // check if game over
        
        // TODO
    }

    public void DecreaseHealthPoints(int damage)
    {
        SetHealthPoints(healthPoints - damage);
    }

    public void SetScore(int points)
    {
        score = Mathf.Abs(points);

        // update GUI
        scoreText.text = string.Format("Score: {0}", score);
    }

    public void IncreaseScore(int points)
    {
        SetScore(score + points);

        enemySpawner.IncreaseDifficulty();
    }
}