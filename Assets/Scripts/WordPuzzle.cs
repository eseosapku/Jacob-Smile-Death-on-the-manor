using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordPuzzle : MonoBehaviour
{
    public TextMeshProUGUI arrangementDisplay;
    public Button submitButton;
    public Image arrangementPanel;
    
    private string[] correctOrder =
    {
        "The", "Poison", "is", "inside", "the", "ice",
        "not", "in", "the", "milk", "when", "the",
        "ice", "melted", "the", "poison", "was", "released"
    };
    
    private List<string> playerOrder = new List<string>();

    void Start()
    {
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RemoveLastWord();
        }
    }

    private void ResetPuzzle()
    {
        playerOrder.Clear();
        arrangementDisplay.text = "";
        arrangementPanel.color = Color.white;
    }

    private void CheckWordPosition()
    {
        int index = playerOrder.Count - 1;

        if (playerOrder[index] != correctOrder[index])
        {
            arrangementPanel.color = Color.red;
        }
        else
        {
            arrangementPanel.color = Color.white;
        }
    }

    private void RemoveLastWord()
    {
        if (playerOrder.Count == 0) return;
        playerOrder.RemoveAt(playerOrder.Count - 1);
        arrangementDisplay.text = string.Join(" ", playerOrder);
        arrangementPanel.color = Color.white;
    }

    public void SelectWord(string word)
    {
        playerOrder.Add(word);
        arrangementDisplay.text = string.Join(" ", playerOrder);
        CheckWordPosition();
        
        if (playerOrder.Count == correctOrder.Length)
        {
            CheckAnswer();
        }
    }

    private void CheckAnswer()
    {
        bool isCorrect = true;
        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (playerOrder[i] != correctOrder[i])
            {
                isCorrect = false;
                break;
            }
        }
        
        if (isCorrect)
        {
            Debug.Log("you win!");
            PuzzleTracker.Instance.CompletePuzzle();
        }
        else
        {
            Debug.Log("Wrong order. Try again.");
            ResetPuzzle();
        }
    }
}