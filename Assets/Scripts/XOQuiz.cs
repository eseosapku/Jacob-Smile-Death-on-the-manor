using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XOQuiz : MonoBehaviour
{
    public Button xButton;
    public Button oButton;
    public TextMeshProUGUI[] statements;
    public TextMeshProUGUI resultText;
    private bool[] correctAnswers = { true, false, false, true, false, true, false, true, true };
    private int currentStatement = 0;
    private int correctCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xButton.onClick.AddListener(() => AnswerX());
        oButton.onClick.AddListener(() => AnswerO());
        HighlightStatement(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AnswerX()
    {
        CheckAnswer(false);
    }

    void AnswerO()
    {
        CheckAnswer(true);
    }

    void CheckAnswer(bool answer)
    {
        if (answer == correctAnswers[currentStatement])
        {
            statements[currentStatement].color = Color.green;
            correctCount++;

            if (correctCount == 9)
            {
                WinPuzzle();
            }
            else
            {
                currentStatement++;
                HighlightStatement(currentStatement);
            }
        }
        else
        {
            statements[currentStatement].color = Color.red;
        }
    }
    void HighlightStatement(int index)
    {
        statements[index].color = Color.yellow;
    }

    void WinPuzzle()
    {
        resultText.text = "The butler's motive revealed.\nPrrimrose is saved";
        PuzzleTracker.Instance.CompletePuzzle();
    }
}
