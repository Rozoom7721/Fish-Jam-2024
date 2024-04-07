using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : StateBase
{
    double gold;
    bool defence;
    public override void OnEnter(AiStateMenager aiState, BattleSystem battle)
    {
;

    }

    public override void OnExit(AiStateMenager aiState, BattleSystem battle)
    {

    }
    
    public override void OnFixedUpdate(AiStateMenager aiState, BattleSystem battle)
    {
        gold = battle.enemyGold;
        defence = aiState.defences;
        aiState.isDefence();
        if (defence == true && battle.enemyFraction.fractionSkills.cooldownOfSkills < 2)
        {
            aiState.SwitchStat(aiState.defenceState);
        }
        else if (gold >= 100 && battle.enemyFraction.fractionSkills.cooldownOfSkills <2)
        {
            aiState.SwitchStat(aiState.attackState);
        }
        else if (battle.enemyFraction.fractionSkills.cooldownOfSkills >= 2)

        aiState.SwitchStat(aiState.att);
    }

    public override void OnUpdate(AiStateMenager aiState, BattleSystem battle   )
    {

    }
}
