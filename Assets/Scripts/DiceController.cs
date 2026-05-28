using UnityEngine;

public class DiceController : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollDice(bool istrue)
    {
        animator.SetTrigger("diceRoll");

        if (istrue)
        {
            animator.SetInteger("Face", 6);
        }
        else
        {
            int randomNumber = Random.Range(1, 6);
            animator.SetInteger("Face", randomNumber);
        }
    }
}
