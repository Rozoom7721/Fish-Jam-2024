using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EnemyState
{
    DEFFENCE,
    ATTACK,
    IDLE, //nie robi nic czeka na dalsze informacje 
}
public class EnemyAdvanceAi : MonoBehaviour
{
    public int currentGold;
    public int unitCost;
    public EnemyEconomy enemyEconomy;
    public UnitData idFinder;
    public EnemyAbility enemyAbility;
    public EnemyState state;
    public void Start()
    {
        state = EnemyState.IDLE;
        ChoseUnit(1);

    }

    public void FixedUpdate()
    {
        currentGold = enemyEconomy.gold;
        //tu potrzebuje ju� danych od was typu ile jednostek jest na planszy i tak dalej ;
        if (currentGold >= 100)
            state = EnemyState.ATTACK;

        if (state == EnemyState.ATTACK)
        {
            //wysy�a jedn� z konfiguracji 
        }
        if (true /* tu doda� kod sprawdzaj�cy czy przeciwnik jest na naszej po�owie je�li tak kup jednoski*/)
        {

        }
        

    }
    public void ChoseUnit(int id)
    { 

    }

}
