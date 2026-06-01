using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleSequence : MonoBehaviour
{
    public TextMeshProUGUI revealText; 
    public Button submitButton;
    public Button submitName;
    public TextMeshProUGUI diceResult;
    public TextMeshProUGUI instructionText;
    public Button beginButton;
    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;
    public GameObject puzzle4;
    public GameObject puzzle5;
    public int currentPuzzle = 0;
    public static bool gameStarted = false;

    void Start()
    {
        gameStarted = false;
        ShowIntro();
        beginButton.onClick.AddListener(OnBeginClicked);

        AudioSource[] allAudio = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        foreach (AudioSource audio in allAudio)
        {
            if (audio.gameObject.name != "HeartBeat audio")
            {
                audio.Stop();
            }
        }
    }

    public void ShowIntro()
    {
        GameObject revealObj = GameObject.Find("RevealText");
        if (revealObj != null) revealObj.SetActive(false);
        instructionText.text = "You are Detective Jacob Smile.\n\n" +
            "A man is dead. Poisoned.\n\n" +
            "Your client, Primrose, is accused.\n" +
            "She faces life in prison.\n\n" +
            "You have 6 days to find the truth.\n\n" +
            "This is your final day.";
        puzzle1.SetActive(true);
        puzzle2.SetActive(false);
        puzzle3.SetActive(false);
        puzzle4.SetActive(false);
        puzzle5.SetActive(false);
        beginButton.gameObject.SetActive(true);
        currentPuzzle = 0;
        if(diceResult != null)
        diceResult.gameObject.SetActive(false);
        if (revealText != null) revealText.gameObject.SetActive(false);
        if (submitButton != null) submitButton.gameObject.SetActive(false);
        if (submitName != null) submitName.gameObject.SetActive(false);
    }

    void OnBeginClicked()
    {
        if (currentPuzzle == 0)
        {
            gameStarted = true;
            instructionText.text = "Start by examining the crime scene.\nUse the UV Light to look for clues.\n\nThe faster the heartbeat the closer you are.";
            beginButton.gameObject.SetActive(false);
            currentPuzzle = 1;
        }
        else if (currentPuzzle == 2)
        {
            instructionText.text = "";
            beginButton.gameObject.SetActive(false);
            if (diceResult != null) diceResult.gameObject.SetActive(true);
        }
        else if (currentPuzzle == 3)
        {
            instructionText.text = "Click the words in order to build the sentence.";
            beginButton.gameObject.SetActive(false);
            if (diceResult != null)
            {
                diceResult.text = "";  
            }
            if (submitButton != null) submitButton.gameObject.SetActive(true);
        }
        else if (currentPuzzle == 4)
        {
            instructionText.text = "Find the letters! Left-click to collect, Right-click to return.";
            beginButton.gameObject.SetActive(false);
            if (submitButton != null) submitButton.gameObject.SetActive(true);
        }
    }

    public void ShowPuzzle2()
    {
        if (currentPuzzle >= 2) return;
        PuzzleTracker.Instance.ResetPuzzleFlag();

        instructionText.text = "Who do the fingerprints belong to.\n\nYou must use the SMILES ability.\nSelect a suspect and roll the dice.\nIf you're correct, the dice shows 6. And thats the owner of the print";

        AudioSource heartbeat = GameObject.Find("HeartBeat audio")?.GetComponent<AudioSource>();
        if (heartbeat != null) heartbeat.Stop();

        puzzle1.SetActive(false);
        puzzle2.SetActive(true);
        currentPuzzle = 2;
        beginButton.gameObject.SetActive(true);
        if (diceResult!= null) diceResult.gameObject.SetActive(true);
    }

    public void ShowPuzzle3()
    {
        Debug.Log("ShowPuzzle3 called!");
        if (currentPuzzle >= 3) return;
        PuzzleTracker.Instance.ResetPuzzleFlag();
        instructionText.text = "The SMILES reveals the truth...";
        puzzle2.SetActive(false);
        puzzle3.SetActive(true);
        if (diceResult != null)
            diceResult.gameObject.SetActive(false);
        if (submitButton != null) submitButton.gameObject.SetActive(true);
        currentPuzzle = 3;
        beginButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowPuzzle4()
    {
        if (currentPuzzle >= 4) return;
        PuzzleTracker.Instance.ResetPuzzleFlag();
        instructionText.text = "Who put the poision Ice in the milk. SMILE has scattered the name across the room.\nCollect the letters to uncover the poisoner's identity.";
        puzzle3.SetActive(false);
        puzzle4.SetActive(true);
        currentPuzzle = 4;
        if (submitButton != null) submitButton.gameObject.SetActive(false);
        beginButton.gameObject.SetActive(true);
        if (revealText != null) revealText.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowPuzzle5()
    {
        if (currentPuzzle >= 5) return;
        instructionText.text = "Now you know WHO did it.\nBut WHY did the butler kill Hendrick?\n\nAnswer the questions. True or False?";
        puzzle4.SetActive(false);
        puzzle5.SetActive(true);
        currentPuzzle = 5;
        beginButton.gameObject.SetActive(true);
        PuzzleTracker.Instance.ResetPuzzleFlag();
        if (revealText != null) revealText.gameObject.SetActive(false);
        if (submitButton != null) submitButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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