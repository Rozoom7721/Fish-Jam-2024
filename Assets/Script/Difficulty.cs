using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public Animator animator;
    public Fraction fraction;
    public Fraction fractionPlayer;
    public bool textShow;
    public TextMeshProUGUI howHard;
    public GameObject questGuy;
    void Start()
    {
        // animator = GetComponent<Animator>();
        questGuy.SetActive(false);
    }

    void OnMouseEnter()
    {
        questGuy.SetActive(true);

        animator.SetTrigger("Guy");

        if (fraction.skillTier <= fractionPlayer.skillTier)
        {
            howHard.text = "Easy";

        }
        else
        {
            howHard.text = "Hard";

        }

    }

    void OnMouseExit()
    {
        questGuy.SetActive(false);

        animator.SetTrigger("Eye");

        howHard.text = "";

    }
}
