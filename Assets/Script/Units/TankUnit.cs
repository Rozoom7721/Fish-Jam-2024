using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUnit : MonoBehaviour, IUnit
{

    
    public UnitStats Stats { get; set; }

    public double CurrentHealthPoints { get; set; }

    public void Attack(double fractionDamage, IUnit otherUnit)
    {

    }

    public void TakeDamage(double damage)
    {

    }

    public void Move()
    {
    }

    public void Distance()
    {

    }
}
