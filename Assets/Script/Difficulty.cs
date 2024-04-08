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

    private Color easyColor;
    private Color hardColor;


    void Start()
    {

        easyColor = new Color(0, 0, 0, 1);
        hardColor = new Color(1, 0, 0, 1);


        // animator = GetComponent<Animator>();
        questGuy.SetActive(false);
    }

    void OnMouseEnter()
    {
        questGuy.SetActive(true);

        animator.SetTrigger("Guy");

        if (fraction.skillTier <= fractionPlayer.skillTier)
        {
            howHard.text = "Looks like we have chances in this battle";
            howHard.color = easyColor;

        }
        else
        {
            howHard.text = "You are not ready for this";
            howHard.color = hardColor;

        }

    }

    void OnMouseExit()
    {
        questGuy.SetActive(false);

        animator.SetTrigger("Eye");

        howHard.text = "";

    }

    public void onButtonClick()
    {
        questGuy.SetActive(false);
        animator.SetTrigger("Eye");
        howHard.text = "";
    }

}
