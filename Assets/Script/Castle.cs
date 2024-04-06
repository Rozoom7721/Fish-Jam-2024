using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    private Sprite unit1;
    private Sprite unit2;
    private Sprite unit3;
    private Sprite unit4;
    public Sprite herb;
    public MenuFraction menuFraction;
    public GameObject map;

    private Fraction enemyFraction;


    private void Start()
    {

        enemyFraction = GetComponent<Fraction>();

        unit1 = enemyFraction.meleeUnit.unitSplashArt;
        unit2 = enemyFraction.rangeUnit.unitSplashArt;
        unit3 = enemyFraction.tankUnit.unitSplashArt;
        unit4 = enemyFraction.healerUnit.unitSplashArt;

    }


    public void SpriteChange()
    {
        menuFraction.gameObject.SetActive(true);
        menuFraction.enemyFraction = enemyFraction;
        map.SetActive(false);
        
        menuFraction.unit1.sprite = unit1;
        menuFraction.unit2.sprite = unit2;
        menuFraction.unit3.sprite = unit3;
        menuFraction.unit4.sprite = unit4;
        menuFraction.herb.sprite = herb;
    }
}
