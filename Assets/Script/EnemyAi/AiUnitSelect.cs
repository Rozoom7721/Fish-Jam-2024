using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiUnitSelect
{
    public string unitChoseEasy()
    {
        string enemyUnitName;
        int random = Random.Range(0, 100);
        
        if (random >= 79)
        {
            enemyUnitName = "melee";
        }
        else if (random >79 && random <= 89)
        {
            enemyUnitName = "tank";
        }
        else if (random >89 && random <= 95)
        {
            enemyUnitName = "range";
        }
        else
        {
            enemyUnitName = "tank";
        }
        return enemyUnitName;
    }
}
