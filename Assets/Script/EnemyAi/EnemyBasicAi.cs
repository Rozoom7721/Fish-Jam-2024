using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EnemyBasicAi : MonoBehaviour
{
    public int currentGold;
    public int unitCost;
    public EnemyEconomy enemyEconomy;
    public UnitData idFinder;
    public EnemyAbility enemyAbility;

    public void Start()
    {
        ChoseUnit();
    }

    public void FixedUpdate()
    {
        currentGold = enemyEconomy.gold;
        int ran = Random.Range(1, 25);
        if (ran == 1)
        {
            enemyAbility.UseAbility();
        }


        if (currentGold >= unitCost)
        {
            enemyEconomy.SpendGold(unitCost);
            //funkcja do spawnu wybranej jednostki
            ChoseUnit();
        }
        

    }
    public void ChoseUnit()
    {
        int units = Random.Range(0, 100);

        Debug.Log(units);

        if (units >= 0 && units < 81) 
        {
            idFinder = enemyEconomy.unitDatas.Find(unit => unit.id == 1);
            unitCost = idFinder.cost;
        }

        else if (units >= 81 && units < 91)
        {
            idFinder = enemyEconomy.unitDatas.Find(unit => unit.id == 2);
            unitCost = idFinder.cost;
        }
        else if (units >= 91  && units < 96)
        {
            idFinder = enemyEconomy.unitDatas.Find(unit => unit.id == 3);
            unitCost = idFinder.cost;
        }
        else if (units >= 96)
        {
            idFinder = enemyEconomy.unitDatas.Find(unit => unit.id == 4);
            unitCost = idFinder.cost;
        }

    }

}
