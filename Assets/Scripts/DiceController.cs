using UnityEngine;
using System.Collections;
using TMPro;

public class DiceController : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    private Animator animator;
    private bool isRolling = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    public void RollDice(bool isCorrect)
    {
        if (isRolling) return;
        StartCoroutine(RollAnimation(isCorrect));
    }

    IEnumerator RollAnimation(bool isCorrect)
    {
        isRolling = true;

        animator.enabled = true;
        animator.SetTrigger("diceRoll");

        yield return new WaitForSeconds(2f);

        int finalNumber;
        if (isCorrect)
        {
            finalNumber = 6;
        }
        else
        {
            finalNumber = Random.Range(1, 6);
        }

        animator.SetInteger("Face", finalNumber);

        if (resultText != null)
        {
            resultText.text = "Dice rolled: " + finalNumber;
        }

        Debug.Log("Dice landed on: " + finalNumber);

        yield return new WaitForSeconds(1f);

        animator.enabled = false;
        isRolling = false;
    }
}