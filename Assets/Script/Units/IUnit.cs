using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    UnitStatistics Stats { get; set; }
    bool IsMoving { get; set; }
    bool IsAttacking{ get; set; }



    void Attack(IUnit otherUnit)
    {
    }

    void TakeDamage(double damage)
    {
    }

    void Move();
  

    void Distance();

}
