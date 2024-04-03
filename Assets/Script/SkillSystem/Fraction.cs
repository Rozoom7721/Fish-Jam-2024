using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraction : MonoBehaviour
{


    public string fractionName;

    public FractionPassives fractionPassives;
    public FractionSkills fractionSkills;
    private FractionStatistics fractionStatistics;
    public int skillTier;
    public int bigPoints;
    public int smallPoints;


    private List<Unit> availble_units;
    private List<Unit> selected_units;

    private List<ISkillOnClickListener> skillOnClickListeners;
    public void addSkillOnClickListener(ISkillOnClickListener listener)
    {
        skillOnClickListeners.Add(listener);
    }
    private void notifySkillOnClickListeners()
    {
        foreach(ISkillOnClickListener listener in skillOnClickListeners)
        {
            listener.onSkillOnClick();
        }
    }

    private void Awake()
    {
        skillOnClickListeners = new List<ISkillOnClickListener>();
        fractionStatistics = gameObject.AddComponent<FractionStatistics>();
    }

    void Start()
    {
        RecalculateStatistits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecalculateStatistits()
    {
        CalculateGoldIncome();
        CalculateHealthPoints();
        CalculateCooldown();
        CalculateDamage();
        updateSkillTier();
        
        
        notifySkillOnClickListeners();
    }

    private void CalculateGoldIncome()
    {
        fractionStatistics.passiveGoldIncome = fractionPassives.basePassiveGoldIncome + 10 * Mathf.Pow(2, fractionSkills.passiveGoldIncome);
        fractionStatistics.goldIncomeForUnit = fractionPassives.baseGoldIncomeForUnit + 10 * Mathf.Pow(2, fractionSkills.goldIncomeForUnit);
    }

    private void CalculateHealthPoints()
    {
        fractionStatistics.unitHealthPoints = fractionPassives.baseUnitHealthPoints * Mathf.Pow(10, fractionSkills.unitHealthPoints * 3);
        fractionStatistics.leaderHealthPoints = fractionPassives.baseLeaderHealthPoints *  Mathf.Pow(10, fractionSkills.leaderHealthPoints * 3);
    }

    private void CalculateCooldown()
    {
        fractionStatistics.cooldownOfSkills = fractionPassives.baseCooldownOfSkills - (fractionPassives.baseCooldownOfSkills * ((double)fractionSkills.cooldownOfSkills / 10));
        fractionStatistics.unitAttackSpeed = fractionPassives.baseUnitAttackSpeed + (fractionPassives.baseCooldownOfSkills * ((double)fractionSkills.cooldownOfSkills * 2 / 10));
    }

    private void CalculateDamage()
    {
        fractionStatistics.unitDamage = fractionPassives.baseUnitDamage * Mathf.Pow(10, fractionSkills.unitDamage * 3);
        fractionStatistics.unitCriticalHitChance = fractionPassives.baseUnitCriticalHitChance * fractionSkills.unitCriticalHitChance;
    }

    private void updateSkillTier()
    {
        if (fractionSkills.passiveGoldIncome >= 3
            && fractionSkills.unitHealthPoints >= 3
            && fractionSkills.cooldownOfSkills >= 3
            && fractionSkills.unitDamage >= 3)
        {
            skillTier = 4;
        }
        else if (fractionSkills.passiveGoldIncome >= 2
            && fractionSkills.unitHealthPoints >= 2
            && fractionSkills.cooldownOfSkills >= 2
            && fractionSkills.unitDamage >= 2)
        {
            skillTier = 3;
        }
        else if (fractionSkills.passiveGoldIncome >= 1
            && fractionSkills.unitHealthPoints >= 1
            && fractionSkills.cooldownOfSkills >= 1
            && fractionSkills.unitDamage >= 1)
        {
            skillTier = 2;
        }
        else
        {
            skillTier = 1;
        }

    }


    public void UpgradeSkill(string skillID, int tier)
    {

        if (tier > skillTier) return;

        switch(skillID)
        {
            case "passiveGoldIncome":
                if(bigPoints > 0 && fractionSkills.passiveGoldIncome < tier)
                {
                    fractionSkills.passiveGoldIncome += 1;
                    bigPoints -= 1;
                }
                break;

            case "goldIncomeForUnit":
                if (smallPoints > 0 && fractionSkills.goldIncomeForUnit < tier)
                {
                    fractionSkills.goldIncomeForUnit += 1;
                    smallPoints -= 1;
                }
                break;

            case "unitHealthPoints":
                if(bigPoints > 0 && fractionSkills.unitHealthPoints < tier)
                {
                    fractionSkills.unitHealthPoints += 1;
                    bigPoints -= 1;
                }
                break;

            case "leaderHealthPoints":
                if(smallPoints > 0 && fractionSkills.leaderHealthPoints < tier)
                { 
                    fractionSkills.leaderHealthPoints += 1;
                    smallPoints -= 1;
                }
                break;

            case "cooldownOfSkills":
                if(bigPoints > 0 && fractionSkills.cooldownOfSkills < tier)
                {
                    fractionSkills.cooldownOfSkills += 1;
                    bigPoints -= 1;
                }
                break;

            case "unitAttackSpeed":
                if(smallPoints > 0 && fractionSkills.unitAttackSpeed < tier)
                {
                    fractionSkills.unitAttackSpeed += 1;
                    smallPoints -= 1;
                }
                break;

            case "unitDamage":
                if(bigPoints > 0 && fractionSkills.unitDamage < tier)
                {
                    fractionSkills.unitDamage += 1;
                    bigPoints -= 1;
                }
                break;

            case "unitCriticalHitChance":
                if(smallPoints > 0 && fractionSkills.unitCriticalHitChance < tier)
                {
                    fractionSkills.unitCriticalHitChance += 1;
                    smallPoints -= 1;
                }
                break;

            default: break;

        }

        RecalculateStatistits();

    }

    public void AddUnit(string unitID)
    {

    }

    public void SelectUnit(string unitID)
    {

    }


}
