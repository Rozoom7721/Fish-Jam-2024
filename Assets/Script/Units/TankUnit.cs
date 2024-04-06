using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUnit : MonoBehaviour, IUnit
{

    
    public UnitStatistics Stats { get; set; }

    public double CurrentHealthPoints { get; set; }

    public void Attack(IUnit otherUnit)
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
