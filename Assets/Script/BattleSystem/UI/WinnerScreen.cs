using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerScreen : MonoBehaviour
{

    public Image meleeImage;
    public Image rangeImage;
    public Image tankImage;
    public Image healerImage;

    private BattleSystem battleSystem;


    private void Start()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        SceneManager.MoveGameObjectToScene(enemy, SceneManager.GetActiveScene());


        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();

        meleeImage.sprite = battleSystem.enemyFraction.meleeUnit.unitSplashArt;
        rangeImage.sprite = battleSystem.enemyFraction.rangeUnit.unitSplashArt;
        tankImage.sprite = battleSystem.enemyFraction.tankUnit.unitSplashArt;
        healerImage.sprite = battleSystem.enemyFraction.healerUnit.unitSplashArt;


    }

    public void meleeOnClick()
    {
        string unitId = battleSystem.enemyFraction.meleeUnit.unitId;
        battleSystem.playerFraction.AddUnit(unitId);
        battleSystem.playerFraction.bigPoints++;
        battleSystem.playerFraction.smallPoints++;
        battleSystem.playerFraction.levelsDone.Add(battleSystem.playerFraction.lastLevelId);

        battleSystem.playerFraction.saveData();

        SceneManager.LoadScene("mapa_mati");
    }

    public void rangeOnClick()
    {
        string unitId = battleSystem.enemyFraction.rangeUnit.unitId;
        battleSystem.playerFraction.AddUnit(unitId);
        battleSystem.playerFraction.bigPoints++;
        battleSystem.playerFraction.smallPoints++;
        battleSystem.playerFraction.levelsDone.Add(battleSystem.playerFraction.lastLevelId);

        battleSystem.playerFraction.saveData();


        SceneManager.LoadScene("mapa_mati");

    }

    public void tankOnClick()
    {
        string unitId = battleSystem.enemyFraction.tankUnit.unitId;
        battleSystem.playerFraction.AddUnit(unitId);
        battleSystem.playerFraction.bigPoints++;
        battleSystem.playerFraction.smallPoints++;
        battleSystem.playerFraction.levelsDone.Add(battleSystem.playerFraction.lastLevelId);

        battleSystem.playerFraction.saveData();


        SceneManager.LoadScene("mapa_mati");

    }

    public void healerOnClick()
    {
        string unitId = battleSystem.enemyFraction.healerUnit.unitId;
        battleSystem.playerFraction.AddUnit(unitId);
        battleSystem.playerFraction.bigPoints++;
        battleSystem.playerFraction.smallPoints++;
        battleSystem.playerFraction.levelsDone.Add(battleSystem.playerFraction.lastLevelId);

        battleSystem.playerFraction.saveData();


        SceneManager.LoadScene("mapa_mati");

    }





}
