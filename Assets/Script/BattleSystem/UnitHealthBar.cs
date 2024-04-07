using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealthBar : MonoBehaviour
{
    [SerializeField] private Transform bar;
    public BattleSystem battleSystem;
    public MeleeUnit hpUnit;
    public UnitStatistics unitStatistics;
    double currentHealth;
    void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();




    }

    void Update()
    {
        UnitHealth(hpUnit.CurrentHealthPoints);
    }
    public void UnitHealth(double sizeNormalized)
    {
        currentHealth = sizeNormalized;
        currentHealth = currentHealth / unitStatistics.unitHealthPoints;
        bar.localScale = new Vector3((float)currentHealth, 1f);
    }
}
