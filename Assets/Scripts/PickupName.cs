using TMPro;
using UnityEngine;


public class PickupName : MonoBehaviour
{

    public TextMeshProUGUI letterDisplay;
    public TextMeshProUGUI revealText;
    private static string targetName = "JOSEPH";
    private static string collectedLetters = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

    void ShowReveal()
    {
        revealText.text = "JOSEPH...\n\nThe butler's name is Joseph.\n" +
                         "Young master Joseph's real name is Jonas.\n\n" +
                         "The butler is the poisoner.";
        collectedLetters = "";
    }
}
