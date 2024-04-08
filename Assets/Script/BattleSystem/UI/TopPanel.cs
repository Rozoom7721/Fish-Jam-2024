using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopPanel : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI goldText;

    private BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();
    }

    void Update()
    {
        long gold = (long)battleSystem.playerGold;

        hpText.text = battleSystem.playerLeaderHealth.ToString();
        goldText.text = gold.ToString();
    }
}
