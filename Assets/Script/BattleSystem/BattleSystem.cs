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

    public Fraction playerFraction;
    public Fraction enemyFraction;

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

    public EnemySpawnQueue enemySpawnQueue;


    public string playerUnitsLayer = "PlayerUnits";
    public string enemyUnitsLayer = "EnemyUnits";



    private void Start()
    {
        unitSpawnQueue = GetComponent<UnitSpawnQueue>();
        enemySpawnQueue= GetComponent<EnemySpawnQueue>();


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

        if(unitSpawnQueue.queue.Count > 4)
        {
            return;
        }

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

        if(playerGold >= cost)
        {
            playerGold -= cost;
            unitSpawnQueue.AddUnit(unitType, splashArt);
        }


    }


    public void enemyBuyUnit(string unitType)
    {
        double cost = 0;
        Sprite splashArt = null;
        switch (unitType)
        {
            case "melee":
                {
                    cost = enemyMeleeCost;
                    splashArt = enemyFraction.meleeUnit.unitSplashArt;
                    break;
                }

            case "range":
                {
                    cost = enemyRangeCost;
                    splashArt = enemyFraction.rangeUnit.unitSplashArt;
                    break;
                }

            case "tank":
                {
                    cost = enemyTankCost;
                    splashArt = enemyFraction.tankUnit.unitSplashArt;
                    break;
                }
            case "healer":
                {
                    cost = enemyHealerCost;
                    splashArt = enemyFraction.healerUnit.unitSplashArt;
                    break;
                }
            default:
                break;
        }

        if (enemyGold >= cost)
        {
            enemyGold -= cost;
            enemySpawnQueue.AddUnit(unitType);
        }


    }


    public void spawnUnit(string unitType, bool isPlayer)
    {

       // Quaternion rotation = isPlayer ? playerSpawner.transform.rotation : enemySpawner.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
        Vector3 position = isPlayer ? playerSpawner.transform.position : enemySpawner.transform.position;

        switch (unitType)
        {

            case "melee":
                {
                    MeleeUnit unit = Instantiate(playerFraction.meleePrefab, position, Quaternion.identity).GetComponent<MeleeUnit>();

                    if(isPlayer)
                    {
                        unit.gameObject.tag = "PlayerUnit";
                        unit.gameObject.layer = LayerMask.NameToLayer(playerUnitsLayer);

                        unit.init(playerFraction, isPlayer);
                    }
                    else
                    {

                        unit.GetComponent<SpriteRenderer>().flipX = true;

                        unit.gameObject.tag = "EnemyUnit";
                        unit.gameObject.layer = LayerMask.NameToLayer(enemyUnitsLayer);
                        unit.init(enemyFraction, isPlayer);
                    }

                    break;
                }

            case "range":
                {
                    RangeUnit unit = Instantiate(playerFraction.rangePrefab, position, Quaternion.identity).GetComponent<RangeUnit>();

                    if (isPlayer)
                    {
                        unit.gameObject.tag = "PlayerUnit";
                        unit.gameObject.layer = LayerMask.NameToLayer(playerUnitsLayer);
                        unit.init(playerFraction, isPlayer);

                    }
                    else
                    {

                        unit.GetComponent<SpriteRenderer>().flipX = true;

                        unit.gameObject.tag = "EnemyUnit";
                        unit.gameObject.layer = LayerMask.NameToLayer(enemyUnitsLayer);

                        unit.init(enemyFraction, isPlayer);
                    }
                    break;
                }


            case "tank":
                {
                    TankUnit unit = Instantiate(playerFraction.tankPrefab, position, Quaternion.identity).GetComponent<TankUnit>();

                    if (isPlayer)
                    {
                        unit.gameObject.tag = "PlayerUnit";
                        unit.gameObject.layer = LayerMask.NameToLayer(playerUnitsLayer);
                        unit.init(playerFraction, isPlayer);
                    }
                    else
                    {
                        unit.GetComponent<SpriteRenderer>().flipX = true;

                        unit.gameObject.tag = "EnemyUnit";
                        unit.gameObject.layer = LayerMask.NameToLayer(enemyUnitsLayer);

                        unit.init(enemyFraction, isPlayer);

                    }
                    break;
                }

            case "healer":
                {
                    HealerUnit unit = Instantiate(playerFraction.healerPrefab, position, Quaternion.identity).GetComponent<HealerUnit>();

                    if (isPlayer)
                    {
                        unit.gameObject.tag = "PlayerUnit";
                        unit.gameObject.layer = LayerMask.NameToLayer(playerUnitsLayer);
                        unit.init(playerFraction, isPlayer);

                    }
                    else
                    {
                        unit.GetComponent<SpriteRenderer>().flipX = true;
                        unit.gameObject.tag = "EnemyUnit";
                        unit.gameObject.layer = LayerMask.NameToLayer(enemyUnitsLayer);

                        unit.init(enemyFraction, isPlayer);

                    }
                    break;
                }
        }

    }

}
