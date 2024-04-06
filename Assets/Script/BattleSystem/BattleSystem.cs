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

    public double playerGold;
    public double enemyGold;

    public double playerMeleeCost;
    public double playerRangeCost;
    public double playerTankCost;
    public double playerHealerCost;

    public double enemyMeleeCost;
    public double enemyRangeCost;
    public double enemyTankCost;
    public double enemyHealerCost;

    public double playerMeleeCooldown;
    public double playerRangeCooldown;
    public double playerTankCooldown;
    public double playerHealerCooldown;

    public double enemyMeleeCooldown;
    public double enemyRangeCooldown;
    public double enemyTankCooldown;
    public double enemyHealerCooldown;

    public GameObject playerSpawner;
    public GameObject enemySpawner;

    public UnitSpawnQueue unitSpawnQueue;



    private void Start()
    {
        unitSpawnQueue = GetComponent<UnitSpawnQueue>();
        
        playerFraction = GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>();
        enemyFraction = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Fraction>();

        playerLeaderHealth = playerFraction.fractionStatistics.leaderHealthPoints;
        enemyLeaderHealth = enemyFraction.fractionStatistics.leaderHealthPoints;




        CalculateCosts();
        CalculateCooldowns();
        StartCoroutine(grantPassiveGold());
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

    private IEnumerator grantPassiveGold()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);

            playerGold += playerFraction.fractionStatistics.passiveGoldIncome;
            enemyGold += enemyFraction.fractionStatistics.passiveGoldIncome;
        }
    }


    private void CalculateCosts()
    {


        playerMeleeCost = playerFraction.fractionPassives.basePassiveGoldIncome * playerFraction.meleeUnit.unitCostInSeconds;
        playerRangeCost = playerFraction.fractionPassives.basePassiveGoldIncome * playerFraction.rangeUnit.unitCostInSeconds;
        playerTankCost = playerFraction.fractionPassives.basePassiveGoldIncome * playerFraction.tankUnit.unitCostInSeconds;
        playerHealerCost = playerFraction.fractionPassives.basePassiveGoldIncome * playerFraction.healerUnit.unitCostInSeconds;

        enemyMeleeCost = enemyFraction.fractionPassives.basePassiveGoldIncome * enemyFraction.meleeUnit.unitCostInSeconds;
        enemyRangeCost = enemyFraction.fractionPassives.basePassiveGoldIncome * enemyFraction.rangeUnit.unitCostInSeconds;
        enemyTankCost = enemyFraction.fractionPassives.basePassiveGoldIncome * enemyFraction.tankUnit.unitCostInSeconds;
        enemyHealerCost = enemyFraction.fractionPassives.basePassiveGoldIncome * enemyFraction.healerUnit.unitCostInSeconds;

    }

    private void CalculateCooldowns()
    {
        playerMeleeCooldown = playerFraction.fractionPassives.baseCooldownOfSkills + playerFraction.meleeUnit.unitCooldown;
        playerRangeCooldown = playerFraction.fractionPassives.baseCooldownOfSkills + playerFraction.rangeUnit.unitCooldown;
        playerTankCooldown = playerFraction.fractionPassives.baseCooldownOfSkills + playerFraction.tankUnit.unitCooldown;
        playerHealerCooldown = playerFraction.fractionPassives.baseCooldownOfSkills + playerFraction.healerUnit.unitCooldown;

        enemyMeleeCooldown = enemyFraction.fractionPassives.baseCooldownOfSkills + enemyFraction.meleeUnit.unitCooldown;
        enemyRangeCooldown = enemyFraction.fractionPassives.baseCooldownOfSkills + enemyFraction.rangeUnit.unitCooldown;
        enemyTankCooldown = enemyFraction.fractionPassives.baseCooldownOfSkills + enemyFraction.tankUnit.unitCooldown;
        enemyHealerCooldown = enemyFraction.fractionPassives.baseCooldownOfSkills + enemyFraction.healerUnit.unitCooldown;
    }


    public void playerBuyUnit(string unitType)
    {
        double cost = 0;
        Sprite splashArt = null;
        switch (unitType)
        {
            case "melee":
                {
                    cost = playerMeleeCost;
                    splashArt = playerFraction.meleeUnit.unitSplashArt;
                    break;
                }

            case "range":
                {
                    cost = playerRangeCost;
                    splashArt = playerFraction.rangeUnit.unitSplashArt;
                    break;
                }

            case "tank":
                {
                    cost = playerTankCost;
                    splashArt = playerFraction.tankUnit.unitSplashArt;
                    break;
                }
            case "healer":
                {
                    cost = playerHealerCost;
                    splashArt = playerFraction.healerUnit.unitSplashArt;
                    break;
                }
            default:
                break;
        }

        if(playerGold > cost)
        {
            playerGold -= cost;
            unitSpawnQueue.AddUnit(unitType,splashArt);
        }


    }


    public void spawnUnit(string unitType)
    {
        switch (unitType)
        {

            case "melee":
                {
                    // instantiate melee in fight system, unit.init(this) must be called right after instantiate
                    break;
                }

            case "range":
                {
                    // instantiate range in fight system, unit.init(this) must be called right after instantiate
                    break;
                }


            case "tank":
                {
                    // instantiate tank in fight system, unit.init(this) must be called right after instantiate
                    break;
                }

            case "healer":
                {
                    // instantiate healer in fight system, unit.init(this) must be called right after instantiate
                    break;
                }
        }

    }

}
