using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiUnitSelect
{
    public string unitChoseEasy()
    {
        string enemyUnitName;
        int random = Random.Range(0, 100);

        if (random < 77)
        {
            enemyUnitName = "melee";
        }
        else if (random >= 77 && random < 87)
        {
            enemyUnitName = "healer";
        }
        else if (random >= 87 && random < 97)
        {
            enemyUnitName = "range";
        }
        else
        {
            enemyUnitName = "tank";
        }
        return enemyUnitName;
    }
    public List<string> UnitChoseAdvance()
    {
        int random = Random.Range(0, 100);
        List<string> result = new List<string>();

        if(random <15)
        {
            result.AddRange(new string[] { "melee", "melee", "melee", "melee" });
            return result;
        }
        else if (random >= 15 && random < 27)
        {
            result.AddRange(new string[] { "melee", "melee", "range", "range" });
            return result;
        }
        else if (random >= 27 && random < 39)
        {
            result.AddRange(new string[] { "tank", "range", "range" });
            return result;
        }
        else if (random >= 39 && random < 51)
        {
            result.AddRange(new string[] { "tank", "healer", "range" });
            return result;
        }
        else if (random >= 51 && random < 63)
        {
            result.AddRange(new string[] { "tank", "range", "healer" });
            return result;
        }
        else if (random >= 63 && random < 68)
        {
            result.AddRange(new string[] { "tank", "tank", "range", "range" });
            return result;
        }
        else if (random >= 68 && random < 73)
        {
            result.AddRange(new string[] { "range", "range", "range"});
            return result;
        }
        else if (random >= 73 && random < 78)
        {
            result.AddRange(new string[] { "melee", "healer", "melee", "healer" });
            return result;
        }
        else if (random >= 78 && random < 85)
        {
            result.AddRange(new string[] { "tank", "range", "melee", "melee" });
            return result;
        }
        else 
        {
            result.AddRange(new string[] { "melee", "healer", "range"});
            return result;
        }


    }
}
