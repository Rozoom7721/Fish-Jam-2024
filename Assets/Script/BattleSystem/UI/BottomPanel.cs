using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottomPanel : MonoBehaviour
{
    public Image meleeImage;
    public Image rangeImage;
    public Image tankImage;
    public Image healerImage;

    public TextMeshProUGUI meleeCost;
    public TextMeshProUGUI rangeCost;
    public TextMeshProUGUI tankCost;
    public TextMeshProUGUI healerCost;


    public Image queue1;
    public Image queue2;
    public Image queue3;
    public Image queue4;
    public Image queue5;


    private Fraction playerFraction;
    private BattleSystem battleSystem;

    private void Start()
    {
        playerFraction = GameObject.FindGameObjectWithTag("Player").GetComponent<Fraction>();

        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();

        meleeImage.sprite = playerFraction.meleeUnit.unitSplashArt;
        rangeImage.sprite = playerFraction.rangeUnit.unitSplashArt;
        tankImage.sprite = playerFraction.tankUnit.unitSplashArt;
        healerImage.sprite = playerFraction.healerUnit.unitSplashArt;

        meleeCost.text = battleSystem.playerMeleeCost.ToString();
        rangeCost.text = battleSystem.playerRangeCost.ToString();
        tankCost.text = battleSystem.playerTankCost.ToString();
        healerCost.text = battleSystem.playerHealerCost.ToString();

    }

    private void Update()
    {
        meleeCost.text = battleSystem.playerMeleeCost.ToString();
        rangeCost.text = battleSystem.playerRangeCost.ToString();
        tankCost.text = battleSystem.playerTankCost.ToString();
        healerCost.text = battleSystem.playerHealerCost.ToString();


        queue1.sprite = battleSystem.unitSpawnQueue.splashArts.Count >= 1 ? battleSystem.unitSpawnQueue.splashArts[0] : battleSystem.unitSpawnQueue.emptySprite;
        queue2.sprite = battleSystem.unitSpawnQueue.splashArts.Count >= 2 ? battleSystem.unitSpawnQueue.splashArts[1] : battleSystem.unitSpawnQueue.emptySprite;
        queue3.sprite = battleSystem.unitSpawnQueue.splashArts.Count >= 3 ? battleSystem.unitSpawnQueue.splashArts[2] : battleSystem.unitSpawnQueue.emptySprite;
        queue4.sprite = battleSystem.unitSpawnQueue.splashArts.Count >= 4 ? battleSystem.unitSpawnQueue.splashArts[3] : battleSystem.unitSpawnQueue.emptySprite;
        queue5.sprite = battleSystem.unitSpawnQueue.splashArts.Count >= 5 ? battleSystem.unitSpawnQueue.splashArts[4] : battleSystem.unitSpawnQueue.emptySprite;



    }


}
