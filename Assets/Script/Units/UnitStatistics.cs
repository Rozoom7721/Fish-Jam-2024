using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatistics : MonoBehaviour
{
    public double unitHealthPoints;
    public double unitDamage;
    public double unitAttackSpeed;
    public double unitCriticalHitChance;
    public double unitCooldown;
    public double unitMovementSpeed;
    public double unitGoldMultiplier;
    public double unitCostInSeconds;
    public double unitRange;
    public double unitGoldIncome;
    public double unitCost;
    private FractionPassives fractionPassives;
    private FractionSkills fractionSkills;
    public UnitStats unitStats;
    public Fraction fraction;

    void Start()
    {
        if (fraction==null)
        {
            fraction = GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>();
        }
        fractionSkills = fraction.fractionSkills;
        fractionPassives=fraction.fractionPassives;
    }

    public void RecalculateStatistics()
    {
        CalculateHealthPoints();
        CalculateDamage();
        CalculateAtackSpeed();
        CalculateGoldIncome();
        CalculateCost();

        unitCriticalHitChance = unitStats.unitCriticalHitChance;
        unitRange = unitStats.unitRange;
        unitCooldown= unitStats.unitCooldown;  
        unitMovementSpeed=unitStats.unitMovementSpeed;
        unitCostInSeconds=unitStats.unitCostInSeconds;
        unitGoldMultiplier = unitStats.unitGoldMultiplier;

    }
    private void CalculateHealthPoints()
    {
      unitHealthPoints = (fractionPassives.baseUnitHealthPoints + unitStats.unitHealthPoints) * Mathf.Pow(10, fractionSkills.unitHealthPoints * 3);

    }
    private void CalculateDamage()
    {
        unitDamage = (fractionPassives.baseUnitDamage+unitStats.unitDamage) * Mathf.Pow(10, fractionSkills.unitDamage * 3);
    }
    private void CalculateAtackSpeed()
    {

        unitAttackSpeed = (fractionPassives.baseUnitAttackSpeed+unitStats.unitAttackSpeed) + ((fractionPassives.baseCooldownOfSkills+unitStats.unitCooldown) * ((double)fractionSkills.cooldownOfSkills * 2 / 10));
    }
    private void CalculateGoldIncome()
    {
        unitGoldIncome = fractionPassives.baseGoldIncomeForUnit*unitStats.unitGoldMultiplier + 10 * Mathf.Pow(2, fractionSkills.goldIncomeForUnit);


    }

    private void CalculateCost()
    {

        unitCost = fractionPassives.basePassiveGoldIncome * unitStats.unitCostInSeconds;

    }






}
