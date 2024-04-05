using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    double CurrentHealthPoints { get; set; }
    UnitStats Stats { get; set; }


    void Attack(double fractionDamage, IUnit otherUnit)
    {
        double damage= fractionDamage* Stats.unitDamage;
        otherUnit.TakeDamage(damage);

    }

    void TakeDamage(double damage)
    {
        CurrentHealthPoints = CurrentHealthPoints - damage;

    }

    void Move();
  

    void Distance();

}
