using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private LeaderHealthBar leaderHealthBar;
    [SerializeField] private EnemyLeaderHealthBar enemyLeaderHealthBar;

    public BattleSystem battleSystem;

    void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();

        
    }

    void Update()
    {
        leaderHealthBar.PlayerHealth(battleSystem.playerLeaderHealth);
        enemyLeaderHealthBar.EnemyHealth(battleSystem.enemyLeaderHealth);
    }
}
