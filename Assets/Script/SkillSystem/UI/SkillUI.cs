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

    public Sprite locked;
    public Sprite unlocked;
    private bool isBought;

    public Image icon;

    private void Start()
    {
        playerFraction = GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>();
        playerFraction.addSkillOnClickListener(this);


        checkIfBought();

        interactive = playerFraction.skillTier >= skillTier;

        if(!interactive)
        {
            icon.enabled = false;
            GetComponentInChildren<Image>().enabled = false;
        }
        else
        {
            icon.enabled = true;

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
        checkIfBought();
        interactive = playerFraction.skillTier >= skillTier;
        if (interactive)
        {
            GetComponent<Image>().enabled = true;
            icon.enabled = true;
        }
    }

    private void checkIfBought()
    {
        if(skillID == "passiveGoldIncome")
        {
            GetComponent<Image>().sprite = playerFraction.fractionSkills.passiveGoldIncome < skillTier  ? locked : unlocked;
        }

        if (skillID == "goldIncomeForUnit")
        {
            GetComponent<Image>().sprite = playerFraction.fractionSkills.goldIncomeForUnit < skillTier  ? locked : unlocked;
        }

        if (skillID == "unitHealthPoints")
        {
            GetComponent<Image>().sprite = playerFraction.fractionSkills.unitHealthPoints < skillTier ? locked : unlocked;
        }

        if (skillID == "leaderHealthPoints")
        {
            GetComponent<Image>().sprite = playerFraction.fractionSkills.leaderHealthPoints < skillTier ? locked : unlocked;
        }

        if (skillID == "cooldownOfSkills")
        {
            GetComponent<Image>().sprite = playerFraction.fractionSkills.cooldownOfSkills < skillTier ? locked : unlocked;
        }

        if (skillID == "unitAttackSpeed")
        {
            GetComponent<Image>().sprite = playerFraction.fractionSkills.unitAttackSpeed < skillTier ? locked : unlocked;
        }

        if (skillID == "unitDamage")
        {
            GetComponent<Image>().sprite = playerFraction.fractionSkills.unitDamage < skillTier ? locked : unlocked;
        }

        if (skillID == "unitCriticalHitChance")
        {
            GetComponent<Image>().sprite = playerFraction.fractionSkills.unitCriticalHitChance < skillTier ? locked : unlocked;
        }


    }

}
