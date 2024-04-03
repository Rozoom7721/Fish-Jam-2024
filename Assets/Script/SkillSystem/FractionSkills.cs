using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FractionSkills", menuName = "ScriptableObjects/FractionSkills")]

public class FractionSkills : ScriptableObject
{

    public int passiveGoldIncome;
    public int goldIncomeForUnit;

    public int unitHealthPoints;
    public int leaderHealthPoints;

    public int cooldownOfSkills;
    public int unitAttackSpeed;

    public int unitDamage;
    public int unitCriticalHitChance;

}
