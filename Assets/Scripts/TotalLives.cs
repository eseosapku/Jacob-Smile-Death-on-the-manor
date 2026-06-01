using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log("LIFE LOST at puzzle: " + FindFirstObjectByType<PuzzleSequence>().currentPuzzle + " | Stack: " + System.Environment.StackTrace);
        lives--;
        UpdateLivesDisplay();
        if (lives <= 0) GameOver();
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
        lives = 10;  // Reset lives for next attempt
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

