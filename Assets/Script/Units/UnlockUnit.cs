using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class UnlockUnit : MonoBehaviour
{
    public int id = 0;
    //  public string slotId ;
    public int cooldown;

    public void Test()
    {
        if(cooldown == 0)
        {
            UnitList.unit.Add(id);
            cooldown = 3;
        }

        Debug.Log(id);
    }
    void OnEnable()
    {
        if (cooldown != 0)
        {
            cooldown--;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
