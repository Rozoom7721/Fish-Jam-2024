using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeaderHealthBar : MonoBehaviour
{
    [SerializeField] private Transform bar;
    public BattleSystem battleSystem;
    double currentHealth;
    void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();




    }

    void Update()
    {

    }
    public void EnemyHealth(double sizeNormalized)
    {
        currentHealth = sizeNormalized;
        currentHealth = currentHealth / battleSystem.enemyFraction.fractionStatistics.leaderHealthPoints;
        bar.localScale = new Vector3((float)currentHealth, 1f);
    }
}
