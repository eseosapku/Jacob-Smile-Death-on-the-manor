using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class PickupName : MonoBehaviour
{
    public Button submitButton;
    public TextMeshProUGUI letterDisplay;
    public TextMeshProUGUI revealText;
    private static string targetName = "joseph";
    private static string collectedLetters = "";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        submitButton.onClick.AddListener(CheckName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    CollectLetter();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            ReturnLastLetter();
        }
    }

    void CollectLetter()
    {
        string letter = gameObject.name;
        collectedLetters += letter;
        letterDisplay.text = collectedLetters;

        gameObject.SetActive(false);
    }
    void ReturnLastLetter()
    {
        if (collectedLetters.Length == 0) return;

        collectedLetters = collectedLetters.Substring(0, collectedLetters.Length - 1);
        letterDisplay.text = collectedLetters;
    }


        void CheckName()
        {
            if (collectedLetters.ToUpper() == targetName.ToUpper())
            {
                ShowReveal();
            PuzzleSequence seq = FindFirstObjectByType<PuzzleSequence>();
            if (seq != null)
            {
                seq.StartCoroutine(WaitAndComplete());
            }
        }
        else
        {
            Debug.Log("Wrong name. Try again.");
            TotalLives.Instance.LoseLife();
            collectedLetters = "";
            letterDisplay.text = "";
        }
    }

        IEnumerator WaitAndComplete()
        {
            yield return new WaitForSeconds(4f);  // Show reveal text for 4 seconds
            PuzzleTracker.Instance.CompletePuzzle();
        }

        void ShowReveal()
        {
        revealText.gameObject.SetActive(true);
        revealText.text = "JOSEPH...\n\nThe butler's name is Joseph.\n" +
                             "Young master Joseph's real name is Jonas.\n\n" +
                             "The butler is the poisoner.";
            collectedLetters = "";
        }
    }