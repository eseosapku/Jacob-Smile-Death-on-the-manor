using TMPro;
using UnityEngine;

public class TotalLives : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public static int lives = 10;
    public static TotalLives Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        UpdateLivesDisplay();
    }

    public void LoseLife()
    {
        lives--;
        Debug.Log("Life lost! Lives remaining: " + lives);
        UpdateLivesDisplay();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateLivesDisplay()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives + " ♥";
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER - No lives left!");
        // We'll add game over screen later
    }
}

