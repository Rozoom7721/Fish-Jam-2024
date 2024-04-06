using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : MonoBehaviour, IUnit
{
 

   
    public UnitStatistics Stats { get ; set; }
    public double CurrentHealthPoints { get ; set; }

    public void init()
    {
        Stats.init();
    }

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
