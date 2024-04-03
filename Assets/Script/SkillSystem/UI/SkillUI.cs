using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

using UnityEngine;

using UnityEngine.UI;

public class SkillUI : MonoBehaviour, IPointerClickHandler, ISkillOnClickListener
{
    public Fraction playerFraction;
    public string skillID;
    public int skillTier;

    private bool interactive;

    private void Start()
    {
        playerFraction = GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>();
        playerFraction.addSkillOnClickListener(this);


        interactive = playerFraction.skillTier >= skillTier;

        if(!interactive)
        {
            GetComponent<Image>().enabled = false;
        }

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        interactive = playerFraction.skillTier >= skillTier;
        if (!interactive) return;
        Debug.Log("click");

        playerFraction.UpgradeSkill(skillID, skillTier);
    }

    public void onSkillOnClick()
    {
        interactive = playerFraction.skillTier >= skillTier;
        if (interactive)
        {
            GetComponent<Image>().enabled = true;
        }
    }
}
