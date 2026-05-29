using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WordPuzzle : MonoBehaviour
{
    public TextMeshProUGUI arrangementDisplay;
    public Button submitButton;
    private string[] correctOrder =
    {
        "The", "Poison", "is", "inside", "the", "Ice",
        "not", "in", "the", "milk", "when", "the",
        "ice", "melted", "the", "poison", "was", "released"
    };
    private List<string> playerOrder = new List<string>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        submitButton.onClick.AddListener(CheckAnswer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectWord(string word)
    {
        playerOrder.Add(word);
        arrangementDisplay.text = string.Join(" ", playerOrder);
    }
    void CheckAnswer()
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
        }
        else
        {
            Debug.Log("Wrong order. Try again.");
            ResetPuzzle();
        }
    }

    void ResetPuzzle()
    {
        playerOrder.Clear();
        arrangementDisplay.text = "";
    }
}
