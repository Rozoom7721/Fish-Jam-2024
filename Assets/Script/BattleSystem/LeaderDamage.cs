using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderDamage : MonoBehaviour
{
    //  public MeleeUnit hpUnit;
    public BattleSystem battleSystem;

    public Collision2D collision;
    public List<MeleeUnit> meleeUnits = new List<MeleeUnit>();
    public List<RangeUnit> rangeUnits = new List<RangeUnit>();
    public List<TankUnit> tankUnits = new List<TankUnit>();
    public List<HealerUnit> healerUnits = new List<HealerUnit>();
    private float damageTimer = 0f;
    private float damageTimer2= 2f;
    public bool enemy;
    void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();

    }

    void Update()
    {
     
        damageTimer += Time.deltaTime;

        if (damageTimer >= damageTimer2)
        {
            DealDamage();
            damageTimer = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        MeleeUnit meleeUnit;
        collision.gameObject.TryGetComponent<MeleeUnit>(out meleeUnit);
        if (meleeUnit != null && collision.gameObject.CompareTag("EnemyUnit")== enemy)
        {
            meleeUnits.Add(meleeUnit);


        }
      
        RangeUnit rangeUnit;
        collision.gameObject.TryGetComponent<RangeUnit>(out rangeUnit);
        if (rangeUnit != null && collision.gameObject.CompareTag("EnemyUnit") == enemy)
        {

            rangeUnits.Add(rangeUnit);


        }
       
        TankUnit tankUnit;
        collision.gameObject.TryGetComponent<TankUnit>(out tankUnit);
        if (tankUnit != null && collision.gameObject.CompareTag("EnemyUnit") == enemy)
        {

            tankUnits.Add(tankUnit);


        }
     
        HealerUnit healerUnit;
        collision.gameObject.TryGetComponent<HealerUnit>(out healerUnit);
        if (healerUnit != null && collision.gameObject.CompareTag("EnemyUnit") == enemy)
        {

            healerUnits.Add(healerUnit);


        }
      

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyUnit") == enemy)
        {
            MeleeUnit meleeUnit;
            if (collision.gameObject.TryGetComponent<MeleeUnit>(out meleeUnit))
            {
                meleeUnits.Remove(meleeUnit);
            }
        }
        if (collision.gameObject.CompareTag("EnemyUnit") == enemy)
        {
            RangeUnit rangeUnit;
            if (collision.gameObject.TryGetComponent<RangeUnit>(out rangeUnit))
            {
                rangeUnits.Remove(rangeUnit);
            }
        }
        if (collision.gameObject.CompareTag("EnemyUnit") == enemy)
        {
            TankUnit tankUnit;
            if (collision.gameObject.TryGetComponent<TankUnit>(out tankUnit))
            {
                tankUnits.Remove(tankUnit);
            }
        }
        if (collision.gameObject.CompareTag("EnemyUnit") == enemy)
        {
            HealerUnit healerUnit;
            if (collision.gameObject.TryGetComponent<HealerUnit>(out healerUnit))
            {
                healerUnits.Remove(healerUnit);
            }
        }
    }

    private void DealDamage()
    {
        try
        {
            double damage = enemy ? (battleSystem.playerFraction.meleeUnit.unitDamage +  battleSystem.playerFraction.fractionPassives.baseUnitDamage)* Mathf.Pow(10,battleSystem.playerFraction.skillTier *3):
    (battleSystem.enemyFraction.meleeUnit.unitDamage + battleSystem.enemyFraction.fractionPassives.baseUnitDamage) * Mathf.Pow(10, battleSystem.enemyFraction.skillTier * 3);   
            damage = damage * 2;
            Debug.Log(damage);
            foreach (var meleeUnit in meleeUnits)
            {
                meleeUnit.TakeDamage(damage);
            }
            foreach (var rangeUnit in rangeUnits)
            {
                rangeUnit.TakeDamage(damage);
            }
            foreach (var tankUnit in tankUnits)
            {
                tankUnit.TakeDamage(damage);
            }
            foreach (var healerUnit in healerUnits)
            {
                healerUnit.TakeDamage(damage);
            }
        }
        catch(System.Exception ex) 
        {
            ;
        }
     
      
    }




}
