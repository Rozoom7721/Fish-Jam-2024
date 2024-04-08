using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackAdvanceState : StateBase
{
    double gold;
    double unitCost;
    List<string> unitName;
    public override void OnEnter(AiStateMenager aiState, BattleSystem battle)
    {
        aiState.AdvanceSelectunit();
        gold = battle.enemyGold;
        unitName = aiState.unitNames;
    }

    public override void OnExit(AiStateMenager aiState, BattleSystem battle)
    {

    }

    public override void OnFixedUpdate(AiStateMenager aiState, BattleSystem battle)
    {
        gold = battle.enemyGold;
        try
        {
            foreach (var unit in unitName)
            {
                switch (unit)
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
                gold = battle.enemyGold;
                if (gold >= unitCost)
                {
                    battle.enemyBuyUnit(unit);
                    unitName.Remove(unit);
                }
                else
                {
                    break;
                }
                if (unitName.Count == 0)
                {
                    aiState.SwitchStat(aiState.startState);
                }
            }
        }
        catch(System.Exception ex)
        {

        }

    }

    public override void OnUpdate(AiStateMenager aiState, BattleSystem battle)
    {

    }
}
