using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiStateMenager : MonoBehaviour
{
    public StateBase currentState;
    public IdleState idleState = new IdleState();
    public DefenceState defenceState = new DefenceState();
    public AttackState attackState = new AttackState();
    public StartState startState = new StartState();
    public BattleSystem battleSystem;
    public string unitName;
    public AiUnitSelect aiUnitSelect = new AiUnitSelect();

    public bool defences;


    private void Start()
    {
        currentState = startState;
        currentState.OnEnter(this, battleSystem);
        defences = false;

    }
    private void Update()
    {
        currentState.OnUpdate(this, battleSystem);
        
    }
    private void FixedUpdate()
    {
        currentState.OnFixedUpdate(this, battleSystem);

    }
    private void OnDisable()
    {
        currentState.OnExit(this, battleSystem);
    }
    public void SwitchStat(StateBase stateBase)
    {
        currentState = stateBase;
        stateBase.OnEnter(this, battleSystem);
    }
    public void SelectUnit()
    {
        unitName = aiUnitSelect.unitChoseEasy();       
    }
    public void isDefence()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PlayerUnit");
        if (objects.Length >= 5)
        {
            defences = true;
        }
        else defences = false;
    }

}
