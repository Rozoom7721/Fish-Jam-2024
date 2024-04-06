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

    private Fraction fraction;


    private void Start()
    {

        fraction = GetComponent<Fraction>();

        unit1 = fraction.meleeUnit.unitSplashArt;
        unit2 = fraction.rangeUnit.unitSplashArt;
        unit3 = fraction.tankUnit.unitSplashArt;
        unit4 = fraction.healerUnit.unitSplashArt;

    }


    public void SpriteChange()
    {
        menuFraction.gameObject.SetActive(true);
        map.SetActive(false);
        
        menuFraction.unit1.sprite = unit1;
        menuFraction.unit2.sprite = unit2;
        menuFraction.unit3.sprite = unit3;
        menuFraction.unit4.sprite = unit4;
        menuFraction.herb.sprite = herb;
    }
}
