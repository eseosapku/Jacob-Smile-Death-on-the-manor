using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PickupName : MonoBehaviour
{
    public Button submitButton;
    public TextMeshProUGUI letterDisplay;
    public TextMeshProUGUI revealText;
    private static string targetName = "JOSEPH";
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

        if (collectedLetters == targetName)
        {
            ShowReveal();
        }
    }
    void ReturnLastLetter()
    {
        if (collectedLetters.Length == 0) return;

        collectedLetters = collectedLetters.Substring(0, collectedLetters.Length - 1);
        letterDisplay.text = collectedLetters;
    }

    void CheckName()
        {
            if (collectedLetters == targetName)
            {
                ShowReveal();
                PuzzleTracker.Instance.CompletePuzzle();
            }
            else
            {
                Debug.Log("Wrong name. Try again.");
            }
        }

        void ShowReveal()
        {
            revealText.text = "JOSEPH...\n\nThe butler's name is Joseph.\n" +
                             "Young master Joseph's real name is Jonas.\n\n" +
                             "The butler is the poisoner.";
            collectedLetters = "";
        }
    }