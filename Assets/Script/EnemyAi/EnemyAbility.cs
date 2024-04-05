using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAbility : MonoBehaviour
{
    public int cooldown;
    public bool abilityOnCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 1000;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (abilityOnCooldown)
        cooldown--;
        if (cooldown == 0)
        {
            abilityOnCooldown = false;
            cooldown = 1000;
        }
    }
    public void UseAbility()
    {
        if (abilityOnCooldown == false)
        {
        abilityOnCooldown = true;
        }
    }
}
