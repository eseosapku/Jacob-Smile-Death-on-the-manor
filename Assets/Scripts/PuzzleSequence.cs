using TMPro;
using UnityEngine;

public class PuzzleSequence : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;
    public GameObject puzzle4;
    public GameObject puzzle5;
    private int currentPuzzle = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowPuzzle1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowPuzzle1()
    {
        instructionText.text = "A man is dead. Poisoned.\nYour client, Primrose, is accused.\n\nYou must find the truth.\n\nStart by examining the crime scene.\nUse the UV light on the glass.";
        puzzle1.SetActive(true);
        puzzle2.SetActive(false);
        puzzle3.SetActive(false);
        puzzle4.SetActive(false);
        puzzle5.SetActive(false);
        currentPuzzle = 1;
    }

    void ShowPuzzle2()
    {
        instructionText.text = "The fingerprints match Primrose.\nBut something feels wrong.\n\nYou must use the SMILES ability.\nSelect a suspect and roll the dice.\nIf you're correct, the dice shows 6.";
        puzzle2.SetActive(true);
        puzzle1.SetActive(false);
        currentPuzzle = 2;
    }

    void ShowPuzzle3()
    {
        instructionText.text = "The SMILES reveals the truth:\nThe poison was in the ICE, not the milk.\n\nArrange the words to understand what happened.";
        puzzle3.SetActive(true);
        puzzle2.SetActive(false);
        currentPuzzle = 3;
    }

    void ShowPuzzle4()
    {
        instructionText.text = "The butler's name is scattered across the room.\nCollect the letters to uncover the poisoner's identity.";
        puzzle4.SetActive(true);
        puzzle3.SetActive(false);
        currentPuzzle = 4;
    }

    void ShowPuzzle5()
    {
        instructionText.text = "Now you know WHO did it.\nBut WHY did the butler kill Hendrick?\n\nAnswer the questions. True or False?";
        puzzle5.SetActive(true);
        puzzle4.SetActive(false);
        currentPuzzle = 5;
    }

    public void OnPuzzleComplete()
    {
        if (currentPuzzle == 1) ShowPuzzle2();
        else if (currentPuzzle == 2) ShowPuzzle3();
        else if (currentPuzzle == 3) ShowPuzzle4();
        else if (currentPuzzle == 4) ShowPuzzle5();
        else if (currentPuzzle == 5) GameComplete();
    }

    void GameComplete()
    {
        instructionText.text = "CASE SOLVED.\n\nPrimrose is innocent.\nThe butler is the killer.\nJustice has been served.";
    }
}
