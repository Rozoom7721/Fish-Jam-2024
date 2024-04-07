using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceState : StateBase
{
    double gold;
    double unitCost;
    string unitName;
    public override void OnEnter(AiStateMenager aiState, BattleSystem battle)
    {
        aiState.SelectUnit();
        gold = battle.enemyGold;
        unitName = aiState.unitName;
        switch (unitName)
        {
            case "healer":
                unitCost = battle.enemyHealerCost; break;
            case "tank":
                unitCost = battle.enemyTankCost; break;
            case "range":
                unitCost = battle.enemyRangeCost; break;
            case "melee":
                unitCost = battle.enemyMeleeCost; break;
            default:
                break;
        }

    }

    public override void OnExit(AiStateMenager aiState, BattleSystem battle)
    {

    }

    public override void OnFixedUpdate(AiStateMenager aiState, BattleSystem battle)
    {
        gold = battle.enemyGold;
        Debug.Log(gold);
        if (gold >= unitCost)
        {
            battle.enemyBuyUnit(unitName);
            aiState.currentState = aiState.startState;
        }
    }

    public override void OnUpdate(AiStateMenager aiState, BattleSystem battle)
    {

    }
}
