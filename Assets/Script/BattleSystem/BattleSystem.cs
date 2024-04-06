using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour, ILeaderHitListener
{
    public double playerLeaderHealth;
    public Sprite playerLeaderSprite;

    public double enemyLeaderHealth;
    public Sprite enemyLeaderSprite;

    public GameObject winScreen;
    public GameObject loseScreen;

    private Fraction playerFraction;
    private Fraction enemyFraction;



    private void Start()
    {
        playerFraction = GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>();
        enemyFraction = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Fraction>();

        playerLeaderHealth = playerFraction.fractionStatistics.leaderHealthPoints;
        enemyLeaderHealth = enemyFraction.fractionStatistics.leaderHealthPoints;



    }


    public void onLeaderHit(bool isLeaderPlayer, double damage)
    {
        if(isLeaderPlayer)
        {
            playerLeaderHealth -= damage;
        }
        else
        {
            enemyLeaderHealth -= damage;
        }

        if(playerLeaderHealth < 0 || enemyLeaderHealth < 0)
        {
            endBattle();
        }

    }

    private void endBattle()
    {
       if(playerLeaderHealth > 0)
        {
            winScreen.SetActive(true);
        }
       else
        {
            loseScreen.SetActive(true);
        }
    }

}
