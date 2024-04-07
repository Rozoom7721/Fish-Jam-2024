using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiStateMenager : MonoBehaviour
{
    /// <summary>
    /// basic state value
    /// </summary>

    public StateBase currentState;
    public IdleState idleState = new IdleState();
    public DefenceState defenceState = new DefenceState();
    public AttackState attackState = new AttackState();
    public StartState startState = new StartState();
    public AttackAdvanceState att = new AttackAdvanceState();

    /// <summary>
    /// This game value
    /// </summary>

    public BattleSystem battleSystem;
    public string unitName;
    public AiUnitSelect aiUnitSelect = new AiUnitSelect();
    public List <string> unitNames = new List <string>();


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
    public void AdvanceSelectunit()
    {
        unitNames = aiUnitSelect.UnitChoseAdvance();
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
