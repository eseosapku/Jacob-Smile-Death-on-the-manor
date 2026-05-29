using TMPro;
using UnityEngine;

public class PuzzleTracker : MonoBehaviour
{
    public TextMeshProUGUI progressText;
    private int puzzlesCompleted = 0;
    private int totalPuzzles = 5;
    public static PuzzleTracker Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void CompletePuzzle()
    {
        puzzlesCompleted++;
        Debug.Log("Puzzle completed! Progress: " + puzzlesCompleted + "/" + totalPuzzles);
        UpdateProgress();
        PuzzleSequence seq = FindFirstObjectByType<PuzzleSequence>();
        seq.OnPuzzleComplete();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateProgress();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateProgress()
    {
        progressText.text = "Investigation Progress: " + puzzlesCompleted + "/" + totalPuzzles;
    }
}
