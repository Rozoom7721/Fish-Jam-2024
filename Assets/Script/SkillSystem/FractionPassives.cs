using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FractionPassives", menuName = "ScriptableObjects/FractionPassives")]

public class FractionPassives : ScriptableObject
{
    public double basePassiveGoldIncome;
    public double baseGoldIncomeForUnit;

    public double baseUnitHealthPoints;
    public double baseLeaderHealthPoints;

    public double baseCooldownOfSkills;
    public double baseUnitAttackSpeed;

    public double baseUnitDamage;
    public double baseUnitCriticalHitChance;

    public Sprite leaderSprite;
    public Sprite leaderSplashArt;
}
