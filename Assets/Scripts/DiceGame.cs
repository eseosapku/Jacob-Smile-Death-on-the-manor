using Unity.VisualScripting;
using UnityEngine;

public class DiceGame : MonoBehaviour
{
    public GameObject[] Suspects;
    public DiceController controller;
    private int correctSuspect = 4;
    private int lives = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    void RollDice (int selectedIndex)
    {
        if (selectedIndex == correctSuspect)
        {
            Debug.Log("you win");
        }
        else
        {
            lives--;
            Debug.Log("you have " + lives + " left");
        }
    }
}
