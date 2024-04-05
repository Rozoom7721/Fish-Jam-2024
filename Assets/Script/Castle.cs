using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public Sprite unit1;
    public Sprite unit2;
    public Sprite unit3;
    public Sprite unit4;
    public Sprite herb;
    public MenuFraction menuFraction;
    public GameObject map;

    

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
