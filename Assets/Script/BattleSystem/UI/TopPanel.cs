using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopPanel : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    private BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();
    }

    void Update()
    {
        long gold = (long)battleSystem.playerGold;
        goldText.text = gold.ToString();
    }
}