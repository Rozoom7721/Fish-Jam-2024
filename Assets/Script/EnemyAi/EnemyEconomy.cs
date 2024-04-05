using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEconomy : MonoBehaviour
{
    public int  gold;
    public int unitCost;
    UnitData unitData = new UnitData();
    public List<UnitData> unitDatas = new List<UnitData>();

    

    void Start()
    {
        unitDatas.Add(new UnitData { cost = 10, id = 1 });
        unitDatas.Add(new UnitData { cost = 15, id = 2 });
        unitDatas.Add(new UnitData { cost = 20, id = 3 });
        unitDatas.Add(new UnitData { cost = 25, id = 4 });
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gold++;
    }
    public void SpendGold(int spendGold)
    {
        gold -= spendGold;
    }

}
