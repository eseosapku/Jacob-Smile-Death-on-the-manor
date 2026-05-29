using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        "not", "in", "milk"
    };
    private List<string> playerOrder = new List<string>();
    private HashSet<string> usedWords = new HashSet<string>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        submitButton.onClick.AddListener(CheckAnswer);
    }

    // Update is called once per frame
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
        string lastWord = playerOrder[playerOrder.Count - 1];
        playerOrder.RemoveAt(playerOrder.Count - 1);
        usedWords.Remove(lastWord);
        arrangementDisplay.text = string.Join(" ", playerOrder);
        arrangementPanel.color = Color.white;
    }
    public void SelectWord(string word)
    {
        if (usedWords.Contains(word))
        {
            Debug.Log("Word already used!");
            return;
        }
        playerOrder.Add(word);
        usedWords.Add(word);
        arrangementDisplay.text = string.Join(" ", playerOrder);
        CheckWordPosition();
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
