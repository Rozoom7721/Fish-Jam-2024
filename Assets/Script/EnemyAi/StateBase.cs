using UnityEngine;

public abstract class StateBase
{
    abstract public void OnEnter(AiStateMenager aiState, BattleSystem battle);

    abstract public void OnExit(AiStateMenager aiState, BattleSystem battle);

    abstract public void OnUpdate(AiStateMenager aiState, BattleSystem battle);

    abstract public void OnFixedUpdate(AiStateMenager aiState, BattleSystem battle);
}
