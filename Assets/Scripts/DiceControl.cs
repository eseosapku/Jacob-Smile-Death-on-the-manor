using UnityEngine;

public class DiceControl : MonoBehaviour
{
    private DiceController diceController;

    void Start()
    {
        diceController = GetComponent<DiceController>();
    }

    void Update()
    {
        // Don't move while rolling
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.origin + ray.direction * 3f;
        }
    }
}