using Unity.VisualScripting;
using UnityEngine;

public class DiceGame : MonoBehaviour
{
    public GameObject[] Suspects;
    public DiceController controller;
    private int correctSuspect = 0;
    private int lives = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Suspects == null || Suspects.Length == 0)
        {
            Debug.Log("ERROR: Suspects array not assigned!");
            return;
        }

        if (Input.GetMouseButtonDown(0) && lives > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                int index = System.Array.IndexOf(Suspects, hit.collider.gameObject);
                if (index != -1)
                {
                    RollDice(index);
                }
            }
        }
    }

    void RollDice(int selectedIndex)
    {
        bool isCorrect = (selectedIndex == correctSuspect);
        controller.RollDice(isCorrect);

        if (isCorrect)
        {
            Debug.Log("Correct suspect!");
            PuzzleTracker.Instance.CompletePuzzle();
        }
        else
        {
            TotalLives.Instance.LoseLife();  
        }
    }
}
