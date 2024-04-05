using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EnemyRandomAi : MonoBehaviour
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

        if (units < 26) 
        {
            idFinder = enemyEconomy.unitDatas.Find(unit => unit.id == 1);
            unitCost = idFinder.cost;
        }

        else if (units >= 26 && units < 51)
        {
            idFinder = enemyEconomy.unitDatas.Find(unit => unit.id == 2);
            unitCost = idFinder.cost;
        }
        else if (units >= 51  && units < 76)
        {
            idFinder = enemyEconomy.unitDatas.Find(unit => unit.id == 3);
            unitCost = idFinder.cost;
        }
        else if (units >= 76)
        {
            idFinder = enemyEconomy.unitDatas.Find(unit => unit.id == 4);
            unitCost = idFinder.cost;
        }

    }

}
