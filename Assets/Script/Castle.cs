using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class castle : MonoBehaviour
{
    public Sprite unit1;
    public Sprite unit2;
    public Sprite unit3;
    public Sprite unit4;
    public MenuFraction menuFraction;
    

    private void Start()
    {
        menuFraction.gameObject.SetActive(true); 
        
        menuFraction.unit1.sprite = unit1;
        menuFraction.unit2.sprite = unit2;
        menuFraction.unit3.sprite = unit3;
        menuFraction.unit4.sprite = unit4;
    }
}
