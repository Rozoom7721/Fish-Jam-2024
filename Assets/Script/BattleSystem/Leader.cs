using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{

    public bool isPlayer;
    BattleSystem battleSystem;
    SpriteRenderer leaderSprite;

    private void Start()
    {

        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();
        leaderSprite = GetComponent<SpriteRenderer>();


    }

    private void Update()
    {
        if(leaderSprite.sprite == null)
        {
            if (isPlayer)
            {
                leaderSprite.sprite = battleSystem.playerFraction.fractionPassives.leaderSprite;
            }
            else
            {
                leaderSprite.sprite = battleSystem.enemyFraction.fractionPassives.leaderSprite;

            }
        }
    }


}
