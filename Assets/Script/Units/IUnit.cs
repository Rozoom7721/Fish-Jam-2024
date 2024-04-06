using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    double CurrentHealthPoints { get; set; }
    UnitStatistics Stats { get; set; }
    bool IsMoving { get; set; }
    bool IsAttacking{ get; set; }



    void Attack(IUnit otherUnit)
    {
        double damage = Stats.unitDamage;
        otherUnit.TakeDamage(damage);

    }

    void TakeDamage(double damage)
    {
        CurrentHealthPoints = CurrentHealthPoints - damage;

    }

    void Move();
  

    void Distance();

}
