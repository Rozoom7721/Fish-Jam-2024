using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private LeaderHealthBar leaderHealthBar;
    public BattleSystem battleSystem;

    void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();

       // leaderHealthBar.SetSize(.4f);
        
    }

    void Update()
    {
      //  Debug.Log(battleSystem.playerLeaderHealth);
     //   Debug.Log(battleSystem.playerFraction.fractionStatistics.leaderHealthPoints);
        leaderHealthBar.SetSize(5000000);

    }
}
