using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObjects/Unit")]

public class UnitStats : ScriptableObject
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
    public string unitId;
    public bool unitIsHealer;




}
