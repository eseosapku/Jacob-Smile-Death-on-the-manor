using TMPro;
using UnityEngine;

public class PuzzleTracker : MonoBehaviour
{
    public TextMeshProUGUI progressText;
    private int puzzlesCompleted = 0;
    private int totalPuzzles = 5;
    private bool isPuzzleComplete = false;
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
        if (isPuzzleComplete) return;
        isPuzzleComplete = true;
        puzzlesCompleted++;
        Debug.Log("Progress: " + puzzlesCompleted + "/" + totalPuzzles);
        UpdateProgress();
        PuzzleSequence seq = FindFirstObjectByType<PuzzleSequence>();
        if (seq != null)
        {
            seq.OnPuzzleComplete();
        }
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
    public void ResetPuzzleFlag()
    {
        isPuzzleComplete = false;
    }

    private void UpdateProgress()
    {
        progressText.text = "Investigation Progress: " + puzzlesCompleted + "/" + totalPuzzles;
    }
}
