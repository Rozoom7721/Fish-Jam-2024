using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitList : MonoBehaviour
{
    public static List<int> unit = new List<int>();
    public static List<int> unitToFight = new List<int>();


    void Start()
    {
        unit.Add(1);
        unit.Add(2);
        unit.Add(3);
        unit.Add(4);
        unitToFight.Add(1);
        unitToFight.Add(2);
        unitToFight.Add(3);
        unitToFight.Add(4);
    }

    void Update()
    {
        foreach (int number in unitToFight)
        {
            Debug.Log(number);
        }
    }
}
