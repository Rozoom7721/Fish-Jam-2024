using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitSplashArt : MonoBehaviour, IPointerClickHandler
{

    public string type;

    private BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();    
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        battleSystem.playerBuyUnit(type);
    }
}
